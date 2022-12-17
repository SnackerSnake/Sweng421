using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11.Models
{
    public class ResultState : CalculatorState
    {
        private CalculatorState parent;

        public ResultState()
        {
            this.stateNum = (int)CalculatorStateEnum.Result;
        }

        public override void setState(Context c)
        {
            this.stateNum = (int)CalculatorStateEnum.Result;
            c.setState(this);
        }

        public override void nextState(Context c)
        {

        }
    }
}
