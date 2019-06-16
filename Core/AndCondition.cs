using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    class AndCondition : Condition
    {
        public Condition FirstCondition { get; set; }

        public Condition SecondCondition { get; set; }
    }
}