using System;

namespace Solid_3
{
    // Порушено LSP (The Liskov Substitution Principle)

    interface IFigure
    {
        int GetArea();
    }

    class Rectangle : IFigure
    {
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public int Width { get; }
        public int Height { get; }
    
        public int GetArea()
        {
            return Width * Height;
        }
    }

//квадрат наслідується від прямокутника!!!
    class Square : IFigure
    {
        public Square(int side)
        {
            Side = side;
        }
        public int Side { get; }

        public int GetArea()
        {
            return Side * Side;
        }
    }

/*      Rectangle rect = new Square();
        rect.Width = 5;
        // base Width = 5
        // base Height = 5
        
        rect.Height = 10;
        // base Width = 10
        // base Height = 10

        Console.WriteLine(rect.GetRectangleArea());
        //Відповідь 100? Що не так???
        Console.ReadKey();
*/


    class Program
    {
        static void Main()
        {
            IFigure rect = new Rectangle(10, 5);
            IFigure square = new Square(5);
        
            Console.WriteLine($"The area of rectangle is {rect.GetArea()} and area of square is {square.GetArea()}");
            Console.ReadKey();
        }
    }
}