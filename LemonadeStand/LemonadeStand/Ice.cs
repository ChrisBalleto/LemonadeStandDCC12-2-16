using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Ice : Item
    {
        public double iceCost;
        
        
        public Ice()
        {
            iceCost = 0.05D;
            itemName = "Ice";
        }
    }
}
