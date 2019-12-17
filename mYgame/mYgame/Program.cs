using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mYgame
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter amount of players: ");
            int.TryParse(Console.ReadLine(), out int players);
            Handler handler = new Handler(players);

            for (int i = 1; i <= players; i++)
            {
                Console.WriteLine(i + "|          |");
            }
            Console.WriteLine(" S          F");
            Console.WriteLine(" T          I");
            Console.WriteLine(" A          N");
            Console.WriteLine(" R          I");
            Console.WriteLine(" T          S");
            Console.WriteLine(" |          H");

            handler.InvokeEvent();
        }
    }
}
