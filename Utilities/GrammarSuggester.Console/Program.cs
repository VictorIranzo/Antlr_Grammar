using Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace GrammarSuggester
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddUserGrammar();

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            Suggester<User> suggester = ActivatorUtilities.CreateInstance(serviceProvider, typeof(Suggester<User>)) as Suggester<User>;

            IEnumerable<string> suggestions = suggester.GetSuggestions("Hola");

            foreach (string suggestion in suggestions)
            {
                Console.WriteLine(suggester);
            }
        }
    }
}
