using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Player
    {
        public Purse playerPurse;
        public Inventory playerInventory;
        public string playerName;
        public Lemon newLemon;

        public Player()
        {
            playerPurse = new Purse(); 
            playerInventory = new Inventory();
        }

        public void SetName(string name)
        {
            name = playerName;                                   
        }

        //public void BuyLemons()
        //{
        //    Console.WriteLine("How many Lemons would you like to buy at {0}?", newLemon.lemonsCost);
        //    double itemsToPurchase = double.Parse(Console.ReadLine());
        //    for (int i = 0; i < itemsToPurchase; i++)
        //    {
        //        Lemons newLemon = new Lemons();
        //        playerInventory.playerLemons.Add(newLemon);                
        //    }
        //        playerPurse.WithdrawMoney(itemsToPurchase, newLemon.lemonsCost);

        //}
        //public void BuyIce()
        //{

        //}
        //public void BuyCups()
        //{

        //}
        //public void BuySugar()
        //{

        //}


    }
}
