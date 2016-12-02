using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Game
    {
        public Player newPlayer;
        public List<Player> playerList = new List<Player>();



        public void RunGame()
        {
            WelcomeToLemonadeStand();
            MakeNewPlayer();
            Weather testWeather = new Weather();
            TwoSecondBreak();
            Weather secondWeather = new Weather();

            
        }
        public void WelcomeToLemonadeStand()
        {
            Console.WriteLine("                                          When life give you Lemons...");
            Console.WriteLine();
            TwoSecondBreak();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                                           Build a Lemonade Stand!!");
            Console.ResetColor();
        }

        public void MakeNewPlayer()
        {        
            Player newPlayer = new Player();
            newPlayer.SetName();
            playerList.Add(newPlayer); 
        }
        public void GetTodaysWeather()
        {
            
        }

        public void TwoSecondBreak()
        {            
            System.Threading.Thread.Sleep(2000);
        }
    }
}
