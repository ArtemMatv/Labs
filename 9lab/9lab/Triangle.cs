using System;

namespace _9lab
{
    class Triangle : Shape
    {
        private double SideLength { get; }

        public Triangle(double sideLength)
        {
            SideLength = sideLength;

            Color = (ConsoleColor)(new System.Random().Next(0, 15));

            Names rn = (Names)(new System.Random().Next(1, 6));
            Name = rn.ToString();
        }

        public Triangle(string name, double sideLength)
        {
            Name = name;
            SideLength = sideLength;

            Color = (ConsoleColor)(new System.Random().Next(0, 15));
        }

        public Triangle(ConsoleColor color, string name, double sideLength)
        {
            Color = color;
            Name = name;
            SideLength = sideLength;
        }

        public override ConsoleColor Color { get; set; }

        public override int AmountOfVertexes => 3;

        public override string Name { get; }

        public override ShapeType Type => ShapeType.Triangle;

        public override double CalculatePerimetr()
        {
            return AmountOfVertexes * SideLength;
        }

        public override double CalculateSquare()
        {
            return (Math.Sqrt(3) / 4) * SideLength * SideLength;
        }

        public override void Draw()
        {
            Console.ForegroundColor = Color;

            Console.WriteLine($"Name: {Name}\n" +
                $"Scale: {SideLength}x{SideLength}x{SideLength}");

            Console.ResetColor();
        }
    }
}
