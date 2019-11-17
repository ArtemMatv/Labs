using System;

namespace _9lab
{
    class Circle : Shape
    {
        private double Radius { get; set; }

        public Circle(string name)
        {
            Radius = new Random().Next(0, 15);

            Color = (ConsoleColor)(new Random().Next(0, 15));

            Name = name;
        }

        public Circle(string name, double radius)
        {
            Name = name;
            Radius = radius;

            Color = (ConsoleColor)(new Random().Next(0, 15));
        }

        public Circle(ConsoleColor color, string name, double radius)
        {
            Color = color;
            Name = name;
            Radius = radius;
        }
        public override ConsoleColor Color { get; set; }

        public override int AmountOfVertexes => 0;

        public override string Name { get; }

        public override ShapeType Type => ShapeType.Circle;

        public override double CalculatePerimetr()
        {
            return 2 * Math.PI * Radius; 
        }

        public override double CalculateSquare()
        {
            return Math.PI * Radius * Radius;
        }

        public override void Draw()
        {
            Console.ForegroundColor = Color;

            Console.WriteLine($"Name: {Name}\n" +
                $"Radius: {Radius}");

            Console.ResetColor();
        }
    }
}
