using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models
{
    class Shop
    {
        private List<Food> _article = Container.Food;

        public List<Food> Article
        {
            get { return this._article; }
        }

        public List<Food> searchForArticle(string articleName)
        {
            List<Food> __foundArticle = new List<Food>();
            foreach(Food f in _article)
            {
                if (f.Name.Contains(articleName))
                {
                    __foundArticle.Add(f);
                }
            }
            return __foundArticle;
        }



    }
}
