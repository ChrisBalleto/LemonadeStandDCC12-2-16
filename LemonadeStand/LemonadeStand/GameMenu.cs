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
            Console.WriteLine("\nMAIN MENU -  Show in(V)entory, (B)uy items, (M)ake Pitchers, (D)isplay Rules, or (S)tart Day to get SELLING!");
            string input = Console.ReadLine().ToLower(); 
            if (input == "v")
            {
                return "v";
            }
            else if (input == "b")  
            {
                return "b";
            }
            else if (input == "m")
            {
                return "m";
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
                Console.WriteLine("\nNot a valid input, please try again.");
                GetMainMenu();
                return null;
            }
        }
        public void EndGame(Game game)
        {
            Console.WriteLine("You have either Run Out of Money or the Number of Days you wanted to play....Thanks for playing!\n");
            Console.WriteLine("If you would like to play again type <PLAY> or if you are done selling lemonade for now type <END>");
            string input = Console.ReadLine().ToLower();
            if (input == "play")
            {
                game.WelcomeToLemonadeStand();
            }
            else if(input == "end")
            {
                Environment.Exit(0);
            }
        }

    }
}
