using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using static Antlr.Grammar.GrammarParser;

namespace Antlr.Grammar
{
    internal class GrammarParserListener : GrammarBaseListener
    {
        public override void ExitCondicion([NotNull] GrammarParser.CondicionContext context)
        {
            base.ExitCondicion(context);

            if (context.comparisonString() != null)
            {
                context.Conditions.Add(new Condition()
                {
                    Comparison = context.comparisonString().GetText(),
                    Field = DescriptionToFieldConverter.GetField(context.attributeString().GetText()),
                    Value = context.SEARCH().GetText()
                });
            }

            if (context.comparsionNumeric() != null)
            {
                context.Conditions.Add(new Condition()
                {
                    Comparison = context.comparsionNumeric().GetText(),
                    Field = DescriptionToFieldConverter.GetField(context.attributeNumeric().GetText()),
                    Value = context.INT().GetText()
                });
            }

            if (context.Parent is ReglaContext reglaContext)
            {
                reglaContext.Conditions.AddRange(context.Conditions);
            }

            if (context.Parent is CondicionContext conditionContext)
            {
                conditionContext.Conditions.AddRange(context.Conditions);
            }
        }
    }
}