using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11.Models
{
    public class Context
    {
        private CalculatorState state { get; set; }

        public Context()
        {
            state = null;
        }

        public void setState(CalculatorState s)
        {
            this.state = s;
            this.state.stateNum = s.stateNum;
        }

        public CalculatorState getState()
        {
            return this.state;
        }
    }
}
