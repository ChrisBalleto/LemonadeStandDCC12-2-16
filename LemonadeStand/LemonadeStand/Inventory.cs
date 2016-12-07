using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Inventory
    {
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
            Console.WriteLine("You currently have in your inventory...  \n Lemons: {0} \n Sugar: {1} \n Ice: {2} \n Cups: {3} \n Money : ${4}", playerLemons.Count, playerSugar.Count, playerIce.Count, playerCups.Count, money );
        }
        public void ChooseItemToPurchase(Purse purse)
        {
            Console.WriteLine("What would you like to purchase? (L)emons, (I)ce, (C)ups, (S)ugar, (R)eturn to MainMenu or Show in(V)entory");
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
            else if (userInput == "i")
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
            Console.WriteLine("How many {1} would you like to buy at {0} Each?", tempLemon.lemonsCost, tempLemon.itemName);
            string items = Console.ReadLine();
            double itemsToPurchase = CheckForNumber(items);
            if (purse.CheckOverdraw(itemsToPurchase, tempLemon.lemonsCost))
            {
                for (int i = 0; i < itemsToPurchase; i++)
                {
                    Lemon newLemon = new Lemon();
                    playerLemons.Add(newLemon);                               
                }
                purse.WithdrawMoney(itemsToPurchase, tempLemon.lemonsCost, tempLemon.itemName);
            }
            ChooseItemToPurchase(purse);
        }
        public void BuyIce(Purse purse)
        {
            Ice tempIce = new Ice();
            Console.WriteLine("How much {1} would you like to buy at {0} Each?", tempIce.iceCost, tempIce.itemName);
            string items = Console.ReadLine();
            double itemsToPurchase = CheckForNumber(items);
            if (purse.CheckOverdraw(itemsToPurchase, tempIce.iceCost))
            {
                for (int i = 0; i < itemsToPurchase; i++)
                {
                    Ice newIce = new Ice();
                    playerIce.Add(newIce);
                }
                purse.WithdrawMoney(itemsToPurchase, tempIce.iceCost, tempIce.itemName);
            }
           ChooseItemToPurchase(purse);
        }
        public void BuyCups(Purse purse)
        {
            Cup tempCup = new Cup();
            Console.WriteLine("How many {1} would you like to buy at {0} Each?", tempCup.cupCost, tempCup.itemName);
            string items = Console.ReadLine();
            double itemsToPurchase = CheckForNumber(items);
            if (purse.CheckOverdraw(itemsToPurchase, tempCup.cupCost))
            {
                for (int i = 0; i < itemsToPurchase; i++)
                {
                    Cup newCup = new Cup();
                    playerCups.Add(newCup);
                }
                purse.WithdrawMoney(itemsToPurchase, tempCup.cupCost, tempCup.itemName);
            }
            ChooseItemToPurchase(purse);
        }
        public void BuySugar(Purse purse)
        {
            Sugar tempSugar = new Sugar();
            Console.WriteLine("How much {1} would you like to buy at {0} Each?", tempSugar.sugarCost, tempSugar.itemName);
            string items = Console.ReadLine();
            double itemsToPurchase = CheckForNumber(items);
            if (purse.CheckOverdraw(itemsToPurchase, tempSugar.sugarCost))
            {
                for (int i = 0; i < itemsToPurchase; i++)
                {
                    Sugar newSugar = new Sugar();
                    playerSugar.Add(newSugar);
                }
                purse.WithdrawMoney(itemsToPurchase, tempSugar.sugarCost, tempSugar.itemName);
            }
            ChooseItemToPurchase(purse);
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
                Console.WriteLine("Please enter a valid number.");
                return 0;                
            }
        }
    }
}
