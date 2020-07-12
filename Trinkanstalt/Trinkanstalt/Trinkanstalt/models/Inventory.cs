using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models
{
    class Inventory
    {
        private Dictionary<Food, int> _inventory = new Dictionary<Food, int>();

        public int InventoryID { get; }
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
                    foreach(Drink drink in ListContainer.getFood())
                    {
                        if (d.FoodID.Equals(drink.FoodID))
                        {
                            drink.Popular += drink.Amount * amount;
                        }
                    }                    
                    return true;
                }
                if ((_inventory[d] - amount) == 0)
                {
                    _inventory.Remove(d);
                    foreach (Drink drink in ListContainer.getFood())
                    {
                        if (d.FoodID.Equals(drink.FoodID))
                        {
                            drink.Popular += drink.Amount * amount;
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
                    foreach (Snacks snack in ListContainer.getFood())
                    {
                        if (s.FoodID.Equals(snack.FoodID))
                        {
                            snack.Popular += snack.Weight * amount;
                        }
                    }
                    return true;
                }
                if ((_inventory[s] - amount) == 0)
                {
                    _inventory.Remove(s);
                    foreach (Snacks snack in ListContainer.getFood())
                    {
                        if (s.FoodID.Equals(snack.FoodID))
                        {
                            snack.Popular += snack.Weight * amount;
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

        public Inventory() : this(null) { }
        public Inventory(Dictionary<Food, int> inventory)
        {
            this._inventory = inventory;
        }

        public override string ToString()
        {
            return this._inventory.ToString();
        }
    }
}
