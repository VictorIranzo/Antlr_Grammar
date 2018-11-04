using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGrammar
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

            string arguments = string.Empty;
            args.ToList().ForEach(a => arguments += " " + a);

            process.StartInfo.Arguments = "-cp ..\\..\\..\\antlr-4.7.1-complete.jar org.antlr.v4.gui.TestRig" + arguments;
            process.Start();

            Console.WriteLine(process.StandardOutput.ReadToEnd());
            Console.WriteLine(process.StandardError.ReadToEnd());

            process.WaitForExit();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}