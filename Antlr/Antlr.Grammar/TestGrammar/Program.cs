using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Program
{
    private static void Main(string[] args)
    {
        //// "Si la presión arterial del usuario es mayor que 50 y el nombre del usuario contiene \"Pepe\".
        AntlrInputStream stream = new AntlrInputStream("r hello pato");
        GrammarLexer lexer = new GrammarLexer(stream);
        CommonTokenStream tokens = new CommonTokenStream(lexer);

        GrammarParser parser = new GrammarParser(tokens);
    }
}