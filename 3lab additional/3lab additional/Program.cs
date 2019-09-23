using System;

namespace _3lab_additional
{
    class Program
    {
        static void Main()
        {
            //Варіант 17
            //Перевірити чи може тура зробити хід з початкової позиції в кінечну

            Console.WriteLine("Enter start pos: ");
            Console.Write("\tX: ");
            int.TryParse(Console.ReadLine(), out int startX);
            Console.Write("\tY: ");
            int.TryParse(Console.ReadLine(), out int startY);

            Console.WriteLine("Enter end pos: ");
            Console.Write("\tX: ");
            int.TryParse(Console.ReadLine(), out int endX);
            Console.Write("\tY: ");
            int.TryParse(Console.ReadLine(), out int endY);

            if (startX == endX || startY == endY)
                Console.WriteLine("It can move");
            else
                Console.WriteLine("It can not move");

            Console.ReadKey();
        }
    }
}
