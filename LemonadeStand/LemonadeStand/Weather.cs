using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Weather
    {
        public string cloudy;
        public bool isRaining;
        public int temperature;
        public string rainBool;
        public List<string> clouds = new List<string> { "Sunny", "Minimal Clouds", "Partly Cloudy", "Overcast" };
        Random random = new Random();

        public Weather()
        {
            GetWeather();
            
        }
        public void GetWeather()
        {
            cloudy = GetClouds();
            isRaining = GetRain();
            ConvertRainBool();
            temperature = GetTemperature();


            //Console.WriteLine("The Weather today is {0}, {1} , and the temperature is {2} degrees.", cloudy, , temperature);
        }

        public int GetTemperature()
        {
            Random random = new Random();
            int randomTemperature = random.Next(60, 120);
            return randomTemperature;
        }
        
        public bool GetRain()
        {            
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            if (randomNumber > 80)
            {
                return true;
            }
            else if (randomNumber <= 80)
            {
                return false;
            }
            return false;
        }
        public void ConvertRainBool()
        {
            if (isRaining == false)
            {
                rainBool = "no chance of rain";
            }
            else if (isRaining == true)
            {
                rainBool = "raining";
            }
        }

        public string GetClouds()
        {            
            string cloud = clouds[random.Next(0, 4)];
            return cloud;
        }

    }
}
//public void MakeWeatherForDaysOpen()   //Was in Game Class
//{
//    for (int i = 0; i < numberOfDaysOpen; i++)
//    {
//        Weather newWeather = new Weather();
//        BreakToRandomizeWeather();
//        weatherCombinations.Add(newWeather);                               
//    }
//}
