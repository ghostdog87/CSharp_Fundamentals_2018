using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodStrings
{
    public class Box<T>
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

        public void Swap(int index1,int index2)
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
