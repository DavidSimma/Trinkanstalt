using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models
{
    public enum FoodType
    {
        Alcohol,
        Mixture,
        Snack,
        Other
    }
    abstract class Food
    {
        public int FoodID { get; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Popular { get; set; }
        public FoodType FoodType{ get; set; }


        public Food() : this("", 0.0, FoodType.Other) { }
        public Food(string name, double price, FoodType foodType)
        {
            this.FoodID= DataWareHouse.createFoodID();
            this.Name = name;
            this.Price = price;
            this.FoodType = foodType;
            
        }

        public override string ToString()
        {
            return Name.ToString() + "\n" +
                Math.Round(Price, 2).ToString() + "€";
        }
    }  
}
