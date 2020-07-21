using System;
using System.Collections.Generic;
using System.Text;
using Trinkanstalt.models.articles;

namespace Trinkanstalt.models
{
    class Shop
    {
        private List<Food> _article = DataWareHouse.Food;
        private List<FinishedMixture> _finishedMixtures = DataWareHouse.FinischedMixtures;

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
        public List<FinishedMixture> searchForFinishedMixtures(string FinishedMixtureName)
        {
            List<FinishedMixture> __foundFinishedMixtures = new List<FinishedMixture>();
            foreach (FinishedMixture fm in _finishedMixtures)
            {
                if (fm.Name.Contains(FinishedMixtureName))
                {
                    __foundFinishedMixtures.Add(fm);
                }
            }
            return __foundFinishedMixtures;
        }


    }
}
