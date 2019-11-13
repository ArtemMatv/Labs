using System;
using System.Collections.Generic;

namespace _9lab
{
    class Picture : IDraw
    {
        public List<Shape> Shapes;

        public int AmountOfObjects => Shapes.Count;

        public Picture()
        {
            Shapes = new List<Shape>();
        }

        public Shape this[int index]
        {
            get
            {
                if (index >= 0 && index < AmountOfObjects)
                    return Shapes[index];
                else
                {
                    Console.WriteLine("You've entered wrong index!");
                    return null;
                }
            }
        }

        public Picture(int length)
        {
            Shapes = new List<Shape>(length);
        }

        public void AddShape(Shape shape)
        {
            Shapes.Add(shape);
        }

        public void DeleteShape(string name)
        {
            foreach (Shape shape in Shapes)
            {
                if (shape.Name == name)
                    Shapes.Remove(shape);
            }
        }

        public void DeleteShape(ShapeType type)
        {
            foreach (Shape shape in Shapes)
            {
                if (shape.Type == type)
                    Shapes.Remove(shape);
            }
        }

        public void DeleteShape(double maxSquare)
        {
            foreach (Shape shape in Shapes)
            {
                if (shape.CalculateSquare() < maxSquare)
                    Shapes.Remove(shape);
            }
        }

        public void Draw()
        {
            foreach (Shape shape in Shapes)
            {
                shape.Draw();
            }
        }
    }
}
