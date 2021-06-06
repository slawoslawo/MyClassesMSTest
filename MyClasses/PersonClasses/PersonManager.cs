using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses.PersonClasses
{
    public class PersonManager
    {
        public Person CreatePerson(string first, string last, bool isSupervisor)
        {
            Person ret = null;
            if (!string.IsNullOrEmpty(first))
            {
                if (isSupervisor)
                {
                    ret = new Supervisor();
                }
                else
                {
                    ret = new Employee();
                }

                ret.FirstName = first;
                ret.LastName = last;
            }
            return ret;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();
            people.Add(new Person() { FirstName = "Paul", LastName = "Smith" });
            people.Add(new Person() { FirstName = "Tom", LastName = "Jones" });
            people.Add(new Person() { FirstName = "Mike", LastName = "Richardson" });

            return people;
        }

        public List<Person> GetSupervisors()
        {
            List<Person> people = new List<Person>();
            people.Add(CreatePerson("Tim", "Robbins", true));
            people.Add(CreatePerson("Jake", "Right", true));

            return people;
        }
        public List<Person> GetEmployees()
        {
            List<Person> people = new List<Person>();
            people.Add(CreatePerson("Steve", "Nystrom", false));
            people.Add(CreatePerson("John", "Kuhn", false));
            people.Add(CreatePerson("Jim", "Ruhl", false));

            return people;
        }
        public List<Person> GetSupervisorsAndEmployees()
        {
            List<Person> people = new List<Person>();
            people.AddRange(GetEmployees());
            people.AddRange(GetSupervisors());

            return people;
        }
    }
}
