using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SWENG421FinalProject.Models.Filter
{
    public class SpecialCharacterRemoverFilter : AbsInputFilter
    {
        public override string GetInput(string input)
        {
            if (this.Validate(input))
            {
                return input;
            }
            else
            {
                //remove all special characters
                return Regex.Replace(input, "[^a-zA-Z0-9]+", "", RegexOptions.Compiled);
            }
        }

        public override bool Validate(string input)
        {
            return input.Any(s => !Char.IsLetterOrDigit(s));
        }
    }
}
