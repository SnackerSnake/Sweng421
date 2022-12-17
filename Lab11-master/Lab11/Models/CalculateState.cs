using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11.Models
{
    public class CalculateState : CalculatorState
    {
        private CalculatorState parent;

        public CalculateState()
        {
            this.stateNum = (int)CalculatorStateEnum.Calc;
        }

        public override void setState(Context c)
        {
            this.stateNum = (int)CalculatorStateEnum.Calc;
            c.setState(this);
        }

        public override void nextState(Context c)
        {

        }
    }
}
