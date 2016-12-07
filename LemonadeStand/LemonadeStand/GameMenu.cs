using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class GameMenu
    {
        

        public string GetMainMenu()
        {
            Console.WriteLine("What Would you like to do? Show in(V)entory, (B)uy items, (D)isplay Rules, (S)tart Day?");
            string input = Console.ReadLine().ToLower(); 
            if (input == "v")
            {
                return "v";
            }
            else if (input == "b")  
            {
                return "b";
            }
            else if (input == "d")
            {
                return "d";
            }
            else if (input == "s")
            {
                return "s";
            }
            else
            {
                Console.WriteLine("Not a valid input, please try again.");
                GetMainMenu();
                return null;
            }
        }

    }
}
