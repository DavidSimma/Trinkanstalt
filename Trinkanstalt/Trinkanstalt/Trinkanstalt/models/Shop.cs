﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models
{
    class Shop
    {
        private List<Food> _article = ListContainer.getFood();

        public List<Food> Article
        {
            get { return this._article; }
        }


    }
}