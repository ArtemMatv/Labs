using System;
using System.Collections.Generic;

namespace _8lab
{
    class Garage
    {
        public List<Car> Cars { get; set; }

        private bool _showMessage;

        public Garage()
        {
            Cars = new List<Car>();
            _showMessage = true;
        }

        public void BuyCar(Car car)
        {
            if (car != null)
            {
                Cars.Add(car);
                Console.WriteLine("Bought!");
            }
        }

        public void SellCar(Car car)
        {
            if (Cars.Remove(car))
                Console.WriteLine("Sold!");
            else
                Console.WriteLine("There is not such a car!");
        }

        private void ShowCar(Car car)
        {
            if (_showMessage)
            {
                Console.WriteLine("Name\tYear\tColor\tSpeed");
                _showMessage = false;
            }

            Console.WriteLine(car.Name + "\t"
                + car.Year + "\t"
                + car.Color + "\t"
                + car.Speed + "\n");
        }

        public void TakeByName(string name)
        {
            int i = 0;
            foreach (Car car in Cars)
            {
                if (car.Name == name)
                {
                    ShowCar(car);
                    i++;
                }
            }
            if (i == 0)
                Console.WriteLine("No such cars");
            _showMessage = true;
        }

        public void TakeByYear(int year)
        {
            int i = 0;
            foreach (Car car in Cars)
            {
                if (car.Year == year)
                {
                    ShowCar(car);
                    i++;
                }
            }
            if (i == 0)
                Console.WriteLine("No such cars");
            _showMessage = true;
        }

        public void TakeByColor(string color)
        {
            int i = 0;
            foreach (Car car in Cars)
            {
                if (car.Color == color)
                {
                    ShowCar(car);
                    i++;
                }
            }
            if (i == 0)
                Console.WriteLine("No such cars");
            _showMessage = true;
        }

        public void TakeBySpeed(int speed)
        {
            int i = 0;
            foreach (Car car in Cars)
            {
                if (car.Speed == speed)
                {
                    ShowCar(car);
                    i++;
                }
            }
            if (i == 0)
                Console.WriteLine("No such cars");
            _showMessage = true;
        }

        public void TakeByEverything(string name, int year, string color, int speed)
        {
            int i = 0;
            foreach (Car car in Cars)
            {
                if (car.Name == name && car.Year == year && car.Color == color && car.Speed == speed)
                {
                    ShowCar(car);
                    i++;
                }
            }
            if (i == 0)
                Console.WriteLine("No such cars");
            _showMessage = true;
        }
    }
}
