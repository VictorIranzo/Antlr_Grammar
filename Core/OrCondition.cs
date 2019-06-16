using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class OrCondition : Condition
    {
        public Condition FirstCondition { get; set; }

        public Condition SecondCondition { get; set; }
    }
}