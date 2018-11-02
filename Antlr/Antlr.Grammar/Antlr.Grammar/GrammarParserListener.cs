using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace Antlr.Grammar
{
    internal class GrammarParserListener : GrammarBaseListener
    {
        public override void EnterRegla([NotNull] GrammarParser.ReglaContext context)
        {
            Console.WriteLine("Hola");
            base.EnterRegla(context);
        }

        public override void VisitErrorNode([NotNull] IErrorNode node)
        {
            Console.WriteLine("Hola");

            base.VisitErrorNode(node);
        }
    }
}