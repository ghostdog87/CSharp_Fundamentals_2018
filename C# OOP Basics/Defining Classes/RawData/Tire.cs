using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Tire
    {
        //<TireAge> <TirePressure> 
        private int tireAge;
        private double tirePressure;

        public Tire(int tireAge, double tirePressure)
        {
            TireAge = tireAge;
            TirePressure = tirePressure;
        }

        public double TirePressure
        {
            get { return tirePressure; }
            set { tirePressure = value; }
        }

        public int TireAge
        {
            get { return tireAge; }
            set { tireAge = value; }
        }


    }
}
