using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models
{
    class UserInventory
    {
        private Dictionary<Food, int> _inventory = new Dictionary<Food, int>();

        
        public User UserInventoryHost { get; set; }
        public void addFood(Food f, int amount)
        {
            if (_inventory.ContainsKey(f))
            {
                _inventory[f] += amount;
            }
            else
            {
                _inventory.Add(f, amount);
            }
        }
        public bool removeFood(Drink d, int amount)
        {
            if (_inventory.ContainsKey(d))
            {
                if ((_inventory[d] - amount) > 0)
                {
                    _inventory[d] -= amount;
                    foreach (Drink drink in DataWareHouse.Food)
                    {
                        if (d.FoodID.Equals(drink.FoodID))
                        {
                            drink.Popular += (drink.Amount * amount);
                        }
                    }
                    return true;
                }
                if ((_inventory[d] - amount) == 0)
                {
                    _inventory.Remove(d);
                    foreach (Drink drink in DataWareHouse.Food)
                    {
                        if (d.FoodID.Equals(drink.FoodID))
                        {
                            drink.Popular += (drink.Amount * amount);
                        }
                    }
                    return true;
                }

            }
            return false;
        }
        public bool removeFood(Snacks s, int amount)
        {
            if (_inventory.ContainsKey(s))
            {
                if ((_inventory[s] - amount) > 0)
                {
                    _inventory[s] -= amount;
                    foreach (Snacks snack in DataWareHouse.Food)
                    {
                        if (s.FoodID.Equals(snack.FoodID))
                        {
                            snack.Popular += (snack.Weight * amount);
                        }
                    }
                    return true;
                }
                if ((_inventory[s] - amount) == 0)
                {
                    _inventory.Remove(s);
                    foreach (Snacks snack in DataWareHouse.Food)
                    {
                        if (s.FoodID.Equals(snack.FoodID))
                        {
                            snack.Popular += (snack.Weight * amount);
                        }
                    }
                    return true;
                }

            }
            return false;
        }
        public Dictionary<Food, int> Food
        {
            get
            {
                return this._inventory;
            }
        }

        public double TotalAlcoholAmount
        {
            get
            {
                double totalAlcohol = 0;

                Type a = Food.GetType();
                Type b = typeof(Alcohol);
                if (a.Equals(b))
                {
                    foreach (Alcohol d in Food.Keys)
                    {
                        totalAlcohol += (d.Amount * Food[d]);
                    }
                }

                return totalAlcohol;
            }
        }
        public double TotalMixtureAmount
        {
            get
            {
                double totalMixture = 0;

                Type a = Food.GetType();
                Type b = typeof(Mixture);
                if (a.Equals(b))
                {
                    foreach (Mixture d in Food.Keys)
                    {
                        totalMixture += (d.Amount * Food[d]);
                    }
                }

                return totalMixture;
            }
        }
        public double TotalSnackWeight
        {
            get
            {
                double totalWeight = 0;

                Type a = Food.GetType();
                Type b = typeof(Snacks);
                if (a.Equals(b))
                {
                    foreach (Snacks d in Food.Keys)
                    {
                        totalWeight += (d.Weight * Food[d]);
                    }
                }

                return totalWeight;
            }
        }
        public double TotalValue
        {
            get
            {
                double totalValue = 0;
                foreach (Food f in Food.Keys)
                {
                    totalValue += (f.Price * Food[f]);
                }
                return totalValue;
            }
        }


        public UserInventory() : this(DataWareHouse.DefaultUser) { }
        public UserInventory(User userInventoryHost)
        {
            
            this.UserInventoryHost = userInventoryHost;
        }

        public override string ToString()
        {
            return "Inventory - Host: " + UserInventoryHost.ToString() + "\n" +
                Food.ToString();
        }
    }
}
