using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Lemon : Item
    {
        public double lemonsCost;
       
        public Lemon()
        {
            lemonsCost = 0.40D;
            itemName = "Lemon";
        }

        
    }
}
