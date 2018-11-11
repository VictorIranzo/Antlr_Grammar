using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antlr.Grammar.AutoComplete
{
    public class AntlrAutoCompletionSuggester : AutoCompletionSuggester
    {
        private readonly ATN atn;
        private readonly Vocabulary vocabulary;

        public AntlrAutoCompletionSuggester(Vocabulary vocabulary, ATN atn)
        {
            this.vocabulary = vocabulary;
            this.atn = atn;
        }

        public void Process(List<string> ruleNames, Vocabulary vocabulary, ATNState atnState, ListTokenSource tokens, List<IntervalSet> collector, ParserStack parserStack, HashSet<int> alreadyPassed, List<string> history)
        {
            IToken atCaret = tokens.AtCaret();

            Tuple<bool, ParserStack> stackRes = parserStack.Process(atnState);

            if (stackRes.Item1 == null)
            {
                return;
            }

            foreach (Transition transition in atnState.TransitionsArray)
            {
                string description = GetDescription(ruleNames, vocabulary, atnState, transition);

                if (transition.IsEpsilon)
                {
                    if (!alreadyPassed.Contains(transition.target.stateNumber))
                    {
                        alreadyPassed.Add(transition.target.stateNumber);
                        history.Add(description);

                        Process(ruleNames, vocabulary, transition.target, tokens, collector, stackRes.Item2, alreadyPassed, history);
                    }

                    if (transition is AtomTransition)
                    {
                        IToken nextToken = tokens.NextToken();

                        if (atCaret != null)
                        {
                            if (IsCompatibleWithStack(transition.target, parserStack))
                            {
                                collector.Add(transition.Label);
                            }
                        }
                    }
                }
            }
        }

        public List<TokenType> Suggestions(EditorContext editorContext)
        {
            List<string> ruleNames = new List<string>() { "regla" };
            List<TokenType> tokenTypes = new List<TokenType>();

            Process(ruleNames, vocabulary, atn.states[0], new ListTokenSource(editorContext.PreceedingTokens()), tokenTypes, new ParserStack(), new HashSet<int>(), new List<string> { "start" });

            return tokenTypes;
        }

        private string GetDescription(List<string> ruleNames, Vocabulary vocabulary, ATNState atnState, Transition transition)
        {
            throw new NotImplementedException();
        }

        private bool IsCompatibleWithStack(ATNState target, ParserStack parserStack)
        {
            throw new NotImplementedException();
        }
    }
}