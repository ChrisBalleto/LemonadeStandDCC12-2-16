using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
     public class Purse
    {
        public double playerMoney;
        public double totalProfit;
        public Purse()
        {
            playerMoney = 20.00D;
        }
        public bool CheckOverdraw(double numberofitems, double cost)
        {
            double totalCost = numberofitems * cost;
            if ((playerMoney - totalCost) < 0)
            {
                Console.WriteLine("\nYou do not have enough money to purchase that many {0}. Please choose a lower amount.", Item.itemName);           
                return  false;
            }
            else
            {
                return true;
            }
        }
        
        public void WithdrawMoney(double numberofitems, double cost, string name)
        {           
            double totalCost = numberofitems * cost;
            playerMoney -= totalCost;
            Console.WriteLine("\nYou purchased {0} {1}(s) at ${2:00.00} each for a total of ${3:00.00}. You have ${4:00.00} left", numberofitems, name, cost, totalCost, playerMoney);
        }
    }
}
