using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GrammarSuggester
{
    public class Suggester<TEntity>
        where TEntity : Entity
    {
        public Suggester(IEntityParser<TEntity> parser, IEntityLexer<TEntity> lexer)
        {
            this.EntityLexer = (Lexer)lexer;
            this.EntityParser = (Parser)parser;
        }

        public Lexer EntityLexer { get; set; }

        public Parser EntityParser { get; set; }

        public ILogger Logger { get; set; }

        public Dictionary<ATNState, int> parserStatesVisited = new Dictionary<ATNState, int>();

        public List<int> lexerStatesVisited = new List<int>();

        public IEnumerable<string> GetSuggestions(string sentence)
        {
            TokenizationResult sentenceTokens = this.GetSentenceTokens(sentence);

            return this.GetSuggestionsFromParser(sentenceTokens);
        }

        private TokenizationResult GetSentenceTokens(string sentence)
        {
            this.EntityLexer.SetInputStream(CharStreams.fromTextReader(new StringReader(sentence)));

            this.EntityLexer.RemoveErrorListeners();

            TokenizationResult tokenizationResult = new TokenizationResult();

            this.EntityLexer.AddErrorListener(new ErrorLexerListener(tokenizationResult, sentence));

            tokenizationResult.Tokens = this.EntityLexer.GetAllTokens();

            return tokenizationResult;
        }

        private IEnumerable<string> GetSuggestionsFromParser(TokenizationResult sentenceTokens)
        {
            ATNState initialState = this.EntityParser.Atn.states.FirstOrDefault();

            return this.GetSuggestionsFromParser(initialState, 0, sentenceTokens);
        }

        private IEnumerable<string> GetSuggestionsFromParser(ATNState parserState, int currentTokenListIndex, TokenizationResult sentenceTokens)
        {
            if (this.HasVisitedParserState(parserState, currentTokenListIndex))
            {
                return new List<string>();
            }

            int previousTokenListIndex = this.SetParserStateLastVisited(parserState, currentTokenListIndex);

            if (!HasMoreTokens(currentTokenListIndex, sentenceTokens))
            {
                // At this moment, the state in which the sentence ends has been reached.
                return SuggestNextTokensForParserState(parserState, sentenceTokens);
            }

            foreach (Transition transition in parserState.TransitionsArray)
            {
                switch (transition)
                {
                    case Transition _ when transition.IsEpsilon:
                        HandleEpsilonTransition(transition, currentTokenListIndex, sentenceTokens);

                        break;
                    case AtomTransition atomTransition:
                        HandleAtomicTransition(atomTransition, currentTokenListIndex, sentenceTokens);

                        break;
                    case SetTransition setTransition:
                        HandleSetTransition(setTransition, currentTokenListIndex, sentenceTokens);

                        break;
                    default:
                        return null;
                }
            }

            this.SetParserStateLastVisited(parserState, previousTokenListIndex);

            return new List<string>();
        }

        private IEnumerable<string> SuggestNextTokensForParserState(ATNState reachedParserState, TokenizationResult sentenceTokens)
        {
            HashSet<int> nextParserStateTransitionLabels = new HashSet<int>();

            FillParserTranstionLabels(reachedParserState, nextParserStateTransitionLabels, visitedTransitions: new HashSet<Transition>());

            return SuggestFromTransitionLabels(nextParserStateTransitionLabels, sentenceTokens);
        }

        private bool HasVisitedParserState(ATNState parserState, int currentTokenListIndex)
        {
            this.parserStatesVisited.TryGetValue(parserState, out int lastVisitedState);

            return lastVisitedState == currentTokenListIndex;
        }

        private int SetParserStateLastVisited(ATNState parserState, int currentTokenListIndex)
        {
            this.parserStatesVisited.Add(parserState, currentTokenListIndex);

            return currentTokenListIndex;
        }

        private static bool HasMoreTokens(int currentTokenListIndex, TokenizationResult sentenceTokens)
        {
            // Epsilon transitions don't consume a token, so don't move the index
            return currentTokenListIndex > sentenceTokens.Tokens.Count();
        }

        private void HandleEpsilonTransition(Transition transition, int currentTokenListIndex, TokenizationResult sentenceTokens)
        {
            GetSuggestionsFromParser(transition.target, currentTokenListIndex, sentenceTokens);
        }

        private void HandleAtomicTransition(AtomTransition atomTransition, int currentTokenListIndex, TokenizationResult sentenceTokens)
        {
            IToken nextToken = sentenceTokens.Tokens.ElementAt(currentTokenListIndex);

            if (atomTransition.Label == sentenceTokens.Tokens.ElementAt(currentTokenListIndex).TokenSource)
            {
                GetSuggestionsFromParser(atomTransition.target, currentTokenListIndex + 1, sentenceTokens);
            }
        }

        private void HandleSetTransition(SetTransition setTransition, int currentTokenListIndex, TokenizationResult sentenceTokens)
        {
            IToken nextToken = sentenceTokens.Tokens.ElementAt(currentTokenListIndex);

            foreach (int transitionTokenType in setTransition.Label.ToList())
            {
                if (transitionTokenType == nextToken.TokenIndex)
                {
                    GetSuggestionsFromParser(setTransition.target, currentTokenListIndex + 1, sentenceTokens);
                }
            }
        }

        private IEnumerable<string> SuggestFromTransitionLabels(HashSet<int> nextParserStateTransitionLabels, TokenizationResult sentenceTokens)
        {
            List<string> suggestions = new List<string>();

            foreach (int nextParserStateTransitionLabel in nextParserStateTransitionLabels)
            {
                // Count from 0 not from 1.
                int nextTokenRuleNumber = nextParserStateTransitionLabel - 1;
                ATNState lexerState = this.EntityLexer.Atn.ruleToStartState[nextTokenRuleNumber];

                SuggestFromTransitionLabels(lexerState, suggestions, tokensSoFar: string.Empty, remainingText: sentenceTokens.UntokenizedText);
            }

            return suggestions;
        }

        private void SuggestFromTransitionLabels(ATNState lexerState, List<string> suggestions, string tokensSoFar, string remainingText)
        {
            if (this.lexerStatesVisited.Contains(lexerState.stateNumber))
            {
                return;
            }

            this.lexerStatesVisited.Add(lexerState.stateNumber);

            bool tokenNotEmpty = tokensSoFar.Length > 0;
            bool noMoreCharactersInToken = !lexerState.TransitionsArray.Any();

            if (tokenNotEmpty && noMoreCharactersInToken)
            {
                suggestions.Add(tokensSoFar);

                return;
            }

            foreach (Transition transition in lexerState.TransitionsArray)
            {
                SuggestViaLexerTransition(tokensSoFar, remainingText, transition, suggestions);
            }

            this.lexerStatesVisited.Remove(this.lexerStatesVisited.Last());
        }

        private void SuggestViaLexerTransition(string tokensSoFar, string remainingText, Transition transition, List<string> suggestions)
        {
            switch (transition)
            {
                case Transition _ when transition.IsEpsilon:
                    SuggestFromTransitionLabels(transition.target, suggestions, tokensSoFar, remainingText);

                    break;
                case AtomTransition atomTransition:
                    string newTokenChar = atomTransition.Label.ToString();

                    if (string.IsNullOrEmpty(remainingText) || remainingText.StartsWith(newTokenChar))
                    {
                        SuggestViaNonEpsilonLexerTransition(tokensSoFar, remainingText, newTokenChar, transition.target, suggestions);
                    }

                    break;
                case SetTransition setTransition:
                    IList<int> symbols = setTransition.Label.ToList();

                    foreach (int symbol in symbols)
                    {
                        string charArr = Convert.ToString(symbol);

                        if (string.IsNullOrEmpty(remainingText) || remainingText.StartsWith(charArr))
                        {
                            SuggestViaNonEpsilonLexerTransition(tokensSoFar, remainingText, charArr, transition.target, suggestions);
                        }
                    }

                    break;
                default:
                    return;
            }
        }

        private void SuggestViaNonEpsilonLexerTransition(string tokenSoFar, string remainingText, string newTokenChar, ATNState targetState, List<string> suggestions)
        {
            string newRemainingText = (remainingText.Length > 0) ? remainingText.Substring(1) : remainingText;

            SuggestFromTransitionLabels(targetState, suggestions, tokenSoFar + newTokenChar, newRemainingText);
        }

        private void FillParserTranstionLabels(ATNState reachedParserState, HashSet<int> transitionLabels, HashSet<Transition> visitedTransitions)
        {
            foreach (Transition transition in reachedParserState.TransitionsArray)
            {
                if (visitedTransitions.Contains(transition))
                {
                    continue;
                }

                switch (transition)
                {
                    case Transition _ when transition.IsEpsilon:
                        visitedTransitions.Add(transition);
                        FillParserTranstionLabels(transition.target, transitionLabels, visitedTransitions);

                        break;
                    case AtomTransition atomTransition:
                        // EOF would be -1.
                        if (atomTransition.Label.SingleElement >= 1)
                        {
                            transitionLabels.Add(atomTransition.Label.SingleElement);
                        }

                        break;
                    case SetTransition setTransition:
                        foreach (Interval interval in setTransition.Label.GetIntervals())
                        {
                            for (int i = interval.a; i <= interval.b; ++i)
                            {
                                transitionLabels.Add(i);
                            }
                        }

                        break;
                    default:
                        return;
                }
            }
        }
    }
}