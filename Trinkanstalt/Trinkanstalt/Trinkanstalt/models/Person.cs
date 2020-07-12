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
    class Person
    {
        private Dictionary<Person, double> _owe = new Dictionary<Person, double>();
        public int PersonID { get; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }

        public DateTime Birthdate { get; set; }

        public Gender Gender { get; set; }
        public RelationShipStatus RelationShipStatus { get; set; }
        public Status Status { get; set; }

        public void addOwe(Person p, double price)
        {
            if (_owe.ContainsKey(p))
            {
                _owe[p] += price;
            }
            else
            {
                _owe.Add(p, price);
            }
        }
        public bool removeOwe(Person p, double price)
        {
            if (_owe.ContainsKey(p))
            {
                if ((_owe[p] - price) > 0)
                {
                    _owe[p] -= price;
                    return true;
                }
                if ((_owe[p] - price) == 0)
                {
                    _owe.Remove(p);
                    return true;
                }

            }
            return false;
        }
        public Dictionary<Person, double> getOwe()
        {
            return this._owe;
        }

        public static int GetAgeFromDate(DateTime birthday)
        {
            int years = DateTime.Now.Year - birthday.Year;
            birthday = birthday.AddYears(years);
            if (DateTime.Now.CompareTo(birthday) < 0) { years--; }
            return years;
        }



        public Person() : this("", "", "", DateTime.MinValue, Gender.unknown, RelationShipStatus.single, Status.user) { }
        public Person(string firstname, string lastname, string Nickname, DateTime BirthDate, Gender gender, RelationShipStatus relationShipStatus, Status status)
        {
            this.PersonID = ListContainer.createPersonID();
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
