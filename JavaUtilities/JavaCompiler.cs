using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace JavaUtilities
{
    public class JavaCompiler
    {
        public static void CompileJavaCode(string pathToCompile)
        {
            Process process = new Process();

            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.FileName = "javac";

            process.StartInfo.Arguments = "-cp ..\\..\\..\\antlr-4.7.1-complete.jar " + pathToCompile + "*.java";
            process.Start();

            Console.WriteLine(process.StandardOutput.ReadToEnd());
            Console.WriteLine(process.StandardError.ReadToEnd());

            process.WaitForExit();
        }
    }
}