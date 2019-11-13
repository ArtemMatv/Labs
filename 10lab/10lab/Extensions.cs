using System;

namespace _10lab
{
    static public class Extensions
    {
        //First task
        static public void ShowReverse(this int number)
        {
            int num = number;
            while (number > 1)
            {
                Console.Write(num % 10);
                number = (int)(num / 10);
            }
        }

        static public void ShowReverse(this string str)
        {
            for (int i = str.Length - 1; i >= 0; i--)
                Console.Write(str[i]);
        }

        static public void ShowReverseStringMagic(this string magicString, char magicChar)
        {
            string[] str = magicString.Split(magicChar);

            for (int i = 0; i < str.Length; i++)
            {
                str[i].ShowReverse();
                if (i != str.Length - 1)
                    Console.Write(magicChar);
            }
        }

        static public void ShowReverseDouble(this double number)
        {
            number.ToString().ShowReverseStringMagic(',');
        }

        static public void ReverseIntArray(this int[] array)
        {
            int length = array.Length / 2 + array.Length % 2;

            for (int i = 0; i < length; i++)
            {
                int temp = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = temp;
            }
        }

        //Second task (variant 2)
        static public void SortByDecrease(this int[] array)
        {
            for (int repeat_counter = 0; repeat_counter < array.Length; repeat_counter++)
            {
                int temp;
                for (int element_counter = repeat_counter + 1; element_counter < array.Length; element_counter++)
                {
                    if (array[repeat_counter] < array[element_counter])
                    {
                        temp = array[repeat_counter];
                        array[repeat_counter] = array[element_counter];
                        array[element_counter] = temp;
                    }
                }
            }
        }
    }
}
