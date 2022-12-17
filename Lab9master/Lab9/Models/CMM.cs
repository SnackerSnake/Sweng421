using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9.Models
{
    public class CMM
    {
        List<CoffeeIF> coffeeList = new List<CoffeeIF>();
        List<CondimentIF> condiments = new List<CondimentIF>();
        string coffeeType;
        CoffeeIF currCoffee { get; set; }

        public void setCurrCoffee(CoffeeIF coffee)
        {
            currCoffee = coffee;
        }

        public void setCoffeeType(string str)
        {
            this.coffeeType = str;
        }

        public void setGrindingTime(int secs)
        {
            Console.WriteLine("Grinding for " + secs + " seconds.");
        }

        public void addCondiment(CondimentIF type)
        {
            condiments.Add(type);
            Console.WriteLine("Adding condiment " + type.GetType().Name);
        }

        public void setTemperature(int degree)
        {
            Console.WriteLine("Temperature is set to " + degree + " degree F.");
        }

        public void setLEDNumber(int num)
        {
            Console.WriteLine(num + "" + coffeeType);
        }

        public double computePrice(CoffeeIF cif)
        {
            var price = cif.getPrice();
            foreach(var condiment in condiments)
            {
                price += condiment.getPrice();
            }
            return price;
        }

        public void done()
        {
            //need to add to coffee list
            coffeeList.Add(currCoffee);
            Console.WriteLine("Coffee is made.");
        }
    }
}
