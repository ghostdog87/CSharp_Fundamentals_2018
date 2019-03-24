using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodStrings
{
    public class Box<T> where T : IComparable<T>
    {
        public List<T> boxes;

        public Box()
        {
            this.boxes = new List<T>();
        }

        public void AddBox(T box)
        {
            boxes.Add(box);
        }

        public int GetBiggerThan(T other)
        {
            int counter = 0;
            foreach (T box in boxes)
            {
                int result = box.CompareTo(other);
                if (result > 0)
                {
                    counter++;
                }
            }
            return counter;
        }

        public void Swap(int index1, int index2)
        {
            T box = boxes[index1];
            boxes[index1] = boxes[index2];
            boxes[index2] = box;
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (var item in boxes)
            {
                result += $"{item.GetType().FullName}: {item}" + Environment.NewLine;
            }
            return result;
        }
    }
}
