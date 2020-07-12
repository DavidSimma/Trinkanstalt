using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models
{
    class Location
    {
        private int _peopleLimit;
        public Inventory inventory = new Inventory();

        public int LocationID { get; }
        public string LocationTitel { get; set; }
        public Person Host { get; set; }
        public string Address { get; set; }
        public int PeopleLimit
        {
            get { return this._peopleLimit; }
            set
            {
                if (this._peopleLimit >= 0)
                {
                    this._peopleLimit = value;
                }
            }
        }
        public bool LocationPass { get; set; }

        public Location() : this("", ListContainer.getDefaultPerson(), "", 5, false) { }
        public Location(string locationTitle, Person host, string address, int peopleLimit, bool locationPass)
        {
            this.LocationID = ListContainer.createLocationID();
            this.LocationTitel = locationTitle;
            this.Host = host;
            this.Address = address;
            this.PeopleLimit = peopleLimit;
            this.LocationPass = locationPass;
        }

        public override string ToString()
        {
            return LocationTitel + "\n" +
                "Veranstalter: " + Host.ToString() + "\n" +
                Address.ToString() + "\n" +
                "Platzbegrenzung: " + PeopleLimit.ToString() + " Personen" + "\n" +
                "Location freigegeben: " + LocationPass.ToString();

        }

    }
}
