using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Game
    {
        public int numberOfDaysOpen;
        public int daysPassed;
        public  Player newPlayer;
        public GameMenu playerMenu;
        public Market mainMarket;
        public Day newDay;
        public Weather firstWeather;

        public List<Weather> weatherCombinations = new List<Weather>();
        public List<Player> playerList = new List<Player>();

        public Game()
        {
            newPlayer = new Player();
            mainMarket = new Market();
            playerMenu = new GameMenu();
            firstWeather = new Weather();
            
        }
        public void RunGame()
        {
            WelcomeToLemonadeStand();            
            MakeNewPlayer();
            ShowRules();
            GetDaysToPlay();
            //MakeWeatherForDaysOpen();
            while (newPlayer.playerPurse.playerMoney > 0 || numberOfDaysOpen - daysPassed > 0)
            {
                StartDay();
                ShowDayWeather();
                MainMenu();
                daysPassed++;
            }           
            Console.ReadLine();           
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
        public void ShowRules()
        {
            Console.WriteLine("Would you like to know the rules (Type Rules)? OR would you like to jump on in and get started (Type Start)?");
            string input = Console.ReadLine().ToLower();
            if (input == "rules")
            {
                GetRules();
            }
            else if (input == "start")
            {

            }
            else
            {
                ShowRules();
            }
        }
        public void GetRules()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine( "This is your classic Lemonade Stand..blah  blah.......explain rules.");
            Console.ResetColor();
        }      
        public void MakeNewPlayer()
        {        
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            newPlayer.SetName(name);
            playerList.Add(newPlayer);            
        }
        public void GetDaysToPlay()
        {
            Console.WriteLine("How many days would you like your Lemonade Stand open for? (Maximum of 21)");
            string daysOpen = Console.ReadLine();
            switch (daysOpen)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                case "11":
                case "12":
                case "13":
                case "14":
                case "15":
                case "16":
                case "17":
                case "18":
                case "19":
                case "20":
                case "21":
                    Console.WriteLine("Awesome, you will be playing for {0} day(s)!", daysOpen);
                    numberOfDaysOpen = Convert.ToInt16(daysOpen);
                    break;
                default:
                    Console.WriteLine("Please choose a number of days you would like to run your Lemonade Stand from 1-21");
                    GetDaysToPlay();
                    break;
            }
        }
        //public void MakeWeatherForDaysOpen()
        //{
        //    for (int i = 0; i < numberOfDaysOpen; i++)
        //    {
        //        Weather newWeather = new Weather();
        //        BreakToRandomizeWeather();
        //        weatherCombinations.Add(newWeather);                               
        //    }
        //}

        public void MainMenu()
        {
            string input = playerMenu.GetMainMenu();
            if (input == "v")
            {
                newPlayer.playerInventory.ShowInventory(newPlayer.playerPurse.playerMoney);
                MainMenu();
            }
            else if (input == "b")
            {
                GoToMarket();
                MainMenu();
            }
            else if (input == "d")
            {
                GetRules();
                Console.WriteLine();
                MainMenu();
            }
            else if(input == "w")
            {
                newDay.ShowForecast();

            }
            else if (input == "s")
            {
                newDay.RunDay();
            }
            else
            {
                Console.WriteLine("Not a valid input, please try again.");
                MainMenu();
            }              

        }
        public void ShowDayWeather()
        {
            
            Console.WriteLine("The Weather for tomorrow is {0}, {1} , and the temperature is {2} degrees.", firstWeather.cloudy, firstWeather.rainBool, firstWeather.temperature);

        }
        public void GoToMarket()
        {
            newPlayer.playerInventory.ChooseItemToPurchase(newPlayer.playerPurse);

        }
        public void StartDay()
        {
            Day newDay = new Day();
            
        }
       
        public void TwoSecondBreak()
        {            
            System.Threading.Thread.Sleep(2000);
        }
        public void BreakToRandomizeWeather()
        {
            System.Threading.Thread.Sleep(0030);
        }
    }
}
