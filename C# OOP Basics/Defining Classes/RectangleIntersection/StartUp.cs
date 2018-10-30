using System;
using System.Collections.Generic;

namespace RectangleIntersection
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int N = int.Parse(input[0]);
            int M = int.Parse(input[1]);

            List<Rectangle> rectangles = new List<Rectangle>();

            for (int i = 0; i < N; i++)
            {
                string[] inputOfRectangles = Console.ReadLine().Split();
                string id = inputOfRectangles[0];
                double width = double.Parse(inputOfRectangles[1]);
                double height = double.Parse(inputOfRectangles[2]);
                double x = double.Parse(inputOfRectangles[3]);
                double y = double.Parse(inputOfRectangles[4]);

                Rectangle rectangle = new Rectangle(id, width, height, x, y);
                rectangles.Add(rectangle);
            }

            for (int i = 0; i < M; i++)
            {
                string[] pairs = Console.ReadLine().Split();
                Rectangle firstRect = rectangles.Find(x => x.Id == pairs[0]);
                Rectangle secondRect = rectangles.Find(x => x.Id == pairs[1]);

                if (firstRect.IsIntersected(secondRect))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}
