using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.Models
{
    public class Decision
    {
        public string DecisionStr { get; set; }

        public void doIt()
        {
            Console.WriteLine(this.DecisionStr);
        }

    }
}
