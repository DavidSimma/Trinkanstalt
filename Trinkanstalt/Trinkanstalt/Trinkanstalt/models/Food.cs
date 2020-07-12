using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models
{
    class Food
    {
        public int FoodID { get; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Popular { get; set; }
        

        public Food() : this("", 0.0, 0) { }
        public Food(string name, double price, int popular)
        {
            this.FoodID= ListContainer.createFoodID();
            this.Name = name;
            this.Price = price;
            this.Popular = popular;
        }

        public override string ToString()
        {
            return Name.ToString() + "\n" +
                Math.Round(Price, 2).ToString() + "€";
        }
    }  
}
