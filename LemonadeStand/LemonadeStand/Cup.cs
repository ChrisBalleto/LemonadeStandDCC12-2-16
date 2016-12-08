using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Cup : Item
    {
        public double cupCost;
        
        public Cup()
        {
            cupCost = 0.10D;
            itemName = "Cup";
        }
    }
}
