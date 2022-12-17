using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5.Models
{
    public interface ComputationIF
    {
        ModuleIF CreateModule(string moduleName);
        bool ValidateModule(string moduleName);
    }
}
