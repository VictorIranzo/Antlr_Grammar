using System;
using System.Collections.Generic;
using BuildGrammar;
using JavaUtilities;

using System;

using System.Diagnostics;

namespace IntellisenseTest
{
    public static class Suggester
    {
        public static void Suggest(string grammarDirectory, string grammarName, string sentence)
        {
            Process process = new Process();

            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.FileName = "java";

            string urlToFolder = "file:" + grammarDirectory;

            process.StartInfo.Arguments = "-jar ..\\..\\..\\antlr4-autosuggest.jar " + urlToFolder + " " + grammarName + " \"" + sentence + "\"";
            process.Start();

            Console.WriteLine(process.StandardOutput.ReadToEnd());

            process.WaitForExit();
        }
    }
}