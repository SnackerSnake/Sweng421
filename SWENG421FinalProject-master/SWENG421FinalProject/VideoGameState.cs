using System;
using System.Collections.Generic;
using System.Text;

namespace SWENG421FinalProject.Models.State
{
    public enum VideoGameStateEnum
    {
        Choice = 1,
        Fight = 2,
        Inventory = 3
    }

    public abstract class VideoGameState
    {
        public int stateNum { get; set; }

        public abstract void setState(Context s);

    }
}
