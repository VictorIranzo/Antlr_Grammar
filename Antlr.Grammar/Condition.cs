using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antlr.Grammar
{
    internal class Condition
    {
        public string Comparison { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
    }
}