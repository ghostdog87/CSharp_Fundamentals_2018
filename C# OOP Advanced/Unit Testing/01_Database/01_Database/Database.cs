using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_Database
{
    public class Database
    {
        private const int Capacity = 16;
        private int[] numbers;
        private int index;

        public Database()
        {
            this.numbers = new int[Capacity];
            this.index = -1;
        }

        public Database(int[] inputArr) : this()
        {
            if (inputArr.Length > Capacity)
            {
                throw new InvalidOperationException("Array is bigger than allowed capacity!");
            }

            for (int i = 0; i < inputArr.Length; i++)
            {
                this.index++;
                this.numbers[i] = inputArr[i];
            }
        }

        public void Add(int value)
        {
            if (this.index + 1 == Capacity)
            {
                throw new InvalidOperationException("Array is already full!");
            }

            this.index++;
            this.numbers[this.index] = value;
        }

        public void Remove()
        {
            if (this.index == -1)
            {
                throw new InvalidOperationException("Array is empty!");
            }
           
            this.numbers[this.index] = 0;
            this.index--;
        }

        public int[] Fetch()
        {
            return this.numbers.Take(this.index + 1).ToArray();
        }
    }
}
