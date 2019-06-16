using Domain;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace UserGrammar
{
    public static class UserPropertiesDictionary
    {
        public static Dictionary<string, PropertyInfo> Dictionary = new Dictionary<string, PropertyInfo>()
        {
            { "es vegetariano", GetUserProperty(nameof(User.IsVegetarian)) },
            { "está ingresado", GetUserProperty(nameof(User.IsIngressed)) },
            { "la edad del usuario", GetUserProperty(nameof(User.Years)) }
        };

        private static PropertyInfo GetUserProperty(string propertyName)
        {
            return typeof(User).GetProperty(propertyName);
        }
    }
}