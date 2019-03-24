using CustomLinkedList;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class ListTests
    {
        [Test]
        public void TestInitializeOfEmptyList()
        {
            DynamicList<int> customList = new DynamicList<int>();

            Assert.That(customList.Count,Is.EqualTo(0));
        }

        [Test]
        public void TestListIndexingGetter()
        {
            DynamicList<int> customList = new DynamicList<int>();
            customList.Add(5);

            Assert.That(customList[0], Is.EqualTo(5));
        }

        [Test]
        public void TestListIndexingSetter()
        {
            DynamicList<int> customList = new DynamicList<int>();
            customList.Add(5);
            customList[0] = 13;

            Assert.That(customList[0], Is.EqualTo(13));
        }

        [Test]
        public void TestListNonExistingIndexGetter()
        {
            DynamicList<int> customList = new DynamicList<int>();
            customList.Add(5);
            customList[0] = 13;

            int value = 0;
            Assert.Catch<ArgumentOutOfRangeException>(() => value = customList[1]);
        }

        [Test]
        public void TestListNonExistingIndexSetter()
        {
            DynamicList<int> customList = new DynamicList<int>();
            customList.Add(5);
            customList[0] = 13;

            Assert.Catch<ArgumentOutOfRangeException>(() => customList[1] = 14);
        }

        [Test]
        public void TestAddingElementsInList()
        {
            DynamicList<int> customList = new DynamicList<int>();
            customList.Add(5);
            customList.Add(5);
            customList.Add(5);
            customList.Add(13);

            Assert.That(customList[3], Is.EqualTo(13));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(6)]
        public void TestRemovingElementInListInNonExistingIndex(int index)
        {
            DynamicList<int> customList = new DynamicList<int>();
            customList.Add(5);
            customList.Add(5);
            customList.Add(5);
            customList.Add(13);

            Assert.Catch<ArgumentOutOfRangeException>(() => customList.RemoveAt(index));
        }

        [Test]
        public void TestRemovingElementInList()
        {
            DynamicList<int> customList = new DynamicList<int>();
            customList.Add(5);
            customList.Add(5);
            customList.Add(5);
            customList.Add(13);
            customList.RemoveAt(2);

            Assert.That(customList[2], Is.EqualTo(13));
        }

        [Test]
        public void TestRemovingElementInListAndReturnsCorrectValue()
        {
            DynamicList<int> customList = new DynamicList<int>();
            customList.Add(5);
            customList.Add(5);
            customList.Add(5);
            customList.Add(13);
            int result = customList.RemoveAt(2);

            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void TestRemoveSpecifiedElementInTheList()
        {
            DynamicList<int> customList = new DynamicList<int>();
            customList.Add(5);
            customList.Add(5);
            customList.Add(5);
            customList.Add(13);
            int result = customList.Remove(5);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void TestRemoveSpecifiedNonExistingElementInTheList()
        {
            DynamicList<int> customList = new DynamicList<int>();
            customList.Add(5);
            customList.Add(5);
            customList.Add(5);
            customList.Add(13);
            int result = customList.Remove(3);

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void TestFindSpecifiedElementInTheListByItem()
        {
            DynamicList<int> customList = new DynamicList<int>();
            customList.Add(5);
            customList.Add(5);
            customList.Add(5);
            customList.Add(13);
            int result = customList.IndexOf(5);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void TestFindSpecifiedNonExistingElementInTheListByItem()
        {
            DynamicList<int> customList = new DynamicList<int>();
            customList.Add(5);
            customList.Add(5);
            customList.Add(5);
            customList.Add(13);
            int result = customList.IndexOf(3);

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void TestContainsSpecifiedElementInTheListByItem()
        {
            DynamicList<int> customList = new DynamicList<int>();
            customList.Add(5);
            customList.Add(5);
            customList.Add(5);
            customList.Add(13);
            bool result = customList.Contains(3);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void TestContainsSpecifiedNonExistingElementInTheListByItem()
        {
            DynamicList<int> customList = new DynamicList<int>();
            customList.Add(5);
            customList.Add(5);
            customList.Add(5);
            customList.Add(13);
            bool result = customList.Contains(5);

            Assert.That(result, Is.EqualTo(true));
        }
    }
}