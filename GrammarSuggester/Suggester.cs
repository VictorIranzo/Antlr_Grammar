using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
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


        public IEnumerable<string> GetSuggestions(string sentence)
        {
            IEnumerable<IToken> sentenceTokens = this.GetSentenceTokens(sentence);

            return this.GetSuggestionsFromParser(sentenceTokens);
        }

        private IEnumerable<IToken> GetSentenceTokens(string sentence)
        {
            this.EntityLexer.SetInputStream(CharStreams.fromTextReader(new StringReader(sentence)));

            return this.EntityLexer.GetAllTokens();
        }

        private IEnumerable<string> GetSuggestionsFromParser(IEnumerable<IToken> sentenceTokens)
        {
            ATNState initialState = this.EntityParser.Atn.states.FirstOrDefault();

            return this.GetSuggestionsFromParser(initialState, 0);
        }

        private IEnumerable<string> GetSuggestionsFromParser(ATNState parserState, int tokenListIndex)
        {
            throw new NotImplementedException();
        }
    }
}