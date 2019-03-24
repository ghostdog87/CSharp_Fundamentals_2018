using _02_ExtendedDatabase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _02_ExtendedDatabaseTest
{
    [TestFixture]
    public class DBTest
    {
        [Test]
        public void TestEmptyConstructor()
        {
            Database db = new Database();

            Type dbType = typeof(Database);

            var field = (List<Person>)dbType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.Name == "people")
                .GetValue(db);
            int fieldLength = field.Count;

            Assert.AreEqual(fieldLength, 0);
        }
      
        [Test]
        public void TestRemoveItemFromEmptyArray()
        {

            Database db = new Database();

            Assert.Catch<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void TestRemoveItemFromNoNEmptyArray()
        {

            Database db = new Database();
            db.Add(new Person()
            {
                Id = 5,
                Username = "pesho"
            });

            db.Add(new Person()
            {
                Id = 2,
                Username = "gosho"
            });

            db.Remove();

            Type dbType = typeof(Database);

            var field = (List<Person>)dbType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.Name == "people")
                .GetValue(db);
            string fieldLength = field[0].Username;

            Assert.AreEqual(fieldLength, "pesho");
        }

        [Test]
        public void TestFindByValidUsername()
        {
            Database db = new Database();

            db.Add(new Person()
            {
                Id = 5,
                Username = "pesho"
            });

            db.Add(new Person()
            {
                Id = 2,
                Username = "gosho"
            });

            db.Add(new Person()
            {
                Id = 3,
                Username = "sasho"
            });

            Assert.AreEqual(db.FindByUsername("gosho").Username, "gosho");
        }

        [Test]
        public void TestFindByInvalidUsername()
        {
            Database db = new Database();

            db.Add(new Person()
            {
                Id = 5,
                Username = "pesho"
            });

            db.Add(new Person()
            {
                Id = 2,
                Username = "gosho"
            });

            db.Add(new Person()
            {
                Id = 3,
                Username = "sasho"
            });

            Assert.Catch<ArgumentNullException>(() => db.FindByUsername(null));
        }


        [Test]
        public void TestFindByValidId()
        {
            Database db = new Database();

            db.Add(new Person()
            {
                Id = 5,
                Username = "pesho"
            });

            db.Add(new Person()
            {
                Id = 2,
                Username = "gosho"
            });

            db.Add(new Person()
            {
                Id = 3,
                Username = "sasho"
            });

            Assert.AreEqual(db.FindById(2).Id, 2);
        }

        [Test]
        public void TestFindByInvalidId()
        {
            Database db = new Database();

            db.Add(new Person()
            {
                Id = 5,
                Username = "pesho"
            });

            db.Add(new Person()
            {
                Id = 2,
                Username = "gosho"
            });

            db.Add(new Person()
            {
                Id = 3,
                Username = "sasho"
            });

            Assert.Catch<ArgumentNullException>(() => db.FindById(-1));
        }


        [Test]
        public void TestAddDuplicateUsername()
        {
            Database db = new Database();

            db.Add(new Person()
            {
                Id = 5,
                Username = "pesho"
            });

            db.Add(new Person()
            {
                Id = 2,
                Username = "gosho"
            });

           
            Assert.Catch<InvalidOperationException>(() => db.Add(new Person()
            {
                Id = 3,
                Username = "gosho"
            }));
        }

        [Test]
        public void TestAddDuplicateId()
        {
            Database db = new Database();

            db.Add(new Person()
            {
                Id = 5,
                Username = "pesho"
            });

            db.Add(new Person()
            {
                Id = 2,
                Username = "gosho"
            });


            Assert.Catch<InvalidOperationException>(() => db.Add(new Person()
            {
                Id = 2,
                Username = "shishi"
            }));
        }
    }
}
