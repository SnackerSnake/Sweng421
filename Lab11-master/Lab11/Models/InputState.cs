using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11.Models
{
    public class InputState : CalculatorState
    {
        private CalculatorState parent;

        public InputState()
        {
            this.stateNum = (int)CalculatorStateEnum.Input;
        }

        public override void setState(Context c)
        {
            this.stateNum = (int)CalculatorStateEnum.Input;
            c.setState(this);
        }

        public override void nextState(Context c)
        {

        }
    }
}
