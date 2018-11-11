using BuildGrammar;
using JavaUtilities;
using System;
using System.Diagnostics;

namespace IntellisenseTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // 1. Builds the grammar using java as the language for the generated code.
            GrammarBuilder.BuildGrammar(new string[] { args[0] });

            // 2. Compiles the generated code.
            JavaCompiler.CompileJavaCode(args[0].Substring(0, args[0].LastIndexOf('\\') + 1));

            // 3. Invoke suggester.
            Suggester.Suggest(args[0].Substring(0, args[0].LastIndexOf('\\') + 1), args[0].Substring(args[0].LastIndexOf('\\') + 1).Replace(".g4", string.Empty), args[1]);

            // 4. Delete java and class files.
            JavaStepsDeleter.DeleteFiles(args[0].Substring(0, args[0].LastIndexOf('\\') + 1));

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}