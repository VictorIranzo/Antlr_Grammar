using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Antlr.Grammar.GrammarParser;

namespace Antlr.Grammar
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //// "Si la presión arterial del usuario es mayor que 50 y el nombre del usuario contiene \"Pepe\".
            AntlrInputStream stream = new AntlrInputStream("Si la presión arterial del usuario es mayor que 50 y el nombre del usuario contiene \"Pepe\"");
            GrammarLexer lexer = new GrammarLexer(stream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);

            GrammarParser parser = new GrammarParser(tokens);

            parser.BuildParseTree = true;

            ReglaContext tree = parser.regla();
        }
    }
}