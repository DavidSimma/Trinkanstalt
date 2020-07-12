using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models
{
    public enum Spice
    {
        salted,
        sweet,
        undefined
    }
    class Snacks : Food
    {
        private int _weight;
        public int Weight {
            get { return this._weight; } 
            set { if(value >= 0){
                    this._weight = value;
                } 
            }
        }
        public Spice Spice { get; set; }

        public Snacks() : this("", 0.0, 0, 0, Spice.undefined) { }
        public Snacks(string name, double price, int popular, int weight, Spice spice) : base(name, price, popular)
        {
            this.Weight = weight;
            this.Spice = spice;
        }

        public override string ToString()
        {
            return base.ToString() + "\n" +
                Weight.ToString() + "g" + "\n" +
                Spice.ToString();
        }
    }
}
