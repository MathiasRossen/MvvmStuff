using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmStuff.Model
{
    public class PersonRepository
    {
        List<Person> personCollection;

        public IReadOnlyCollection<Person> Persons
        {
            get { return personCollection.AsReadOnly(); }
        }

        public PersonRepository()
        {
            personCollection = new List<Person>();

            AddPerson("John", "Doe", "Someone@somewhere.com");
            AddPerson("Bob", "Doe", "Someoneelse@somewhere.com");
            AddPerson("Hans", "Dondon", "dondon@somewhere.com");
            AddPerson("Winston", "Whinycat", "winstonthefag@whinycat.com");
        }

        public void AddPerson(string firstName, string lastName, string email)
        {
            Person p = new Person(firstName, lastName, email);
            personCollection.Add(p);
        }

        public void RemovePerson(string email)
        {
            personCollection.RemoveAll(x => x.Email == email);
        }
    }
}
