using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antlr.Grammar.AutoComplete
{
    public static class ListTokenSourceExtensions
    {
        public static IToken AtCaret(this ListTokenSource listTokenSource)
        {
            for (int i = 0; i < listTokenSource.InputStream.Size; i++)
            {
                listTokenSource.NextToken();
            }

            return listTokenSource.NextToken();
        }
    }
}