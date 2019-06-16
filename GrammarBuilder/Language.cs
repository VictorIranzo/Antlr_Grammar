using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrammarBuilder
{
    public enum Language
    {
        Java = 1,
        CSharp = 2
    }

    public static class LanguageExtensions
    {
        public static string GetLanguageString(this Language language)
        {
            switch (language)
            {
                case Language.Java:
                    return "Java";
                case Language.CSharp:
                    return "CSharp";
                default:
                    return null;
            }
        }
    }
}