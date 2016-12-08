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
        
        public Player(string playerName)
        {
            playerPurse = new Purse(); 
            playerInventory = new Inventory();
        }
        //public string GetName(string name)
        //{
        //    return name;
                                         
        //}
    }
}
