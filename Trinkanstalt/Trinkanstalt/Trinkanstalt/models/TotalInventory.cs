using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models
{
    class TotalInventory
    {     
        public List<UserInventory> AllInventorys { 
            get 
            {
                List<UserInventory> __inventorys = new List<UserInventory>();
                foreach (User u in Container.getUser())
                {
                    __inventorys.Add(u.Inventory);
                }
                return __inventorys;
            } 
        }
        
            

        public double TotalAlcoholAmount { 
            get 
            {
                double totalAlcohol = 0;
                foreach(UserInventory ui in AllInventorys)
                {
                    totalAlcohol += ui.TotalAlcoholAmount;
                }
                return totalAlcohol; 
            } 
        }
        
            
        
        public double TotalMixtureAmount
        {
            get
            {
                double totalMixture = 0;
                foreach (UserInventory ui in AllInventorys)
                {
                    totalMixture += ui.TotalMixtureAmount;
                }
                return totalMixture;
            }
        }
        private double TotalSnackWeight
        {
            get
            {
                double totalWeight = 0;
                foreach (UserInventory ui in AllInventorys)
                {
                    totalWeight += ui.TotalSnackWeight;
                }
                return totalWeight;
            }
        }
        private double TotalValue
        {
            get
            {
                double totalValue = 0;
                foreach (UserInventory ui in AllInventorys)
                {
                    totalValue += ui.TotalValue;
                }
                return totalValue;
            }
        }

        public TotalInventory() { }

        public override string ToString()
        {
            return AllInventorys.ToString();
        }
    }
}
