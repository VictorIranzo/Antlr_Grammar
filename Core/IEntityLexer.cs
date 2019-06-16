using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IEntityLexer<TLexer>
        where TLexer : Lexer
    {
    }
}