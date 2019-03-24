using _01_Database;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace _01_DatabaseTest
{
    [TestFixture]
    public class DBTest
    {
        private const int ArrSize = 16;

        [Test]
        public void TestEmptyConstructor()
        {
            Database db = new Database();

            Type dbType = typeof(Database);

            var field = (int[])dbType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.Name == "numbers")
                .GetValue(db);
            int fieldLength = field.Length;

            Assert.AreEqual(fieldLength, ArrSize);
        }

        [Test]
        public void TestArrayBiggerThanCapacity()
        {

            Assert.Catch<InvalidOperationException>(() => new Database(new int[17]));
        }

        [Test]
        public void TestAddItemToFullArray()
        {

            Database db = new Database(new int[16]);

            Assert.Catch<InvalidOperationException>(() => db.Add(5));
        }

        [Test]
        public void TestAddItemToNoNFullArray()
        {

            Database db = new Database(new int[1]);
            db.Add(5);

            Type dbType = typeof(Database);

            var field = (int[])dbType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.Name == "numbers")
                .GetValue(db);
            int num = field[1];


            Assert.AreEqual(num, 5);
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

            Database db = new Database(new int[16]);
            const int initialIndex = 15;
            db.Remove();

            Type dbType = typeof(Database);

            var field = (int)dbType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.Name == "index")
                .GetValue(db);
            int fieldLength = field;

            Assert.AreEqual(fieldLength, initialIndex - 1);
        }

        [Test]
        public void TestFetchArray()
        {
            Database db = new Database(new int[] { 1,2,3});

            Assert.AreEqual(db.Fetch(), new int[] { 1, 2,3 });
        }
    }
}
