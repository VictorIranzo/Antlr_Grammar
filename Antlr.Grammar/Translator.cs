using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Antlr.Grammar.GrammarParser;

namespace Antlr.Grammar
{
    public static class Translator
    {
        public static XDocument TranslateRuleToXml(ReglaContext reglaContext)
        {
            string xmlResult =
                $@"<Rule name=""{reglaContext.GetText()}"">
                    <Conditions>
                        <AND>
                            {GetConditions(reglaContext.Conditions)}
                        </AND>
                    </Conditions>
                  </Rule>
                ";

            return XDocument.Parse(xmlResult);
        }

        private static string GetConditions(List<Condition> conditions)
        {
            string xmlConditions = string.Empty;

            foreach (Condition condition in conditions)
            {
                xmlConditions +=
                    $@"
                            <Condition type =""{condition.Comparison}"">
                                <Field name=""{condition.Field}"">{condition.Value}</Field>
                            </Condition>
                    ";
            }

            return xmlConditions;
        }
    }
}