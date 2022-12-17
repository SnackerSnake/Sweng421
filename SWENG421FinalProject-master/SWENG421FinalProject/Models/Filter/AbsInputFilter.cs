using System;
using System.Collections.Generic;
using System.Text;

namespace SWENG421FinalProject.Models.Filter
{
    public abstract class AbsInputFilter : InputFilterIF
    {
        public abstract string GetInput(string input);
        public abstract bool Validate(string input);
    }
}
