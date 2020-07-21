using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models
{
    class TotalInventory
    {     
        public static List<UserInventory> AllInventorys { 
            get 
            {
                List<UserInventory> __inventorys = new List<UserInventory>();
                foreach (User u in DataWareHouse.User)
                {
                    __inventorys.Add(u.Inventory);
                }
                return __inventorys;
            } 
        }
        
            

        public static double TotalAlcoholAmount { 
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
        
            
        
        public static double TotalMixtureAmount
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
        private static double TotalSnackWeight
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
        private static double TotalValue
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
