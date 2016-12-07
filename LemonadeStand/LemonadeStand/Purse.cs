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
        public Purse()
        {
            playerMoney = 20.00D;
        }
        public bool CheckOverdraw(double numberofitems, double cost)
        {
            double totalCost = numberofitems * cost;
            if ((playerMoney - totalCost) <= 0)
            {
                Console.WriteLine("You do not have enough money to purchase that many items. Please choose a lower amount.");           
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
            Console.WriteLine("You purchased {0} {1}(s) at ${2:00.00} each for a total of ${3:00.00}.", numberofitems, name, cost, totalCost);           
        }
    }
}
