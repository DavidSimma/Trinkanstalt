using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models
{
    class Mixture : Drink
    {
        public Mixture() : this("", 0.0, false, 0.0, 0.0) { }
        public Mixture(string name, double price, bool paid, double popular, double amount) : base(name, price, paid, popular, amount)
        {
            
        }

        
    }
}
