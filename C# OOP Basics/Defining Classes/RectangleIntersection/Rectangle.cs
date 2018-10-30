using System;
using System.Collections.Generic;
using System.Text;

namespace RectangleIntersection
{
    public class Rectangle
    {
        //id, width, height and the coordinates of its top left corner (horizontal and vertical)

        private string id;
        private double width;
        private double height;
        private double x;
        private double y;

        public Rectangle(string id, double width, double height, double x, double y)
        {
            this.Id = id;
            this.Width = width;
            this.Height = height;
            this.X = x;
            this.Y = y;
        }


        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        internal bool IsIntersected(Rectangle secondRect)
        {
            if (this.x > secondRect.X + secondRect.Width || secondRect.X > this.x + this.width ||
                this.y > secondRect.Y + secondRect.Height || secondRect.Y > this.y + this.height)
            {
                return false;
            }
                
            return true;
        }
    }
}
