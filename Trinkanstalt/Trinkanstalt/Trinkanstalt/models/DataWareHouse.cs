using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Xml.Serialization;
using Trinkanstalt.mainPages;
using Trinkanstalt.models.articles;
using Xamarin.Forms;

namespace Trinkanstalt.models
{
    class DataWareHouse
    {
        private static List<User> _people = new List<User>();
        private static List<Food> _food = new List<Food>();
        private static List<Location> _locations = new List<Location>();
        private static List<Event> _events = new List<Event>();
        private static List<FinishedMixture> _finishedMixtures = new List<FinishedMixture>();

        private static string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        public static string isLoggedInPath = Path.Combine(path, "loggedIn.txt");
        public static string usernamePath = Path.Combine(path, "username.txt");

        public static bool IsInitialized { get; set; } = false;

        public static void Initialize()
        {
            IsInitialized = true;
            _people.Add(new User("admin", "dev123", "", "", "", DateTime.Today, true, RelationShipStatus.complicated, Status.developer));

            _locations.Add(new Location("", DefaultUser, "", 0, false));
            _events.Add(new Event("", DefaultUser, DefaulLocation, DateTime.MinValue));
            IsLoggedIn = false;
        }

        
        
        public static List<User> User
        {
            get
            {
                return _people;
            }
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
        
        public static User DefaultUser
        {
            get
            {
                return _people[0];
            }
        }



        public static List<Food> Food
        {
            get
            {
                return _food;
            }
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


        public static List<Location> Locations
        {
            get
            {
                return _locations;
            }
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
        public static Location DefaulLocation
        {
            get
            {
                return _locations[0];
            }
        }


        public static List<Event> Events
        {
            get
            {
                return _events;
            }
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
        public static Event DefaulEvent
        {
            get
            {
                return _events[0];
            }
        }


        public static List<FinishedMixture> FinischedMixtures
        {
            get
            {
                return _finishedMixtures;
            }
        }
        public static void addFinischedMixtures(FinishedMixture fm)
        {
            _finishedMixtures.Add(fm);
        }
        public static bool removeFinischedMixtures(FinishedMixture fm)
        {
            if (_finishedMixtures.Remove(fm))
            {
                return true;
            }
            return false;
        }
        public static int createFinischedMixturesID()
        {
            return _finishedMixtures.Count;
        }

        public static bool IsLoggedIn{
            get 
            {
                using (var streamReader = new StreamReader(isLoggedInPath))
                {
                    string loggedIn = streamReader.ReadLine();
                    string username = streamReader.ReadLine();
                    string password = streamReader.ReadLine();

                    if (loggedIn == "true")
                    {
                        if (userExists(username, password))
                        {
                            Application.Current.MainPage = new SlideMenu();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        Application.Current.MainPage = new Login();
                        return false;
                    }
                }
            }
            set
            {
                if(value == false)
                { 
                    Application.Current.MainPage = new Login();
                   
                }
                else
                {
                    using (var streamWriter = new StreamWriter(isLoggedInPath, true))
                    {
                        streamWriter.WriteLine("true");
                        streamWriter.WriteLine(currentUser.UserName);
                        streamWriter.WriteLine(currentUser.UserPassword);

                    }
                    

                    Application.Current.MainPage = new SlideMenu();

                }
            }
        }

        public static User currentUser { get; set; }

        private static bool userExists (string username, string password){ 
            
                foreach (User u in User)
                {
                    System.Diagnostics.Debug.WriteLine(u.UserName);

                    if (u.UserName == username)
                    {
                        if(u.UserPassword == password)
                        {
                            currentUser = u;
                            return true;
                            
                        }
                        else
                        {
                            return false;
                        }
                        
                    }
                    else
                    {
                        return false;
                    }


                }
                return false;
        }
        
    }
}
