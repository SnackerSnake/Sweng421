using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11.Models
{
    public enum CalculatorStateEnum
    {
        Init = 1,
        Input = 2,
        Calc = 3,
        Result = 4
    }

    public abstract class CalculatorState
    {
        //protected InitialState initialState = IntitialState w;
        public int stateNum { get; set; }
        InitialState initialState { get; set; }
        InputState inputState { get; set; }
        CalculateState calculateState { get; set; }
        ResultState resultState { get; set; }

        public abstract void nextState(Context s);

        public abstract void setState(Context s);

    }
}
