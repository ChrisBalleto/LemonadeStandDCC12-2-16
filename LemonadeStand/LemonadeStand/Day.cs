﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Day  

    {
        public double daysSales;
        public double moneySpent;
        public int potentialPatrons;
        List<Patron> dayPatrons = new List<Patron>();
        public Weather dayWeather;
        
        

        public Day()
        {
            dayWeather = new Weather();   
            GeneratePatrons();
            SetDaysSales();
        }   
        public void SetDaysSales()
        {
                foreach(Patron element in dayPatrons)
            { 
                if (element.willBuy == true)
                {
                    daysSales++;
                }
            }
        }
        public void ShowForecast()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nThe Weather for tomorrow is {0}, {1}, and the temperature is {2} degrees.", dayWeather.cloudy, dayWeather.rainBool, dayWeather.temperature);
            Console.ResetColor();
        }       
        public void GeneratePatrons()
        {
            SetPotentialPatrons();
            for (int i = 0; i < potentialPatrons; i++)
            {   Patron patron = new Patron();
                patron.SetPatronHeat(dayWeather);
                BreakToRandomizePatrons();
                patron.SetPatronThirst(dayWeather);
                patron.SetIfPatronWillBuy();                
                dayPatrons.Add(patron);
            }
        }
        public void SetPotentialPatrons()
        {
           if(dayWeather.cloudy == dayWeather.clouds[0])
            {
                potentialPatrons = 140;
            }
            else if (dayWeather.cloudy == dayWeather.clouds[1])
            {
                potentialPatrons = 120;
            }
            else if (dayWeather.cloudy == dayWeather.clouds[2])
            {
                potentialPatrons = 100;
            }
            else if (dayWeather.cloudy == dayWeather.clouds[3])
            {
                potentialPatrons = 80;
            }
        }

        
        public void BreakToRandomizePatrons()
        {
            System.Threading.Thread.Sleep(0010);
        }











    }
}
