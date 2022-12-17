using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SWENG421FinalProject.Models.Filter
{
    public class SpaceRemoverFilter : AbsInputFilter
    {
        public override string GetInput(string input)
        {
            if (this.Validate(input))
            {
                return input;
            }
            else
            {
                input = input.Trim();
                RegexOptions options = RegexOptions.None;
                Regex regex = new Regex("[ ]{2,}", options);
                input = regex.Replace(input, " ");
                return input;
            }
        }

        public override bool Validate(string input)
        {
            Regex regex = new Regex(@"\s{2,}"); //has at least 2 whitespaces
            return !string.IsNullOrEmpty(input) && input.Trim().Length != 0 && !regex.IsMatch(input);
        }
    }
}
