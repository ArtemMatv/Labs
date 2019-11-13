using System;

namespace _9lab
{
    class Circle : Shape
    {
        private double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;

            Color = (ConsoleColor)(new System.Random().Next(0, 15));

            Names rn = (Names)(new System.Random().Next(1, 6));
            Name = rn.ToString();
        }

        public Circle(string name, double radius)
        {
            Name = name;
            Radius = radius;

            Color = (ConsoleColor)(new System.Random().Next(0, 15));
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
