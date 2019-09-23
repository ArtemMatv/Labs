using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6lab
{
    class Program
    {
        //2 Варіант
        //Створити ліст cтрінгових змінних, дозволити можливість заповнення з клaвіатури.
        //Вивести індекси змінних рівних перевірочній(теж ввести з клавіатури). Скопіювати ліст в масив.
        static void Main()
        {
            List<string> list = new List<string>();

            string cont = "yes";

            while (cont == "yes")
            {
                Console.Write("Enter new element: ");
                list.Add(Console.ReadLine());
                Console.Write("Enter 'yes' if you want to continue entering or 'no' if you want to move on: ");
                cont = Console.ReadLine();
            }

            Console.Write("Enter value to check: ");
            string toCheck = Console.ReadLine();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == toCheck)
                    Console.WriteLine($"Element No{i} equels needed value");
            }

            string[] array = list.ToArray();

            Console.WriteLine("Array from the list: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }

            Console.ReadKey();
        }
    }
}
