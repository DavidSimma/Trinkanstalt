using Plugin.PushNotification;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

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
        public List<User> InvitedUser { get { return this._invited; } }
        
        public void addUserToEvent(User u)
        {
            
            if (_coming.Count-1 < EventLocation.PeopleLimit)
            {
                _coming.Add(u);
            }
            if (_coming.Count-1 == EventLocation.PeopleLimit)
            {
                _coming.Add(u);
                spreadOwes();
                
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
        public List<User> ComingUser { get { return this._coming; } }


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

        private void spreadOwes()
        {
            foreach (User us in _coming)
            {
                if (us.Balance.Credit > 0)
                {
                    foreach (User use in _coming)
                    {
                        if (!us.Equals(use))
                        {
                            use.Balance.increasOwe(us, us.Balance.Credit / _coming.Count - 1);
                        }
                    }
                }
            }
        }
        

        public Event() : this("", Container.DefaultUser, Container.DefaulLocation, DateTime.MinValue) { }
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
