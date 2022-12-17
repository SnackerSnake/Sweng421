using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9.Models
{
    public class Chocolate : CondimentIF
    {
        double Price => 1;

        public double getPrice()
        {
            return this.Price;
        }

    }
}
