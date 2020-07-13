using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models
{
    class TotalInventory
    {     
        public List<UserInventory> getAllInventorys()
        {
            List<UserInventory> __inventorys = new List<UserInventory>();
            foreach (User u in Container.getUser())
            {
                __inventorys.Add(u.Inventory);
            }
            return __inventorys;
        }

        public double getTotalAlcoholAmount()
        {
            double totalAlcohol = 0;
            foreach(UserInventory ui in getAllInventorys())
            {
                totalAlcohol += ui.getTotalAlcoholAmount();
            }
            return totalAlcohol;
        }
        public double getTotalMixtureAmount()
        {
            double totalMixture = 0;
            foreach (UserInventory ui in getAllInventorys())
            {
                totalMixture += ui.getTotalMixtureAmount();
            }
            return totalMixture;
        }
        private double getTotalSnackWeight()
        {
            double totalWeight = 0;
            foreach (UserInventory ui in getAllInventorys())
            {
                totalWeight += ui.getTotalSnackWeight();
            }
            return totalWeight;
        }
        private double getTotalValue()
        {
            double totalValue = 0;
            foreach (UserInventory ui in getAllInventorys())
            {
                totalValue += ui.getTotalValue();
            }
            return totalValue;
        }

        public TotalInventory() { }

        public override string ToString()
        {
            return getAllInventorys().ToString();
        }
    }
}
