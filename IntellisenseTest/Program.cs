﻿using BuildGrammar;
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
            Suggest(args[0], args[1]);

            // 4. Delete java and class files.
            JavaStepsDeleter.DeleteFiles(args[0].Substring(0, args[0].LastIndexOf('\\') + 1));

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void Suggest(string grammarName, string sentence)
        {
            Process process = new Process();

            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.FileName = "java";

            process.StartInfo.Arguments = "-jar ..\\..\\..\\antlr4-autosuggest.jar " + grammarName.Replace(".g4", string.Empty) + " \"" + sentence + "\"";
            process.Start();

            Console.WriteLine(process.StandardOutput.ReadToEnd());
            Console.WriteLine(process.StandardError.ReadToEnd());

            process.WaitForExit();
        }
    }
}