using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4lab_additional
{
    class Program
    {
        static void Main()
        {
            //23.	Даний масив розміру N. Перетворити його, вставивши після кожного додатного елементу нульовий елемент. 

            int n;
            do
            {
                Console.Write("Enter N: ");
                int.TryParse(Console.ReadLine(), out n);
                if (n <= 0)
                    Console.WriteLine("Error");
            } while (n <= 0);

            int[] arr = new int[n];
            int upZeroAmount = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Enter el{i + 1}: ");
                int.TryParse(Console.ReadLine(), out arr[i]);
                if (arr[i] > 0)
                    upZeroAmount++;
            }

            int[] newArr = new int[n + upZeroAmount];

            for (int i = 0, j = 0; i < arr.Length && j < newArr.Length; i++, j++)
            {
                newArr[j] = arr[i];
                if (newArr[j] > 0)
                    newArr[++j] = 0;
            }

            for (int i = 0; i < newArr.Length; i++)
            {
                Console.Write($" {newArr[i]} ");
            }

            Console.ReadKey();
        }
    }
}
