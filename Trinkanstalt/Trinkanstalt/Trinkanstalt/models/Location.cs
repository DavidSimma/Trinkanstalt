using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models
{
    class Location
    {
        private int _peopleLimit;

        
        public int LocationID { get; }
        public string LocationTitel { get; set; }
        public User Host { get; set; }
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
        public List<Event> getLocatedEvents()
        {
            List<Event> __foundEvents = new List<Event>();
            foreach(Event e in Container.getEvents())
            {
                if (e.EventActive && e.EventLocation.LocationID == this.LocationID)
                {
                    __foundEvents.Add(e);
                }
            }
            return __foundEvents;
        }

        public Location() : this("", Container.getDefaultUser(), "", 5, false) { }
        public Location(string locationTitle, User host, string address, int peopleLimit, bool locationPass)
        {
            this.LocationID = Container.createLocationID();
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
