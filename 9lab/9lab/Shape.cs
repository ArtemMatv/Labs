using System;

namespace _9lab
{
    public enum ShapeType
    {
        Square,
        Circle,
        Triangle
    }

    public abstract class Shape : IDraw
    {
        public abstract ConsoleColor Color { get; set; }

        public abstract int AmountOfVertexes { get; }

        public abstract string Name { get; }

        public abstract ShapeType Type { get; }

        public abstract double CalculateSquare();

        public abstract double CalculatePerimetr();

        public abstract void Draw();
    }
}
