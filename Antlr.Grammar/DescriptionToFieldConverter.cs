using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antlr.Grammar
{
    internal class DescriptionToFieldConverter
    {
        internal static string GetField(string field)
        {
            if (field.Equals("la presion arterial del usuario"))
            {
                return "BloodPressure.Systolic";
            }

            if (field.Equals("el nombre del usuario"))
            {
                return "User.Name";
            }

            return string.Empty;
        }
    }
}