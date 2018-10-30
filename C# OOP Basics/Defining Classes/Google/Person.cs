using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Person
    {
        public string Name { get; set; }
        public Company Company { get; set; }
        public List<Pokemon> Pokemon { get; set; }
        public List<Parents> Parents { get; set; }
        public List<Children> Children { get; set; }
        public Car Car { get; set; }

        public Person(string name)
        {
            Name = name;
            Pokemon = new List<Pokemon>();
            Parents = new List<Parents>();
            Children = new List<Children>();
        }
    }
}
