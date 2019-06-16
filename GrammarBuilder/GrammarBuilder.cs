using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrammarBuilder
{
    public static class GrammarBuilder
    {
        public static void BuildGrammar(string antlrJarPath, bool generateVisitor, string grammarNamespace, Language grammarCodeGeneratedLanguage)
        {
            Process process = new Process();

            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.FileName = "java";

            string arguments = "-jar " + antlrJarPath;

            if (generateVisitor)
            {
                arguments += " -visitor";
            }

            if (!string.IsNullOrEmpty(grammarNamespace))
            {
                arguments += " -package=" + grammarNamespace;
            }

            arguments += " -DLanguage=" + grammarCodeGeneratedLanguage.GetLanguageString();

            process.StartInfo.Arguments = arguments;
            process.Start();

            Console.WriteLine(process.StandardOutput.ReadToEnd());
            Console.WriteLine(process.StandardError.ReadToEnd());

            process.WaitForExit();
        }
    }
}