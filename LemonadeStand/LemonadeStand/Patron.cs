using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Patron
    {
        public bool willBuy;
        public bool isHot;
        public bool isThirsty;
        public Random random = new Random();
        


        public Patron()
        {
            isHot = false;
            isThirsty = true;
            willBuy = true;
        }
        public void SetPatronHeat(Weather weather)
        {
            if (weather.temperature >= 110)
            {
                isHot = true;
            }
            else if (weather.temperature >= 90 && weather.temperature < 110)
            {
                isHot = RollRandomEithtyTwenty();
            }
            else if (weather.temperature >= 60 && weather.temperature < 90)
            {
                isHot = RollRandomFiftyFifty();
            }
        }        
        public void SetPatronThirst(Weather weather)
        { 
            if (weather.isRaining == true)
            {
                isThirsty = RollRandomFiftyFifty();
            }
            else if(weather.isRaining == false)
            {
                isThirsty = RollRandomEithtyTwenty();
            }            
        }
        public void SetIfPatronWillBuy()
        {
            if (isThirsty == true && isHot == true)
            {
                willBuy = true;
            }
            else
            {
                willBuy = false;
            }
        }
        public bool RollRandomEithtyTwenty()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            if (randomNumber > 20)
            {
                return true;
            }
            else if (randomNumber <= 20)
            {
                return false;
            }
            return false;
        }
        public bool RollRandomFiftyFifty()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            if (randomNumber > 50)
            {
                return true;
            }
            else if (randomNumber <= 50)
            {
                return false;
            }
            return false;

        }





    }
}
