﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models
{
    class UserInventory
    {
        private Dictionary<Food, int> _inventory = new Dictionary<Food, int>();

        public int UserInventoryID { get; }
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
                    foreach (Drink drink in Container.getFood())
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
                    foreach (Drink drink in Container.getFood())
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
                    foreach (Snacks snack in Container.getFood())
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
                    foreach (Snacks snack in Container.getFood())
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
        public Dictionary<Food, int> getFood()
        {
            return this._inventory;
        }

        public double getTotalAlcoholAmount()
        {
            double totalAlcohol = 0;

            Type a = getFood().GetType();
            Type b = typeof(Alcohol);
            if (a.Equals(b))
            {
                foreach (Alcohol d in getFood().Keys)
                {
                    totalAlcohol += (d.Amount * getFood()[d]);
                }
            }

            return totalAlcohol;
        }
        public double getTotalMixtureAmount()
        {
            double totalMixture = 0;

            Type a = getFood().GetType();
            Type b = typeof(Mixture);
            if (a.Equals(b))
            {
                foreach (Mixture d in getFood().Keys)
                {
                    totalMixture += (d.Amount * getFood()[d]);
                }
            }

            return totalMixture;
        }
        public double getTotalSnackWeight()
        {
            double totalWeight = 0;

            Type a = getFood().GetType();
            Type b = typeof(Snacks);
            if (a.Equals(b))
            {
                foreach (Snacks d in getFood().Keys)
                {
                    totalWeight += (d.Weight * getFood()[d]);
                }
            }

            return totalWeight;
        }
        public double getTotalValue()
        {
            double totalValue = 0;
            foreach(Food f in getFood().Keys)
            {
                totalValue += (f.Price * getFood()[f]);
            }
            return totalValue;
        }


        public UserInventory() : this(Container.getDefaultUser()) { }
        public UserInventory(User userInventoryHost)
        {
            this.UserInventoryID = userInventoryHost.UserID;
            this.UserInventoryHost = userInventoryHost;
        }

        public override string ToString()
        {
            return "Inventory - Host: " + UserInventoryHost.ToString() + "\n" +
                getFood().ToString();
        }
    }
}