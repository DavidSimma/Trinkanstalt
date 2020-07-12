using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models
{
    class Event
    {
        private List<Person> _invited = new List<Person>();
        
        public int EventID { get; }
        public string EventTitle { get; set; }
        public Person EventHost { get; set; }
        public Location EventLocation { get; set; }
        public DateTime EventDate { get; set; }
        public List<Person> Invited
        {
            get { return this._invited; }
            set
            {
                if (Invited.Count <= EventLocation.PeopleLimit)
                {
                    this._invited = value;
                }
            }
        }
        public bool EventActive
        {
            get { if (EventDate.Date > DateTime.Now.Date)
                {
                    return false;
                }
                return true;
            }
        }
        

        public Event() : this("", ListContainer.getDefaultPerson(), ListContainer.getDefaulLocation(), DateTime.MinValue) { }
        public Event(string eventTitle, Person eventHost, Location eventLocation, DateTime eventDate)
        {
            this.EventID = ListContainer.createEventID();
            this.EventTitle = eventTitle;
            this.EventHost = eventHost;
            this.EventLocation = eventLocation;
            this.EventDate = eventDate;
        }

        public override string ToString()
        {
            return EventTitle.ToString() + "\n" +
                "Event-Host: " + EventHost.ToString() + "\n" +
                EventLocation.ToString() + "\n" +
                EventDate.ToString() + "\n" +
                "Event aktiv: " + EventActive.ToString();
        }
    }
}
