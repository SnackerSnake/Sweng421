﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5.Models
{
    public interface ModuleIF
    {
        public double CurrentValue { get; set; }
        public double Compute(double input);
    }
}
