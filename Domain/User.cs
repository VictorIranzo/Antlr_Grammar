using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User : Entity
    {
        public bool IsVegetarian { get; set; }

        public bool IsIngressed { get; set; }

        public int Years { get; set; }
    }
}