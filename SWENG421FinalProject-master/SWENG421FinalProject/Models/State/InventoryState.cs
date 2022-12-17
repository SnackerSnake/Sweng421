using System;
using System.Collections.Generic;
using System.Text;

namespace SWENG421FinalProject.Models.State
{
    public class InventoryState : VideoGameState
    {
        public InventoryState()
        {
            this.stateNum = (int)VideoGameStateEnum.Inventory;
        }

        public override void setState(Context c)
        {
            this.stateNum = (int)VideoGameStateEnum.Inventory;
            c.setState(this);
        }
    }
}
