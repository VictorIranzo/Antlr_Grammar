using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GrammarSuggester
{
    public class ErrorLexerListener : IAntlrErrorListener<int>
    {
        public ErrorLexerListener(TokenizationResult tokenizationResult, string sentence)
        {
            this.TokenizationResult = tokenizationResult;
            this.Sentence = sentence;
        }

        public TokenizationResult TokenizationResult { get; }

        public string Sentence { get; }

        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            this.TokenizationResult.UntokenizedText = this.Sentence.Substring(charPositionInLine);
        }
    }
}