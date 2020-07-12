using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models
{
    class Alcohol : Drink
    {
        private double _alcoholContent;
        public double AlcoholContent
        {
            get { return this._alcoholContent; }
            set
            {
                if (value >= 0)
                {
                    this._alcoholContent = value;
                }
            }
        }
        public Alcohol() : this("", 0.0, 0, 0.0, 0.0) { }
        public Alcohol(string name, double price, int popular, double amount, double alcoholContent) : base(name, price, popular, amount)
        {
            this.AlcoholContent = alcoholContent;
        }

        public override string ToString()
        {
            return base.ToString() + "\n" +
                AlcoholContent.ToString() + "% Vol.";
        }
    }
}
