﻿using System;
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
                int maxFromMins = int.MinValue;
               
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i == 0)
                        if (arr[0] < arr[1])
                            if (maxFromMins < arr[i])
                                maxFromMins = arr[i];
                            else
                                continue;
                        else
                            continue;
                    else if (i == arr.Length - 1)
                        if (arr[i] < arr[i - 1])
                            if (maxFromMins < arr[i])
                                maxFromMins = arr[i];
                            else
                                continue;
                        else
                            continue;
                    else
                        if (arr[i - 1] > arr[i] && arr[i] < arr[i + 1])
                        if (maxFromMins < arr[i])
                            maxFromMins = arr[i];
                        else
                            continue;
                }

                Console.WriteLine($"The biggest element from local mins: {maxFromMins}");
            }
            Console.ReadKey();

        }
    }
}
