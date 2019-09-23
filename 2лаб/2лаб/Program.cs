using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2лаб
{
    class Program
    {
        static void Main(string[] args)
        {
            //Знайти добуток (((-1)^k)*k))/(2*(k^3)+k+7)
            
            double sum = 1.0;

            for (int k = 0; k < 200; k++)
            {
                sum *= (Math.Pow(-1, k) * k + 8) / (2 * Math.Pow(k, 3) + k + 7);
            }

            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
