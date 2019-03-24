using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class ListyIterator<T>
    {
        private List<T> list;

        public int Counter;

        public ListyIterator(params T[] listItems)
        {
            this.Counter = 0;
            this.list = new List<T>(listItems);
        }

        public bool Move()
        {
            if (this.Counter < this.list.Count - 1)
            {
                this.Counter++;
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (this.list.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            Console.WriteLine(this.list[this.Counter]);
        }

        public bool HasNext()
        {
            if (this.Counter < this.list.Count - 1)
            {
                return true;
            }

            return false;
        }
    }
}
