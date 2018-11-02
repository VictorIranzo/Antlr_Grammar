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
            Process process = new Process();

            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.FileName = "java";
            process.StartInfo.Arguments = "-jar D:\\RulesDesigner\\Antlr\\antlr-4.7.1-complete.jar " + args[0] + " -visitor -Dlanguage=CSharp -package " + args[1];

            process.Start();

            Console.WriteLine(process.StandardOutput.ReadToEnd());
            Console.WriteLine(process.StandardError.ReadToEnd());

            process.WaitForExit();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}