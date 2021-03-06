﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7lab
{
    class Program
    {
        static void ShowReverseNumber(int number)
        {
            while (number > 1)
            {
                Console.Write(number % 10);
                number = (int)(number / 10);
            }
        }

        static void ShowReverseString(string str)
        {
            for (int i = str.Length - 1; i >= 0; i--)
                Console.Write(str[i]);
        }

        static void ShowReverseDouble(double number)
        {
            ShowReverseStringMagic(number.ToString(), ',');
        }

        static void ShowReverseStringMagic(string magicString, char magicChar)
        {
            string[] str = magicString.Split(magicChar);

            for (int i = 0; i < str.Length; i++)
            {
                ShowReverseString(str[i]);
                if (i != str.Length - 1)
                    Console.Write(magicChar);
            }
        }

        static void ShowReverse(int number)
        {
            while (number > 1)
            {
                Console.Write(number % 10);
                number = (int)(number / 10);
            }
        }

        static void ShowReverse(double number)
        {
            ShowReverseStringMagic(number.ToString(), ',');
        }

        static void ShowReverse(string str)
        {
            for (int i = str.Length - 1; i >= 0; i--)
                Console.Write(str[i]);
        }

        static void ShowReverseRecursively(int number)
        {
            if (number >= 1)
            {
                Console.Write(number % 10);
                number /= 10;
                ShowReverseRecursively(number);
            }
        }

        static void ShowReverseRecursively(string str)
        {
            if (str != "")
            {
                Console.Write(str[str.Length - 1]);
                str = str.Remove(str.Length - 1);
                ShowReverseRecursively(str);
            }
        }

        static void ShowReverseRecursively(double number)
        {
            string[] str = number.ToString().Split(',');
            ShowReverseRecursively(str[0]);
            Console.Write(',');
            ShowReverseRecursively(str[1]);
        }

        static void ShowReverseRecursively(string magicString, char magicChar)
        {
            string[] str = magicString.Split(magicChar);
            for (int i = 0; i < str.Length; i++)
            {
                ShowReverseRecursively(str[i]);
                if (i != str.Length - 1)
                    Console.Write(magicChar);
            }
        }

        static int[] ReverseIntArray(int[] array)
        {
            int length = array.Length / 2 + array.Length % 2;

            for (int i = 0; i < length; i++)
            {
                int temp = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = temp;
            }

            return array;
        }

        static int[] ReverseIntArrayRef(int[] array)
        {
            int length = array.Length / 2 + array.Length % 2;

            for (int i = 0; i < length; i++)
            {
                SwapRef(ref array[i], ref array[array.Length - 1 - i]);
            }

            return array;
        }

        static void SwapRef(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

        static void Main()
        {
            
        }
    }
}
