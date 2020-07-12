using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trinkanstalt.models
{
    class ListContainer
    {
        private static List<Person> people = new List<Person>();
        private static List<Food> food = new List<Food>();

        public static List<Person> getPeople(){
            return people;
        }
        public static void addPerson(Person p)
        {
            people.Add(p);
        }
        public static bool removePerson(Person p)
        {
            if (people.Remove(p))
            {
                return true;
            }
            return false;
        }
        public static int createPersonID()
        {
            return people.Count;
        }
        public static Person getDefaultPerson()
        {
            return people[0];
        }



        public static List<Food> getFood()
        {
            return food;
        }
        public static void addFood(Food f)
        {
            food.Add(f);
        }
        public static bool removeFood(Food f)
        {
            if (food.Remove(f))
            {
                return true;
            }
            return false;
        }
        public static int createFoodID()
        {
            return food.Count;
        }

        

        public ListContainer()
        {
            people.Add(new Person("", "", "Admin", DateTime.Today, Gender.unknown, RelationShipStatus.complicated, Status.admin ));
        }
    }
}
