using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5.Models
{
    public class Power : ModuleIF
    {
        public double CurrentValue { get; set; }
        public double Compute(double input)
        {
            var result = Math.Pow(this.CurrentValue, input);
            this.CurrentValue = result;
            return this.CurrentValue;
        }
    }
}
