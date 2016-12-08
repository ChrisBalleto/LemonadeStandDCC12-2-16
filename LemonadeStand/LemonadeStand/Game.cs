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
        public double pitchersCupsQuotent;
        public Player newPlayer;
        public GameMenu playerMenu;
        public Market mainMarket;
        public Day newDay;
        public Weather firstWeather;

        public List<Weather> weatherCombinations = new List<Weather>();
        public List<Player> playerList = new List<Player>();

        public Game()
        {
            daysPassed = 1;
            mainMarket = new Market();
            playerMenu = new GameMenu();
            firstWeather = new Weather();
            
        }
        public void RunGame(Game game)
        {
            WelcomeToLemonadeStand();            
            MakeNewPlayer();
            ShowRules();
            GetDaysToPlay();           
            while (newPlayer.playerPurse.playerMoney > 0 || numberOfDaysOpen == daysPassed  )
            {
                CreateDay();
                newDay.ShowForecast();
                MainMenu();
                StartDay();
            }
            playerMenu.EndGame(game);                  
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
            Console.WriteLine("\nWould you like to know the rules (Type Rules)? OR would you like to jump on in and get started (Type Start)?");
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
            Console.WriteLine("\n In this Lemonade stand you will choose the number of days to play. \nThen you will buy ingredients and make your pitcher(s).\n Each day will have a different amount of potential customers that are dependant on \n the weather conditions and the price you set for your pitcher. \n The goal is to make as much profit as possible for as many days as you are playing....\n Good LUCK!");
            Console.ResetColor();
        }      
        public void MakeNewPlayer()
        {              
            Console.WriteLine("\nWhat is your name?");
            string name = Console.ReadLine();
            newPlayer = new Player(name);              
        }
        public void GetDaysToPlay()
        {
            Console.WriteLine("\nHello, How many days would you like your Lemonade Stand open for? (Maximum of 21)");
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
                    Console.WriteLine("\nAwesome, you will be playing for {0} day(s)!", daysOpen);
                    numberOfDaysOpen = Convert.ToInt16(daysOpen);
                    break;
                default:
                    Console.WriteLine("\nPlease choose a number of days you would like to run your Lemonade Stand from 1-21");
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
            }
            else if (input == "b")
            {
                GoToMarket();               
            }
            else if (input == "d")
            {
                GetRules();               
            }
            else if (input == "m")
            {
                newPlayer.playerInventory.MakePitcher(newPlayer.playerInventory.newPitcher, newPlayer.playerPurse);
            }
            else if(input == "w")
            {
                newDay.ShowForecast();
            }
            else if (input == "s")
            {
                return;
            }
            else
            {
                Console.WriteLine("\nNot a valid input, please try again.");               
            }
            newPlayer.playerInventory.ShowInventory(newPlayer.playerPurse.playerMoney);
            MainMenu();
        }
        public void ShowDayWeather()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nThe Weather for tomorrow is {0}, {1}, and the temperature is {2} degrees.", firstWeather.cloudy, firstWeather.rainBool, firstWeather.temperature);
            Console.ResetColor();
        }
        public void GoToMarket()
        {
            newPlayer.playerInventory.ChooseItemToPurchase(newPlayer.playerPurse);
        }
        public void CreateDay()
        {
            newDay = new Day();
            newPlayer.playerInventory.ResetPitcherCount();
        }
        public void StartDay()
        {
            Console.WriteLine("Potential Sales Today: {0}", newDay.daysSales);
            Console.WriteLine("\nHow much would you like to sell each cup for?");          
            double dailyCupCharge = Convert.ToDouble(Console.ReadLine());            
            SetSalesOnCupCharge(dailyCupCharge);
            double gain = GetDayProfit(dailyCupCharge);
            Console.WriteLine("\nHere we GO...!");
            TwoSecondBreak();
            Console.WriteLine("\nHum de Hum de Hum" );
            TwoSecondBreak();
            Console.WriteLine("\nSell, Sell, Sell!!!");
            TwoSecondBreak();
            Console.WriteLine("\nGlug, Glug, Glug!!!");
            TwoSecondBreak();
            Console.WriteLine("\nYou made ......");
            TwoSecondBreak();
            Console.WriteLine("\n${0}!!!!", gain);
            newPlayer.playerPurse.playerMoney += gain;           
            newPlayer.playerPurse.totalProfit += gain;
            Console.WriteLine("\nDay{0}", daysPassed);
            daysPassed++;
            Console.WriteLine("Total Sales: {0}", newDay.daysSales);
            Console.WriteLine("Total Profit: {0}", newPlayer.playerPurse.totalProfit);
            
            Console.WriteLine("\n \nDay{0}", daysPassed);
        }
        public double GetDayProfit(double charge)
        {
            pitchersCupsQuotent = newPlayer.playerInventory.numberOfPitchers * Pitcher.cupsPerPitcher;
            CheckMaxPossibleSales(pitchersCupsQuotent);
            double dayProfit = (newDay.daysSales * charge);                                  //(number of pitchers * Pitcher.Cups) 
            return dayProfit;
        }
        public void CheckMaxPossibleSales(double number)
        { 
            if(number < newDay.daysSales)
            {
                pitchersCupsQuotent = newDay.daysSales;
            }
        }
        public void SetSalesOnCupCharge(double charge)
        {
            if (charge >= 0.5 && charge < 1.00)
            {
                newDay.daysSales -= 10;
            }
            else if (charge >= 1.00 && charge < 1.75)
            {
                newDay.daysSales -= 20;
            }
            else if (charge >= 1.75) 
            {
                newDay.daysSales -= 30;
            }
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
