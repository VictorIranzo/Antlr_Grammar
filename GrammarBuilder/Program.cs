using System;

namespace GrammarBuilder
{
    class Program
    {
        /// <summary>
        ///     Main entry point.
        /// </summary>
        /// <param name="grammarPath"> The path to the grammar. </param>
        /// <param name="antlrJarPath"> The path to the JAR of the ANTLR. </param>
        /// <param name="generateVisitor"> A value that states if a visitor of the grammar is generated. </param>
        /// <param name="grammarCodeGeneratedLanguage"> The Language in which the code is generated. </param>
        /// <param name="grammarNamespace"> The grammar generated code namespace. </param>
        /// <returns></returns>
        static int Main(string grammarPath, string antlrJarPath, bool generateVisitor, Language grammarCodeGeneratedLanguage, string grammarNamespace = null)
        {
            GrammarBuilder.BuildGrammar(grammarPath, antlrJarPath, generateVisitor, grammarNamespace, grammarCodeGeneratedLanguage);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            return 0;
        }
    }
}
