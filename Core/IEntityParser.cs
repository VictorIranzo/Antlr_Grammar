﻿using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IEntityParser<TEntity>
        where TEntity : Entity
    {
    }
}