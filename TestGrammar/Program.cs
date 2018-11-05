using BuildGrammar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGrammar
{
    internal class Program
    {
        private static void CompileJavaCode(string pathToGrammar)
        {
            Process process = new Process();

            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.FileName = "javac";

            string compilePath = " " + pathToGrammar.Substring(0, pathToGrammar.LastIndexOf('\\') + 1) + "*.java";

            process.StartInfo.Arguments = "-cp ..\\..\\..\\antlr-4.7.1-complete.jar" + compilePath;
            process.Start();

            Console.WriteLine(process.StandardOutput.ReadToEnd());
            Console.WriteLine(process.StandardError.ReadToEnd());

            process.WaitForExit();
        }

        private static void DeleteFiles(string pathToGrammar)
        {
            DirectoryInfo grammarDirectory = new DirectoryInfo(pathToGrammar.Substring(0, pathToGrammar.LastIndexOf('\\') + 1));

            foreach (FileInfo javaFile in grammarDirectory.EnumerateFiles("*.java"))
            {
                javaFile.Delete();
            }

            foreach (FileInfo classFile in grammarDirectory.EnumerateFiles("*.class"))
            {
                classFile.Delete();
            }
        }

        private static void InvokeTestRig(string[] args)
        {
            Process process = new Process();

            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.FileName = "java";
            process.StartInfo.WorkingDirectory = args[0].Substring(0, args[0].LastIndexOf('\\') + 1);

            string arguments = " " + args[0].Substring(args[0].LastIndexOf('\\') + 1).Replace(".g4", string.Empty) + " " + args[1];

            process.StartInfo.Arguments = "-cp \".;..\\antlr-4.7.1-complete.jar\" org.antlr.v4.gui.TestRig" + arguments + " -gui";
            process.Start();

            string sentenceToEvaluate = string.Empty;
            args.Skip(2).ToList().ForEach(a => sentenceToEvaluate += " " + a);

            process.StandardInput.WriteLine(sentenceToEvaluate);
            process.StandardInput.Close();
        }

        private static void Main(string[] args)
        {
            // 1. Builds the grammar using java as the language for the generated code.
            GrammarBuilder.BuildGrammar(new string[] { args[0] });

            // 2. Compiles the generated code.
            CompileJavaCode(args[0]);

            // 3. Invoke TestRig utility.
            InvokeTestRig(args);

            System.Threading.Thread.Sleep(5000);

            // 4. Delete java and class files.
            DeleteFiles(args[0]);
        }
    }
}