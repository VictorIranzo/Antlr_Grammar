using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antlr.Grammar
{
    public partial class GrammarParser
    {
        public partial class CondicionContext
        {
            internal List<Condition> conditions;

            internal List<Condition> Conditions
            {
                get
                {
                    if (conditions == null)
                    {
                        conditions = new List<Condition>();
                    }

                    return conditions;
                }
                set
                {
                    conditions = value;
                }
            }
        }

        public partial class ReglaContext
        {
            internal List<Condition> conditions;

            internal List<Condition> Conditions
            {
                get
                {
                    if (conditions == null)
                    {
                        conditions = new List<Condition>();
                    }

                    return conditions;
                }
                set
                {
                    conditions = value;
                }
            }
        }
    }
}