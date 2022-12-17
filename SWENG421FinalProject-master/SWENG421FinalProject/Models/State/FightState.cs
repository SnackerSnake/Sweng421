using System;
using System.Collections.Generic;
using System.Text;

namespace SWENG421FinalProject.Models.State
{
    public class FightState : VideoGameState
    {
        public FightState()
        {
            this.stateNum = (int)VideoGameStateEnum.Fight;
        }

        public override void setState(Context c)
        {
            this.stateNum = (int)VideoGameStateEnum.Fight;
            c.setState(this);
        }

    }
}
