﻿using System;

namespace _9lab
{
    public class Square : Shape
    {
        private double SideLength { get; set; }

        public Square(string name)
        {
            SideLength = new Random().Next(0, 15);

            Color = (ConsoleColor)(new Random().Next(0, 15));

            Name = name;
        }

        public Square(string name, double sideLength)
        {
            Name = name;
            SideLength = sideLength;

            Color = (ConsoleColor)(new Random().Next(0, 15));
        }

        public Square(ConsoleColor color, string name, double sideLength)
        {
            Color = color;
            Name = name;
            SideLength = sideLength;
        }

        public override ConsoleColor Color { get; set; }

        public override int AmountOfVertexes => 4;

        public override string Name { get; }

        public override ShapeType Type => ShapeType.Square;

        public override double CalculatePerimetr()
        {
            return SideLength * AmountOfVertexes;
        }

        public override double CalculateSquare()
        {
            return SideLength * SideLength;
        }

        public override void Draw()
        {
            Console.ForegroundColor = Color;

            Console.WriteLine($"Name: {Name}\n" +
                $"Scale: {SideLength}x{SideLength}x{SideLength}x{SideLength}");

            Console.ResetColor();
        }
    }
}
