using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class SimpleCondition : Condition
    {
        public object Field { get; set; }

        public Comparison Comparison { get; set; }

        public object Value { get; set; }
    }
}