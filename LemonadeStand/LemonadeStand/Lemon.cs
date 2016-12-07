using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Lemon 
    {
        public double lemonsCost;
        public string itemName;
        public Lemon()
        {
            lemonsCost = 0.50D;
            itemName = "Lemon";
        }

        public double GetLemonCost()
        {
            return lemonsCost;
        }
    }
}
