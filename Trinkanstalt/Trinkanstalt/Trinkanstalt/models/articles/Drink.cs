using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Trinkanstalt.models
{
    class Drink : Food
    {
        private double _amount;

        public double Amount
        {
            get { return this._amount; }
            set
            {
                if (value >= 0)
                {
                    this._amount = value;
                }
            }
        }

        public Drink() : this("", 0.0, 0.0, 0.0) { }
        public Drink(string name, double price, double popular, double amount) : base(name, price, popular)
        {
            this.Amount = amount;
        }

        public override string ToString()
        {
            return base.ToString() + "\n" +
                Amount.ToString() + "ml";
        }
    }
}
