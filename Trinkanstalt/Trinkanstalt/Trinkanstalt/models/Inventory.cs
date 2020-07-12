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
        public bool removeFood(Food f, int amount)
        {
            if (_inventory.ContainsKey(f))
            {
                if ((_inventory[f] - amount) > 0)
                {
                    _inventory[f] -= amount;
                    return true;
                }
                if ((_inventory[f] - amount) == 0)
                {
                    _inventory.Remove(f);
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
