using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double CalcSurfaceArea()
        {
            return (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }

        public double CalcLateralSurfaceArea()
        {
            return (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }

        public double CalcVolume()
        {
            return this.Length * this.Width * this.Height;
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    InputException("Height");
                }
                height = value;
            }
        }

        public double Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                {
                    InputException("Width");
                }
                width = value;
            }
        }

        public double Length
        {
            get { return length; }
            set
            {
                if (value <= 0)
                {
                    InputException("Length");
                }
                length = value;
            }
        }

        private void InputException(string argument)
        {
            throw new ArgumentException(argument + " cannot be zero or negative.");
        }
    }
}
