using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5.Models
{
    public class Subtract : ModuleIF
    {
        public double CurrentValue { get; set; }
        public double Compute(double input)
        {
            this.CurrentValue -= input;
            return this.CurrentValue;
        }
    }
}
