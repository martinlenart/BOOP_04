using System;

namespace BOOP_04_01
{
    class Program
    {
        public struct Point
        {
            public long X, Y;
        }
        public struct Rectangle
        {
            public Point BottomLeft, TopRight;

            //Instance Methods 
            //Normal syntax
            public long Width() { return Math.Abs(TopRight.X - BottomLeft.X); }

            // Expression bodied syntax
            public long Height() => Math.Abs(TopRight.Y - BottomLeft.Y);

            public void Print (bool printArea = false)
            {
                Console.WriteLine();
                Console.WriteLine($"Height: {Height(),10}");
                Console.WriteLine($"Width:  {Width(),10}");

                if (printArea)
                    Console.WriteLine($"Area:   {Width() * Height(),10}");
            }

            //Static Methods
            public static void Print(long width, long height, bool printArea = false)
            {
                Console.WriteLine();
                Console.WriteLine($"Height: {height,10}");
                Console.WriteLine($"Width:  {width,10}");

                if (printArea)
                    Console.WriteLine($"Area:   {width*height,10}");
            }
            public static long Area(long width, long height) => width * height;
            public static void GetACD(long width, long height,
                out long area, out long circumference, out double diagonal)
            {
                area = width * height;
                circumference = 2 * width + 2 * height;
                diagonal = Math.Sqrt(width * width + height + height);
            }

        }

        static void Main(string[] args)
        {
            Rectangle r1 = new Rectangle
            {
                BottomLeft = new Point { X = 0, Y = 0 },
                TopRight = new Point { X = 100, Y = 100 }
            };


            //Two ways of printing the rectangle
            r1.Print();
            Rectangle.Print(r1.Width(), r1.Height());
            Rectangle.Print(r1.Width(), r1.Height(), true);

            //The static Print must have width and height parameters
            //Using parameter position
            Rectangle.Print(200, 50, true);

            //Using parameter name
            Rectangle.Print(height:200, width:50);

            //Mixed position and name to clarity to a optional argument 
            Rectangle.Print(150, 75, printArea:true);

            //Get the diagonal
            Rectangle.GetACD(150, 75, out _, out _, out double diagonal);
            Console.WriteLine($"{diagonal:F2}");  // 150.50
        }
    }
}
