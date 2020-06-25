using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.Models
{
    public enum MenuItemType
    {
        Startseite,
        LEDSteuern
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
