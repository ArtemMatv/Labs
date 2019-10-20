namespace _8lab
{
    class Car
    {
        public string Name { get; set; }

        public int Year { get; private set; }

        public string Color { get; set; }

        public int Speed { get; private set; }

        public Car(string name, int year, string color, int speed)
        {
            Name = name;

            if (year < 1879)
                Year = 1879;
            else if (year > 2019)
                Year = 2019;
            else
                Year = year;

            Color = color;

            if (speed <= 0)
                Speed = 1;
            else
                Speed = speed;
        }
    }
}
