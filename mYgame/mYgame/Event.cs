using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mYgame
{
    public delegate void KeyPressed(string key);
    public class Handler
    {
        private int[] lengths;
        event KeyPressed myevent = null;

        public Handler(int amountOfPlayers)
        {
            myevent += ActuallyHandler;
            lengths = new int[amountOfPlayers];
        }

        //Костилі - наше все
        public void InvokeEvent()
        {
            while (true)
            {
                string s = Console.ReadKey().KeyChar.ToString();

                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write(" ");

                try
                {
                    if (Convert.ToInt32(s) > 0 && Convert.ToInt32(s) <= lengths.Length)
                        if (myevent != null)
                            myevent.Invoke(s);
                        else
                            return;
                    else
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                }
                catch (Exception)
                {
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    if (s == "e")
                    {
                        Console.WriteLine("Game over!");
                        return;
                    }

                    if (myevent == null)
                        return;
                }
                
            }
        }

        private void ActuallyHandler(string key)
        {
            int player = Convert.ToInt32(key) - 1;
            Console.SetCursorPosition(2 + lengths[player], player + 1);
            Console.Write("#");
            lengths[player]++;
            if (lengths[player] == 10)
            {
                Console.SetCursorPosition(0, 10 + player);
                Console.WriteLine("Player #" + (player+1) + " wins!");
                myevent -= ActuallyHandler;
            }
        }
    }
}
