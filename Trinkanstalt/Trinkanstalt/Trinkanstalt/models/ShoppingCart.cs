using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Trinkanstalt.models
{
    class ShoppingCart
    {
        private Dictionary<Food, int> _articles = new Dictionary<Food, int>();
        private bool bought;
        private List<Location> _locations = Container.getLocations();

        public List<Location> getLocations()
        {
            return _locations;
        }
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
                if (!(_articles[f] - amount <= 0))
                {
                    _articles.Remove(f);
                    user.Balance.addCredit(f.Price * amount);
                    return true;
                }
            }
            return false;
        }
        public Dictionary<Food, int> getArticles()
        {
            return this._articles;
        }
    }
}
