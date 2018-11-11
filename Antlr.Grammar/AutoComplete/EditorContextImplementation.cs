using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;

namespace Antlr.Grammar.AutoComplete
{
    public class EditorContextImplementation : EditorContext
    {
        public const int CARET_TOKEN_TYPE = -10;
        private readonly Lexer lexer;

        public EditorContextImplementation(GrammarLexer grammarLexer)
        {
            this.lexer = grammarLexer;
        }

        public List<IToken> PreceedingTokens()
        {
            List<IToken> tokens = new List<IToken>();
            IToken nextToken;
            do
            {
                nextToken = this.lexer.NextToken();

                if (nextToken.Channel == 0 && nextToken.Type < 0)
                {
                    nextToken = new CommonToken(CARET_TOKEN_TYPE);
                }

                tokens.Add(nextToken);
            } while (nextToken.Type >= 0);

            return tokens;
        }
    }
}