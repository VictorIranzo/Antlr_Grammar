using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public static class ComparisonUtilities
    {
        public static Comparison GetComparisonNumeric(string comparisonString)
        {
            switch (comparisonString)
            {
                case "es mayor que":
                    return Comparison.GreaterThan;
                default:
                    throw new Exception();
            }
        }
    }
}
