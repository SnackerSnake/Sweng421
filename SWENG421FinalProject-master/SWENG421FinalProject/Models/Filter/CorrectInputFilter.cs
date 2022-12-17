using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SWENG421FinalProject.Models.Filter
{
    public class CorrectInputFilter : AbsInputFilter
    {
        public override string GetInput(string input)
        {
            if (this.Validate(input))
            {
                return input;
            }
            else
            {
                return "-1";
            }
        }

        public override bool Validate(string input)
        {
            Regex regex = new Regex("^[0-9]+$"); //only numbers
            return !string.IsNullOrEmpty(input) && regex.IsMatch(input);
        }
    }
}
