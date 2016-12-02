using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Player
    {
        public string playerName;


        
        public void SetName()
        {            
            Console.WriteLine("Good Day, What is your name?");
            playerName = Console.ReadLine();                                   
        }
    }
}
