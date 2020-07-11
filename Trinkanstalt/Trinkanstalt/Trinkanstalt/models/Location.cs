using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models
{
    class Location
    {
        private int _peopleLimit;
        private List<Person> _invited;
        public Inventory inventory = new Inventory;

        public int LocationID { get; }
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
        public List<Person> Invited
        {
            get { return this._invited; }
            set { if(Invited.Count <= PeopleLimit)
                {
                    this._invited = value;
                } 
            }
        }

        public Location() : this(ListContainer.getDefaultPerson(), "", 5, null) { }
        public Location(Person host, string address, int peopleLimit, List<Person> invited)
        {
            this.Host = host;
            this.Address = address;
            this.PeopleLimit = peopleLimit;
            this.Invited = invited;
        }

    }
}
