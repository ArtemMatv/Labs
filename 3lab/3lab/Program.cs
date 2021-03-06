﻿using System;

namespace _3lab
{
    class Program
    {
        //14.	Перевірити істинність вислову: "Цифри даного тризначного числа утворюють зростаючу або спадаючу послідовність".

        static private bool Partitioning(int number)
        {
            string temp = number.ToString();

            int[] result = new int[temp.Length];

            for (int i = 0; i < result.Length; i++)
                result[i] = int.Parse(temp[temp.Length - 1 - i].ToString());

            //Convert.ToInt32(char) повертає символ ASCII
            //int.Parse(char) не існує
            //Тому використано int.Parse(char.ToString())

            int j = 0;
            while (j < result.Length - 1 && result[j] < result[j + 1])
                j++;

            if (j == result.Length - 1)
                return true;

            j = 0;
            while (j < result.Length - 1 && result[j] > result[j + 1])
                j++;

            if (j == result.Length - 1)
                return true;

            return false;
        }

        static void Main()
        {
            int number;
            do
            {
                Console.WriteLine("Enter three digit number: ");

                int.TryParse(Console.ReadLine(), out number);

                if (number > 999 || number < 100)
                    Console.WriteLine("You've entered wrong value!");

            } while (number > 999 || number < 100);
            
            if (Partitioning(number))
                Console.WriteLine("Makes");
            else
               Console.WriteLine("Does not make");

            Console.ReadKey();
        }
    }
}
