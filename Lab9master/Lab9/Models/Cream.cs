using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9.Models
{
    public class Cream : CondimentIF
    {
        double Price => 0.25;

        public double getPrice()
        {
            return this.Price;
        }

    }
}
