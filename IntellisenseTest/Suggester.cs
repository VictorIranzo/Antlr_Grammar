using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace IntellisenseTest
{
    public static class Suggester
    {
        public static IEnumerable<string> Suggest(string grammarDirectory, string grammarName, string sentence)
        {
            Process process = new Process();

            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = "java";

            string urlToFolder = "file:" + grammarDirectory;

            process.StartInfo.Arguments = "-jar ..\\..\\..\\antlr4-autosuggest.jar " + urlToFolder + " " + grammarName + " \"" + sentence + "\"";
            process.Start();

            List<string> suggestions = new List<string>();

            while (!process.StandardOutput.EndOfStream)
            {
                suggestions.Add(process.StandardOutput.ReadLine());
            }

            process.WaitForExit();

            return suggestions;
        }
    }
}