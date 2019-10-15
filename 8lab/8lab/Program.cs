using System;

namespace _8lab
{
    class Program
    {
        static void Main()
        {
            Garage garage = new Garage();

            int action = 1;

            while (action > 0)
            {
                Console.WriteLine("Choose an action: ");
                Console.WriteLine("1 - buy a car");
                Console.WriteLine("2 - sell a car");
                Console.WriteLine("3 - take a car by name");
                Console.WriteLine("4 - take a car by year");
                Console.WriteLine("5 - take a car by color");
                Console.WriteLine("6 - take a car by speed");
                Console.WriteLine("7 - take a car by every property");
                Console.WriteLine("0 - close program");
                int.TryParse(Console.ReadLine(), out action);

                if (action == 1)
                {
                    Console.WriteLine("Enter data for a new car: ");

                    GetData(out string name, out int year, out string color, out int speed);

                    garage.BuyCar(new Car(name, year, color, speed));
                }
                else if (action == 2)
                {
                    Console.WriteLine("Enter data for a car to sell: ");

                    GetData(out string name, out int year, out string color, out int speed);

                    garage.SellCar(new Car(name, year, color, speed));
                }
                else if (action == 3)
                {
                    Console.Write("Enter name for car: ");
                    string name = Console.ReadLine();

                    garage.TakeByName(name);
                }
                else if (action == 4)
                {
                    Console.Write("Enter year for car: ");
                    int.TryParse(Console.ReadLine(), out int year);

                    garage.TakeByYear(year);
                }
                else if (action == 5)
                {
                    Console.Write("Enter color for car: ");
                    string color = Console.ReadLine();

                    garage.TakeByColor(color);
                }
                else if (action == 6)
                {
                    Console.Write("Enter speed for car: ");
                    int.TryParse(Console.ReadLine(), out int speed);

                    garage.TakeBySpeed(speed);
                }
                else if (action == 7)
                {
                    Console.WriteLine("Enter data for a car to find: ");

                    GetData(out string name, out int year, out string color, out int speed);

                    garage.TakeByEverything(name, year, color, speed);
                }
                else
                {
                    continue;
                }
            }
        }

        private static void GetData(out string name, out int year, out string color, out int speed)
        {
            Console.Write("Enter name for car: ");
            name = Console.ReadLine();

            Console.Write("Enter year for car: ");
            int.TryParse(Console.ReadLine(), out year);

            Console.Write("Enter color for car: ");
            color = Console.ReadLine();

            Console.Write("Enter speed for car: ");
            int.TryParse(Console.ReadLine(), out speed);
        }
    }
}
