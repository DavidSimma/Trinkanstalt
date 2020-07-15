using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models
{
    class Mixture : Drink
    {
        public Mixture() : this("", 0.0, FoodType.Mixture, 0.0) { }
        public Mixture(string name, double price, FoodType foodType, double amount) : base(name, price, foodType, amount)
        {
            
        }

        
    }
}
