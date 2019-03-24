using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_ExtendedDatabase
{
    public class Database
    {
        private List<Person> people;

        public Database()
        {
            this.people = new List<Person>();
        }

        public Database(List<Person> inputArr) : this()
        {
            for (int i = 0; i < inputArr.Count; i++)
            {
                this.people.Add(inputArr[i]);
            }
        }

        public void Add(Person value)
        {
            if (this.people.Any(x => x.Username == value.Username))
            {
                throw new InvalidOperationException("Array already contains user with that Username!");
            }

            if (this.people.Any(x => x.Id == value.Id))
            {
                throw new InvalidOperationException("Array already contains user with that Id!");
            }
            this.people.Add(value);
        }

        public void Remove()
        {
            if (this.people.Count == 0)
            {
                throw new InvalidOperationException("Array is empty!");
            }

            this.people[this.people.Count - 1] = null;
        }

        public Person FindByUsername(string username)
        {

            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null!");
            }

            if (!this.people.Any(x => x.Username == username))
            {
                throw new InvalidOperationException("Array does not contain user with that Username!");
            }

            return this.people.First(x => x.Username == username);
        }

        public Person FindById(long id)
        {

            if (id < 0)
            {
                throw new ArgumentNullException("ID cannot be negative!");
            }

            if (!this.people.Any(x => x.Id == id))
            {
                throw new InvalidOperationException("Array does not contain user with that Id!");
            }

            return this.people.First(x => x.Id == id);
        }
    }
}
