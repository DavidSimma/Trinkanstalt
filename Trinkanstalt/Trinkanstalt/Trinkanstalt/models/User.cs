using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models
{
    public enum Gender
    {
        male,
        female,
        unknown
    }
    public enum RelationShipStatus
    {
        single,
        taken,
        complicated
    }
    public enum Status
    {
        admin,
        user,
        host,
        inferior
    }
    class User
    {

        private List<Location> _locations = new List<Location>();

        public Balance Balance { get; }

        public void addLocation(Location l)
        {
            if (!_locations.Contains(l))
            {
                this._locations.Add(l);
            }
        }
        public bool removeLocation(Location l)
        {
            if (_locations.Contains(l))
            {
                _locations.Remove(l);
                return true;
            }
            return false;
        }
        public List<Location> Locations { get { return this._locations; } }
        
        public int UserID { get; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }

        public DateTime Birthdate { get; set; }

        public Gender Gender { get; set; }
        public RelationShipStatus RelationShipStatus { get; set; }
        public Status Status { get; set; }
        public UserInventory Inventory { get; }

        

        public static int GetAgeFromDate(DateTime birthday)
        {
            int years = DateTime.Now.Year - birthday.Year;
            birthday = birthday.AddYears(years);
            if (DateTime.Now.CompareTo(birthday) < 0) { years--; }
            return years;
        }



        public User() : this("", "", "", DateTime.MinValue, Gender.unknown, RelationShipStatus.single, Status.user) { }
        public User(string firstname, string lastname, string Nickname, DateTime BirthDate, Gender gender, RelationShipStatus relationShipStatus, Status status)
        {
            this.UserID = Container.createUserID();
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Birthdate = Birthdate;
            this.Gender = gender;
            this.RelationShipStatus = relationShipStatus;
            this.Status = status;
        }

        public override string ToString()
        {
            return Firstname.ToString() + " " + Lastname.ToString() + " (" + Nickname.ToString() + ")" + "\n"
                + GetAgeFromDate(Birthdate).ToString() + " " + Gender.ToString() + "\n" +
                RelationShipStatus.ToString();

        }
    }
}
