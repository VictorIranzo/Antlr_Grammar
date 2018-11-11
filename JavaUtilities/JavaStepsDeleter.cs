using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JavaUtilities
{
    public class JavaStepsDeleter
    {
        public static void DeleteFiles(string pathToDelete)
        {
            DirectoryInfo grammarDirectory = new DirectoryInfo(pathToDelete);

            foreach (FileInfo javaFile in grammarDirectory.EnumerateFiles("*.java"))
            {
                javaFile.Delete();
            }

            foreach (FileInfo classFile in grammarDirectory.EnumerateFiles("*.class"))
            {
                classFile.Delete();
            }
        }
    }
}