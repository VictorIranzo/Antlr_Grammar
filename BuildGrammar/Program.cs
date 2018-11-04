using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildGrammar
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GrammarBuilder.BuildGrammar(args);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}