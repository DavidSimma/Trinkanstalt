using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models.articles
{
    class FinishedMixture
    {
        private int _mixture;
        public int FinishedMixtureID { get; }
        public string Name { get; set; }
        public Alcohol Alcohol { get; set; }
        public Mixture Mixture { get; set; }
        public int MixtureAmount
        {
            get
            {
                double onePercent = Alcohol.Amount / MixingRatio;
                double perfectTotalAmount = onePercent * 100 - MixingRatio;
                double perfectAmount = perfectTotalAmount / Mixture.Amount;
                return (int)Math.Floor(perfectAmount);

            }
        }
        public int MixingRatio {
            get
            {
                return this._mixture;
            }
            set
            {
                if(value >= 0)
                {
                    this._mixture = value;
                }
            }
        }

        public FinishedMixture() : this("", null, null, 0) { }
        public FinishedMixture(string name, Alcohol alcohol, Mixture mixture, int mixtureRatio)
        {
            this.FinishedMixtureID = DataWareHouse.createFinischedMixturesID();
            this.Name = name;
            this.Alcohol = alcohol;
            this.Mixture = mixture;
            this.MixingRatio = mixtureRatio;
        }

        public override string ToString()
        {
            return "Alkoholgetränk: " + Alcohol.Name.ToString() + "\n" +
                "Mischgetränk: " + Mixture.Name.ToString() + "\n" +
                "Verhältnis: " + MixingRatio + "/" + (100 - MixingRatio).ToString();
        }
    }
}
