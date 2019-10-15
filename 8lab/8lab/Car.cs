namespace _8lab
{
    class Car
    {
        public string Name { get; set; }

        public int Year
        {
            get
            {
                return Year;
            }
            private set
            {
                if (value < 1879)
                    Year = value;

                else if (value > 2019)
                    Year = 2019;

                else
                    Year = value;
            }
        }

        public string Color { get; set; }

        public int Speed
        {
            get
            {
                return Speed;
            }
            private set
            {
                if (value <= 0)
                    Speed = 1;
                else
                    Speed = value;
            }
        }

        public Car(string name, int year, string color, int speed)
        {
            Name = name;
            Year = year;
            Color = color;
            Speed = speed;
        }
    }
}
