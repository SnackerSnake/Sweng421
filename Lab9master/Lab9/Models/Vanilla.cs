using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9.Models
{
    public class Vanilla : CondimentIF
    {
        double Price => 0.5;

        public double getPrice()
        {
            return this.Price;
        }

    }
}
