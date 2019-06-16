using Core;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class UserGrammarServiceCollectionExtensions
    {
        public static IServiceCollection AddUserGrammar(this IServiceCollection services)
        {
            services.AddScoped<IEntityParser<User>, UserGrammarParser>();
            services.AddScoped<IEntityLexer<User>, UserGrammarLexer>();

            return services;
        }
    }
}