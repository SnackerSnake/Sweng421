using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5.Models
{
    public class Computation : ComputationIF
    {
        public ModuleIF CreateModule(string moduleName)
        {
            Type t = Type.GetType("Lab5.Models." + moduleName);
            if(t != null)
            {
                Object o = Activator.CreateInstance(t);
                return (ModuleIF)o;
            }
            return (ModuleIF)new Initialize();
        }

        public bool ValidateModule(string moduleName)
        {
            Type t = Type.GetType("Lab5.Models." + moduleName);
            if(t != null)
            {
                return true;
            }
            return false;
        }
    }
}
