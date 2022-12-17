using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9.Models
{
    public class Mocha : CoffeeIF
    {
        public int CoffeeType => 1;
        double Price => 4;
        public List<CondimentIF> condiments = new List<CondimentIF>();

        public Mocha()
        {

        }

        public void addCondiment(CondimentIF cdif)
        {
            condiments.Add(cdif);
        }

        public void run()
        {
            CMM cmm = new CMM();
            //make mocha coffee
            cmm.setCurrCoffee(new Mocha());
            //set coffee type
            cmm.setCoffeeType(CoffeeType.ToString());
            //display LED to indicate that the machine is running
            cmm.setLEDNumber(1);
            //grind coffee beans
            cmm.setGrindingTime(8);
            //heat up water
            cmm.setTemperature(150);

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
