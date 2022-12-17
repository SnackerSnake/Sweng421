using Lab9.Models;
using System;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start brewing Mocha
            CoffeeIF mocha = new Mocha();
            CondimentIF cream = new Cream();
            CoffeeIF coffee1 = new CoffeeWrapper(mocha, cream);
            CondimentIF vanilla = new Vanilla();
            coffee1 = new CoffeeWrapper(coffee1, vanilla);
            coffee1.run();

            Console.WriteLine();

            //Start brewing Espresso
            CoffeeIF espresso = new Espresso();
            CondimentIF chocolate1 = new Chocolate();
            CoffeeIF coffee2 = new CoffeeWrapper(espresso, chocolate1);
            CondimentIF chocolate2 = new Chocolate();
            coffee2 = new CoffeeWrapper(coffee2, chocolate2);
            coffee2.run();



        }
    }
}
