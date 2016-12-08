using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Inventory
    {
        public int numberOfPitchers;
        public Pitcher newPitcher;
        public List<Lemon> playerLemons;
        public List<Sugar> playerSugar;
        public List<Cup> playerCups;
        public List<Ice> playerIce;     
        public Inventory()
        {
            playerLemons = new List<Lemon>();
            playerSugar = new List<Sugar>();
            playerCups = new List<Cup>();
            playerIce = new List<Ice>();
        }
        public void ShowInventory(double money)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nYou currently have in your inventory...\nLemons: {0} \nSugar: {1} \nIce: {2} \nCups: {3} \nMoney: ${4:00.00} \nPitchers: {5}", playerLemons.Count, playerSugar.Count, playerIce.Count, playerCups.Count, money, numberOfPitchers );
            Console.ResetColor();
            ShowItemsNeededPerPitcher();
        }
        public void MakePitcher(Pitcher pitcher, Purse purse)
        {
            ShowInventory(purse.playerMoney);
            Console.WriteLine("\nHow many pitchers would you like to make?");
            string pitchers = Console.ReadLine();
            int pitchersToMake = Convert.ToInt16(pitchers);
            CreatePitchers(pitchersToMake);                      
        }
        public void ShowItemsNeededPerPitcher()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nEach Pitcher will need {0} Lemons, {1} Sugar, {2} Ice, and {3} Cups.", Pitcher.lemonsPerPitcher, Pitcher.sugarPerPitcher, Pitcher.icePerPitcher, Pitcher.cupsPerPitcher);
            Console.ResetColor();
        }
        public void CreatePitchers(int numberOfPitchersToMake)
        {
            if(!(numberOfPitchersToMake * Pitcher.lemonsPerPitcher <= playerLemons.Count))
            {
                Console.WriteLine("\nYou do not have enough Lemons to make this pitcher");
                return;
            }
            else if (!(numberOfPitchersToMake * Pitcher.icePerPitcher <= playerIce.Count))
            {
                Console.WriteLine("\nYou do not have enough Ice to make this pitcher");
                return;
            }
            else if (!(numberOfPitchersToMake * Pitcher.sugarPerPitcher <= playerSugar.Count))
            {
                Console.WriteLine("\nYou do not have enough Sugar to make this pitcher");
                return;
            }
            else if (!(numberOfPitchersToMake * Pitcher.cupsPerPitcher <= playerCups.Count))
            {
                Console.WriteLine("\nYou do not have enough Cups to make this pitcher");
                return;
            }
            else
            {
                RemoveLemons(numberOfPitchersToMake);
                RemoveIce(numberOfPitchersToMake);
                RemoveCups(numberOfPitchersToMake);
                RemoveSugar(numberOfPitchersToMake);
                for (int i = 0; i < numberOfPitchersToMake; i++)
                {
                    numberOfPitchers++;   
                    newPitcher = new Pitcher();             
                }
            }
             
        }
        
        public void RemoveLemons(int numberOfPitchers)
        {
            int removed = numberOfPitchers * Pitcher.lemonsPerPitcher;
            for(int i = 0; i < removed; i++)
            {
                playerLemons.RemoveAt(0);
            }
        }
        public void RemoveIce(int numberOfPitchers)
        {
            int removed = numberOfPitchers * Pitcher.icePerPitcher;
            for (int i = 0; i < removed; i++)
            {
                playerIce.RemoveAt(0);
            }
        }
        public void RemoveSugar(int numberOfPitchers)
        {
            int removed = numberOfPitchers * Pitcher.icePerPitcher;
            for (int i = 0; i < removed; i++)
            {
                playerSugar.RemoveAt(0);
            }
        }
        public void RemoveCups(int numberOfPitchers)
        {
            int removed = numberOfPitchers * Pitcher.icePerPitcher;
            for (int i = 0; i < removed; i++)
            {
                playerCups.RemoveAt(0);
            }
        }
        public void ChooseItemToPurchase(Purse purse)
        {
            Console.WriteLine("\nWhat would you like to purchase? (L)emons, (I)ce, (C)ups, (S)ugar, (R)eturn to MainMenu or Show in(V)entory");
            string userInput = Console.ReadLine().ToLower();
            if (userInput == "l")
            {
                BuyLemons(purse);
            }
            else if (userInput == "i")
            {
                BuyIce(purse);
            }
            else if (userInput == "c")
            {
                BuyCups(purse);
            }
            else if (userInput == "s")
            {
                BuySugar(purse);
            }
            else if (userInput == "v")
            {
                ShowInventory(purse.playerMoney);
            }
            else if (userInput == "r")
            {
                return;
            }
        }
        public void BuyLemons(Purse purse)
        {
            Lemon tempLemon = new Lemon();
            ShowInventory(purse.playerMoney);
            Console.WriteLine("\nHow many {1}s would you like to buy at {0:0.00} Each?", tempLemon.lemonsCost, Lemon.itemName);
            string items = Console.ReadLine();
            double itemsToPurchase = CheckForNumber(items);
            if (purse.CheckOverdraw(itemsToPurchase, tempLemon.lemonsCost))
            {
                for (int i = 0; i < itemsToPurchase; i++)
                {
                    Lemon newLemon = new Lemon();
                    playerLemons.Add(newLemon);                               
                }
                purse.WithdrawMoney(itemsToPurchase, tempLemon.lemonsCost, Lemon.itemName);
            }            
            ChooseItemToPurchase(purse);
        }
        public void BuyIce(Purse purse)
        {
            Ice tempIce = new Ice();
            ShowInventory(purse.playerMoney);
            Console.WriteLine("\nHow much {1} would you like to buy at {0:0.00} Each?", tempIce.iceCost, Ice.itemName);
            string items = Console.ReadLine();
            double itemsToPurchase = CheckForNumber(items);
            if (purse.CheckOverdraw(itemsToPurchase, tempIce.iceCost))
            {
                for (int i = 0; i < itemsToPurchase; i++)
                {
                    Ice newIce = new Ice();
                    playerIce.Add(newIce);
                }
                purse.WithdrawMoney(itemsToPurchase, tempIce.iceCost, Ice.itemName);
            }
            ChooseItemToPurchase(purse);
        }
        public void BuyCups(Purse purse)
        {
            Cup tempCup = new Cup();
            ShowInventory(purse.playerMoney);
            Console.WriteLine("\nHow many {1}s would you like to buy at {0:0.00} Each?", tempCup.cupCost, Cup.itemName);
            string items = Console.ReadLine();
            double itemsToPurchase = CheckForNumber(items);
            if (purse.CheckOverdraw(itemsToPurchase, tempCup.cupCost))
            {
                for (int i = 0; i < itemsToPurchase; i++)
                {
                    Cup newCup = new Cup();
                    playerCups.Add(newCup);
                }
                purse.WithdrawMoney(itemsToPurchase, tempCup.cupCost, Cup.itemName);
            }
            ChooseItemToPurchase(purse);
        }
        public void BuySugar(Purse purse)
        {
            Sugar tempSugar = new Sugar();
            ShowInventory(purse.playerMoney);
            Console.WriteLine("\nHow much {1} would you like to buy at {0:0.00} Each?", tempSugar.sugarCost, Sugar.itemName);
            string items = Console.ReadLine();
            double itemsToPurchase = CheckForNumber(items);
            if (purse.CheckOverdraw(itemsToPurchase, tempSugar.sugarCost))
            {
                for (int i = 0; i < itemsToPurchase; i++)
                {
                    Sugar newSugar = new Sugar();
                    playerSugar.Add(newSugar);
                }
                purse.WithdrawMoney(itemsToPurchase, tempSugar.sugarCost, Sugar.itemName);
            }           
            ChooseItemToPurchase(purse);
        }
        public void ResetPitcherCount()
        {
            numberOfPitchers = 0;
        }

        public double CheckForNumber(string items)
        {
            try
            {
                double input = Convert.ToDouble(items);
                return input;
            }
            catch
            {
                Console.WriteLine("\nPlease enter a valid number.");
                return 0;                
            }
        }
    }
}
