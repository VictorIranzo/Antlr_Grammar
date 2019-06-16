using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Core
{
    public class SimpleCondition : Condition
    {
        public PropertyInfo Field { get; set; }

        public Comparison Comparison { get; set; }

        public object Value { get; set; }
    }
}