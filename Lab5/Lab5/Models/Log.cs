using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5.Models
{
    public class Log : ModuleIF
    {
        public double CurrentValue { get; set; }
        public double Compute(double input)
        {
            var result = Math.Log(this.CurrentValue, input);
            this.CurrentValue = result;
            return this.CurrentValue;
        }
    }
}
