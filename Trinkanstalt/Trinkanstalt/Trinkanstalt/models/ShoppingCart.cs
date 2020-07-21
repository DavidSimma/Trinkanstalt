using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Trinkanstalt.models
{
    class ShoppingCart
    {
        private Dictionary<Food, int> _articles = new Dictionary<Food, int>();
        public bool Bought { get; set; }

        
        public void addArticles(Food f, int amount)
        {
            if (_articles.ContainsKey(f))
            {
                _articles[f] += amount;
            }
            else
            {
                _articles.Add(f, amount);
            }
        }
        public bool removeArticle(Food f, int amount, User user)
        {
            if (_articles.ContainsKey(f))
            {
                if (_articles[f] - amount > 0)
                {
                    _articles[f] -= amount;
                    user.Inventory.addFood(f, amount);
                    user.Balance.increaseCredit(f.Price * amount);
                    return true;
                }
            }
            if (_articles.ContainsKey(f))
            {
                if (_articles[f] - amount == 0)
                {
                    _articles.Remove(f);
                    user.Inventory.addFood(f, amount);
                    user.Balance.increaseCredit(f.Price * amount);
                    return true;
                }
            }
            return false;
        }

        public List<Food> filterBy(FoodType ft)
        {
            List<Food> __foundFoods = new List<Food>();
            foreach(Food f in DataWareHouse.Food)
            {
                if (f.FoodType.Equals(ft))
                {
                    __foundFoods.Add(f);
                }
            }
            return __foundFoods;
        }
        public Dictionary<Food, int> getArticles()
        {
            return this._articles;
        }
    }
}
