using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmStuff.Model
{
    public class Person
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public string Email { get; private set; }

        public Person(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
