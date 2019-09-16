using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3lab
{
    class Program
    {
        static private int[] Partitioning(int number)
        {
            int[] result = new int[3];

            result[2] = number % 10;
            result[1] = (number % 100 - result[2]) / 10;
            result[0] = (number - result[1] * 10 - result[0]) / 100;
                
            return result;
        }

        static void Main()
        {
            int number;
            do {
                Console.WriteLine("Enter three digit number: ");

                int.TryParse(Console.ReadLine(), out number);

                if (number > 999 || number < 100)
                    Console.WriteLine("You've entered wrong value!");

            } while (number > 999 || number < 100);

            int[] comparing = Partitioning(number);

            if (((comparing[0] > comparing[1]) && (comparing[1] > comparing[2]))||((comparing[0] < comparing[1]) && (comparing[1] < comparing[2])))
                Console.WriteLine("Makes");
            else
                Console.WriteLine("Does not make");

            Console.ReadKey();
        }
    }
}
