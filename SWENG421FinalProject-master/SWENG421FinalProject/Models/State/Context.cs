using System;
using System.Collections.Generic;
using System.Text;

namespace SWENG421FinalProject.Models.State
{
    public class Context
    {
        private VideoGameState state { get; set; }

        public Context()
        {
            state = null;
        }

        public void setState(VideoGameState s)
        {
            this.state = s;
            this.state.stateNum = s.stateNum;
        }

        public VideoGameState getState()
        {
            return this.state;
        }
    }
}
