using System;
using System.Collections.Generic;
using System.Text;
using static SWENG421FinalProject.Program;
using System.Diagnostics;

namespace SWENG421FinalProject.Models.State
{
    public class ChoiceState : VideoGameState
    {
        public int eventVariable = 0;

        //if true, the player enters combat. if false, the player says in ChoiceState
        public bool inCombat;

        public ChoiceState()
        {
            this.stateNum = (int)VideoGameStateEnum.Choice;
        }

        public override void setState(Context c)
        {
            this.stateNum = (int)VideoGameStateEnum.Choice;
            c.setState(this);
        }

        public void makeChoice()
        {
            switch (eventVariable)
            {
                case 0:
                    DoFirstBeginning();
                    break;
                case 1:
                    DoFirstBeginningA1();
                    break;
                case 2:
                    DoFirstBeginningB1();
                    break;
                case 3:
                    DoFirstBeginningC1();
                    break;
                case 4:
                    DoFirstBeginningABC1();
                    break;
                case 5:
                    DoFirstMiddleEventOne();
                    break;
                case 6:
                    DoFirstMiddleEventTwoA2();
                    break;
                case 7:
                    DoFirstMiddleEventThreeA3();
                    break;
                case 8:
                    DoFirstMiddleEventFourA4();
                    break;
                case 9:
                    DoFirstMiddleEventFiveA5();
                    break;
                case 10:
                    DoFirstMiddleEventTwoB2();
                    break;
                case 11:
                    DoFirstMiddleEventThreeB3();
                    break;
                case 12:
                    DoFirstMiddleEventFourB4();
                    break;
                case 13:
                    DoFirstMiddleEventFiveB5();
                    break;
                case 14:
                    DoFirstMiddleEventSixB6();
                    break;
                case 15:
                    DoFirstMiddleEventSevenB7();
                    break;
                case 16:
                    DoFirstMiddleEventEightB8();
                    break;
                case 17:
                    DoFirstMiddleEventNineB9();
                    break;
                case 18:
                    DoFirstMiddleEventTenB10();
                    break;
                case 19:
                    DoSecondMiddleEvent1();
                    break;
                case 20:
                    DoSecondMiddleEvent2();
                    break;
                case 21:
                    DoSecondMiddleEvent3();
                    break;
                case 22:
                    DoSecondMiddleEvent4();
                    break;
                case 23:
                    DoSecondMiddleEvent5();
                    break;
                case 24:
                    DoSecondMiddleEvent6();
                    break;
                case 25:
                    DoSecondMiddleEvent7();
                    break;
                case 26:
                    DoScavengerFirstEndingLose();
                    break;
                case 27:
                    DoScavengerSecondEndingVictory();
                    break;
                case 28:
                    DoScavengerThirdEndingVictory();
                    break;
                case 29:
                    DoSoldierEventOne();
                    break;
                case 30:
                    DoSoldierEventTwo();
                    break;
                case 31:
                    DoSoldierEventThree();
                    break;
                case 32:
                    DoSoldierEventFour();
                    break;
                case 33:
                    DoSoldierEventFive();
                    break;
                case 34:
                    DoSoldierEventSix();
                    break;
                case 35:
                    DoMayorBeginningEventOne();
                    break;
                case 36:
                    DoMayorBeginningEventTwo();
                    break;
                case 37:
                    DoMayorBeginningEventThree();
                    break;
                case 38:
                    DoMayorMiddleEventOne();
                    break;
                case 39:
                    DoMayorMiddleEventTwo();
                    break;
                case 40:
                    DoMayorMiddleEventThree();
                    break;
                case 41:
                    DoMayorMiddleEventFour();
                    break;
                case 42:
                    DoMayorEndingEventEventOne();
                    break;
                case 43:
                    DoMayorEndingEventEventTwo();
                    break;
                case 44:
                    DoMayorEndingEventEventThree();
                    break;
            }
        }
    }
}
                

    



