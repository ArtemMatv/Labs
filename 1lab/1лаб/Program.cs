﻿using System;

namespace _1лаб
{
    class Program
    {
        static void Main(string[] args)
        {
            //Знайти час, через який зустрінуться тіла, що рухаються на зустріч зі сталим прискоренням

            //Початкові швидкості
            Console.WriteLine("Enter movespeed: ");
            Console.Write("First object: ");
            double.TryParse(Console.ReadLine(), out double firstSpeed);
            Console.Write("Second object: ");
            double.TryParse(Console.ReadLine(), out double secondSpeed);

            //Прискорення
            Console.WriteLine("Enter acceleration: ");
            Console.Write("First object: ");
            double.TryParse(Console.ReadLine(), out double firstAcceleration);
            Console.Write("Second object: ");
            double.TryParse(Console.ReadLine(), out double secondAcceleration);

            //Відстань між тілами
            Console.WriteLine("Enter distance between objects: ");
            double.TryParse(Console.ReadLine(), out double distance);

            //Розрахунки
            double acceleration = firstAcceleration + secondAcceleration;
            double movespeed = firstSpeed + secondSpeed;

            double time = ((-movespeed + Math.Sqrt(Math.Pow(movespeed, 2) + 2 * acceleration * distance)) / acceleration);
            Console.WriteLine(time);
            Console.ReadKey();
        }
    }
}
