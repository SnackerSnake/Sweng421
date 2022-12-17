using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9.Models
{
    public class Espresso : CoffeeIF
    {
        
        public int CoffeeType => 3;
        double Price => 4.25;
        public List<CondimentIF> condiments = new List<CondimentIF>();

        //new code
        CondimentIF cream = new Cream();
        CondimentIF vanilla = new Vanilla();

        public Espresso()
        {

        }

        public void addCondiment(CondimentIF cdif)
        {
            condiments.Add(cdif);
        }

        public void run()
        {
            CMM cmm = new CMM();
            //make espresso coffee
            cmm.setCurrCoffee(new Espresso());
            //set coffee type
            cmm.setCoffeeType(CoffeeType.ToString());
            //display LED to indicate that the machine is running
            cmm.setLEDNumber(1);
            //grind coffee beans
            cmm.setGrindingTime(5);
            //heat up water
            cmm.setTemperature(200);

            cmm.addCondiment(cream);
            cmm.addCondiment(vanilla);

            //add condiment
            foreach (var condiment in condiments)
            {
                cmm.addCondiment(condiment);
            }

            //done
            cmm.done();

            //display LED to indicate that the machine is in idel state
            cmm.setLEDNumber(0);
            Console.WriteLine("Price is " + cmm.computePrice(this));
        }

        public double getPrice()
        {
            return this.Price;
        }
    }
}
