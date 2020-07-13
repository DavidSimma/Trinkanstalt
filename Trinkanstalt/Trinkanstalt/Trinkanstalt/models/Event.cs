using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models
{
    class Event
    {
        private List<User> _invited = new List<User>();
        private List<User> _coming = new List<User>();
        
        public int EventID { get; }
        public string EventTitle { get; set; }
        public User EventHost { get; set; }
        public Location EventLocation { get; set; }
        public DateTime EventDate { get; set; }
        public void addAInvitedUser(User u)
        {
            if (_invited.Count <= EventLocation.PeopleLimit)
            {
                _invited.Add(u);
            }
        }
        public bool removeUserFromInvitedList(User u)
        {
            if (_invited.Remove(u))
            {
                return true;
            }
            return false;
        }
        public List<User> getAllInvitedUser()
        {
            return this._invited;
        }
        public void addUserToEvent(User u)
        {
            if (_coming.Count <= EventLocation.PeopleLimit)
            {
                _coming.Add(u);
            }
        }
        public bool removeUserFromEvent(User u)
        {
            if (_coming.Remove(u))
            {
                return true;
            }
            return false;
        }
        public List<User> getAllComingUser()
        {
            return this._coming;
        }


        public bool EventActive
        {
            get { 
                if (EventDate.Date > DateTime.Now.Date)
                {
                    return false;
                }
                return true;
            }
        }
        

        public Event() : this("", Container.getDefaultUser(), Container.getDefaulLocation(), DateTime.MinValue) { }
        public Event(string eventTitle, User eventHost, Location eventLocation, DateTime eventDate)
        {
            this.EventID = Container.createEventID();
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
