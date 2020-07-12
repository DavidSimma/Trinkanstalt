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
    }
}
