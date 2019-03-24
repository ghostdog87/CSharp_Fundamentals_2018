using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08_CustomListSorter
{
    public class CustomList<T> : ICustomList<T> where T : IComparable<T>
    {
        private const int defaultArraySize = 4;
        public int Counter { get; private set; }

        public T[] ArrayList { get; private set; }
        

        public CustomList()
        {
            this.ArrayList = new T[defaultArraySize];
        }

        public void Add(T element)
        {
            if (this.Counter > this.ArrayList.Length - 1)
            {
                Resize();
            }
            this.ArrayList[this.Counter++] = element;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Counter; i++)
            {
                if (this.ArrayList[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public int CountGreaterThan(T element)
        {
            int count = 0;

            for (int i = 0; i < this.Counter; i++)
            {
                int result = this.ArrayList[i].CompareTo(element);
                if (result > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public T Max()
        {
            T max = this.ArrayList[0];
            for (int i = 1; i < this.Counter; i++)
            {
                int result = this.ArrayList[i].CompareTo(max);
                if (result > 0)
                {
                    max = this.ArrayList[i];
                }
            }
            return max;
        }

        public T Min()
        {
            T min = this.ArrayList[0];
            for (int i = 1; i < this.Counter; i++)
            {
                int result = this.ArrayList[i].CompareTo(min);
                if (result < 0)
                {
                    min = this.ArrayList[i];
                }
            }
            return min;
        }

        public T Remove(int index)
        {
            T removedElement = this.ArrayList[index];
            this.ArrayList[index] = default(T);
            this.Counter--;

            for (int i = index; i < this.Counter; i++)
            {
                this.ArrayList[i] = this.ArrayList[i + 1];
            }
            return removedElement;
        }

        public void Swap(int index1, int index2)
        {
            T tempElement = this.ArrayList[index1];
            this.ArrayList[index1] = this.ArrayList[index2];
            this.ArrayList[index2] = tempElement;
        }

        public void Sort()
        {
            while (true)
            {
                int count = 0;

                for (int i = 0; i < this.Counter - 1; i++)
                {
                    if (this.ArrayList[i].CompareTo(this.ArrayList[i + 1]) > 0)
                    {
                        count++;
                        T tempElement = this.ArrayList[i];
                        this.ArrayList[i] = this.ArrayList[i + 1];
                        this.ArrayList[i + 1] = tempElement;
                    }
                }
                if (count == 0)
                {
                    break;
                }
            }
        }

        private void Resize()
        {
            T[] tempArr = new T[this.ArrayList.Length * 2];
            for (int i = 0; i < this.ArrayList.Length; i++)
            {
                tempArr[i] = this.ArrayList[i];
            }
            this.ArrayList = tempArr;
        }

        public override string ToString()
        {
            return string.Join("\n", this.ArrayList.Take(this.Counter));
        }
       
    }
}
