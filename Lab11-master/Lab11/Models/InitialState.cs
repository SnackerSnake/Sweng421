using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11.Models
{
    public class InitialState : CalculatorState
    {
        private CalculatorState parent;

        public InitialState()
        {
            this.stateNum = (int)CalculatorStateEnum.Init;
        }

        public override void setState(Context c)
        {
            this.stateNum = (int)CalculatorStateEnum.Init;
            c.setState(this);
        }

        public override void nextState(Context c)
        {

        }
    }
}
