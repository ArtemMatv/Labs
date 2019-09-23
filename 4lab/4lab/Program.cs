using System;
using System.Collections.Generic;
using System.Linq;

namespace _4lab
{
    class Program
    {
        static void Main()
        {
            //14.Даний масив розміру N. Знайти максимальний з його локальних мінімумів. 

            int n;
            do
            {
                Console.Write("Enter N: ");
                int.TryParse(Console.ReadLine(), out n);
                if (n <= 0)
                    Console.WriteLine("Error");
            } while (n <= 0);

            int[] arr = new int[n];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Enter el{i + 1}: ");
                int.TryParse(Console.ReadLine(), out arr[i]);
            }
            if (n == 1)
            {
                Console.WriteLine(arr[0]);
            }
            else
            {

                List<int> mins = new List<int>();

                for (int i = 0; i < arr.Length; i++)
                {
                    if (i == 0)
                        if (arr[0] < arr[1])
                            mins.Add(arr[0]);
                        else
                            continue;
                    else if (i == arr.Length - 1)
                        if (arr[i] < arr[i - 1])
                            mins.Add(arr[i]);
                        else
                            continue;
                    else
                        if (arr[i - 1] > arr[i] && arr[i] < arr[i + 1])
                        mins.Add(arr[i]);
                }

                int maxFromMins = mins.Max();

                Console.WriteLine($"The biggest element from local mins: {maxFromMins}");
            }
            Console.ReadKey();

        }
    }
}
