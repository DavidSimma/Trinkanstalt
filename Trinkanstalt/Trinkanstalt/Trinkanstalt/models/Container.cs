using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trinkanstalt.models
{
    class Container
    {
        private static List<User> _people = new List<User>();
        private static List<Food> _food = new List<Food>();
        private static List<Location> _locations = new List<Location>();
        private static List<Event> _events = new List<Event>();

        public static List<User> getUser(){
            return _people;
        }
        public static void addUser(User p)
        {
            _people.Add(p);
        }
        public static bool removeUser(User p)
        {
            if (_people.Remove(p))
            {
                return true;
            }
            return false;
        }
        public static int createUserID()
        {
            return _people.Count;
        }
        public static User getDefaultUser()
        {
            return _people[0];
        }



        public static List<Food> getFood()
        {
            return _food;
        }
        public static void addFood(Food f)
        {
            _food.Add(f);
        }
        public static bool removeFood(Food f)
        {
            if (_food.Remove(f))
            {
                return true;
            }
            return false;
        }
        public static int createFoodID()
        {
            return _food.Count;
        }


        public static List<Location> getLocations()
        {
            return _locations;
        }
        public static void addLocation(Location l)
        {
            _locations.Add(l);
        }
        public static bool removeLocation(Location l)
        {
            if (_locations.Remove(l))
            {
                return true;
            }
            return false;
        }
        public static int createLocationID()
        {
            return _locations.Count;
        }
        public static Location getDefaulLocation()
        {
            return _locations[0];
        }


        public static List<Event> getEvents()
        {
            return _events;
        }
        public static void addEvent(Event e)
        {
            _events.Add(e);
        }
        public static bool removeEvent(Event e)
        {
            if (_events.Remove(e))
            {
                return true;
            }
            return false;
        }
        public static int createEventID()
        {
            return _events.Count;
        }
        public static Event getDefaulEvent()
        {
            return _events[0];
        }



        public Container()
        {
            _people.Add(new User("", "", "Admin", DateTime.Today, Gender.unknown, RelationShipStatus.complicated, Status.admin ));
            _locations.Add(new Location("", getDefaultUser(), "", 0, false));
            _events.Add(new Event("", getDefaultUser(), getDefaulLocation(), DateTime.MinValue));
        }
    }
}
