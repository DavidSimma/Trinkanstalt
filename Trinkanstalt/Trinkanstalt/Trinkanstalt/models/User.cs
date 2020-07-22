using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models
{
    public enum RelationShipStatus
    {
        single,
        taken,
        complicated
    }
    public enum Status
    {
        developer,
        user,
        admin,
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
        private string _password;
        public int UserID { get; }
        public string UserName { get; set; }
        
        public string UserPassword
        {
            get
            {
                return this._password;
            }
            set
            {
                if (value.Length >= 4)
                {
                    this._password = value;
                }
            }
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }

        public DateTime Birthdate { get; set; }

        public bool IsMale { get; set; }
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



        public User() : this("", "", "", "", "", DateTime.MinValue, false, RelationShipStatus.single, Status.user) { }
        public User(string userName, string userPassword, string firstname, string lastname, string Nickname, DateTime BirthDate, bool isMale, RelationShipStatus relationShipStatus, Status status)
        {
            this.UserName = userName;
            this.UserPassword = userPassword;
            this.UserID = DataWareHouse.createUserID();
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Birthdate = Birthdate;
            this.IsMale = isMale;
            this.RelationShipStatus = relationShipStatus;
            this.Status = status;
        }

        public override string ToString()
        {
            return Firstname.ToString() + " " + Lastname.ToString() + " (" + Nickname.ToString() + ")" + "\n"
                + GetAgeFromDate(Birthdate).ToString() + " " + IsMale.ToString() + "\n" +
                RelationShipStatus.ToString();

        }
    }
}
