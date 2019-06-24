using Antlr4.Runtime;
using System.Collections;
using System.Collections.Generic;

namespace GrammarSuggester
{
    public class TokenizationResult
    {
        public IEnumerable<IToken> Tokens { get; set; }

        public string UntokenizedText { get; set; }
    }
}