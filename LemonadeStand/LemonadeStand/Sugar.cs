using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Sugar : Item
    {
        
        public double sugarCost;
        
        public Sugar()
        {
            sugarCost = 0.30D;
            itemName = "Sugar";
        }
    }
}

