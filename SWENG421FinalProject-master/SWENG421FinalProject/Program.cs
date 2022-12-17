using SWENG421FinalProject.Models.Prototype;
using SWENG421FinalProject.Models.State;
using SWENG421FinalProject.Models.DynamicLinkage;
using System;
using System.Diagnostics;
using SWENG421FinalProject.Models.Filter;
using SWENG421FinalProject.Models.ReadWriteLock;
using System.Linq;

namespace SWENG421FinalProject
{
    class Program
    {
        static Context context = new Context();
        static ChoiceState choiceState = new ChoiceState();
        static FightState fightState = new FightState();
        static InventoryState inventoryState = new InventoryState();

        static ReadWriteLock LockManager = new ReadWriteLock();

        static Character scavenger = new Protagonist("Scavenger", 10, LockManager);
        static Character soldier = new Protagonist("Soldier", 20, LockManager);
        static Character mayor = new Protagonist("Mayor", 150, LockManager);
        static Character zombie = new Antagonist("Zombie", 5, LockManager);
        static Character zombie2;
        static Character zombie3;
        static Character bandit;
        static Character judgmentGang;

        static CharacterManager cm = new CharacterLoader();

        static AbstractLoadableItem absLoadableItem = new ConcreteLoadableItem();

        static AverageItem shovel = new Shovel();
        static AverageItem axe = new Axe();
        static AverageItem revolver = new Revolver();
        static AverageItem huntingRifle = new HuntingRifle();
        static AverageItem soda = new Soda();
        static AverageItem medKit = new MedKit();
        static AverageItem army;

        static InputFilterIF correctInput = new CorrectInputFilter();
        static InputFilterIF spaceRemover = new SpaceRemoverFilter();
        static InputFilterIF specialCharacterRemover = new SpecialCharacterRemoverFilter();

        static bool gameEnded = false;

        public static void Main(string[] args)
        {
            Init();
            while (!gameEnded)
            {
                //IMPORTANT FILTER COMMAND
                //input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(DoFirstBeginning())));
                
                if(context.getState().stateNum == (int)VideoGameStateEnum.Choice)
                {
                    if (choiceState.eventVariable == 0)
                    {
                        scavenger.ClearCharacter();
                        soldier.ClearCharacter();
                        mayor.ClearCharacter();
                    }
                    choiceState.makeChoice();
                }
            }
        }


        #region Story
        public static void DoFirstBeginning()
        {
            Console.Clear();

            Console.Write("The zombie apocalypse happened weeks ago. You are a scavenger for the Union of Survivors, a society with long metal sheet walls for territory to protect themselves from the zombie hordes and bandits. You are a simple female farmer with a 6 year old son. The Union of Survivors relies on people like you to farm food and gather supplies outside the walls. After a long day of farming, you decide to…");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Go to the Bar");
            Console.WriteLine("Choice 2: Go to the Church");
            Console.WriteLine("Choice 3: Go Home");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1" && input != "2" && input != "3")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 1;
            }
            else if (input == "2")
            {

                choiceState.eventVariable = 2;
            }
            else if (input == "3")
            {

                choiceState.eventVariable = 3;
            }
        }

        public static void DoFirstBeginningA1()
        {
            Console.Clear();
            Console.Write("You have a fun time at the bar. Hey, your son is sick. Go home.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Go Home");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 4;
            }
            Debug.WriteLine(choiceState.eventVariable);
            
        }

        public static void DoFirstBeginningABC1()
        {
            Console.Clear();
            Console.Write("The town doctor, Dr. Taub, greets as he exits your son’s room. He was one of the best doctors before the apocalypse.");
            Console.WriteLine("\n");
            Console.Write("Dr. Taub: Your son has Whipple’s Disease. Good news is, it’s treatable. Bad news, we do not have the right medicine to treat him. We would need a year’s or two worth of antibiotics to make sure that he survives. The Mayor has sent you on a scavenging mission to get the medicine. Normally, he would pick the location for you, but since it’s your son at stake, he is letting you choose. I will take care of him while you are outside the walls. Good hunting, scavenger.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Suburbs (Medium Risk, Medium Reward)");
            Console.WriteLine("Choice 2: Hospital (High Risk, High Reward)");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            while (input != "1" && input != "2")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }
            if (input == "1")
            {
                choiceState.eventVariable = 5;
            }
            else if (input == "2")
            {
                choiceState.eventVariable = 19;
            }
            Console.WriteLine("\n");

        }

        public static void DoFirstBeginningB1()
        {
            Console.Clear();
            Console.Write("You have a fun time at the church. Hey, your son is sick. Go home.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Go Home");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 4;
            }

        }

        public static void DoFirstBeginningC1()
        {
            Console.Clear();
            Console.Write("You have a fun time at the home. Hey, your son is sick. Go home. Wait, you are home! Go to his room.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Go to Room");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 4;
            }

        }

        public static void DoFirstMiddleA4()
        {
            Console.Clear();
            Console.Write("You enter the bedroom with a bunk bed and find a revolver. No medicine. As you exit to find rooms with medicine, the two bandits come upstairs. PREPARE FOR COMBAT!");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Fight!");

            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            //Context context = new Context();
            //context.setState(3);

            //change to combat state here

        }

        public static void DoFirstMiddleEventOne()
        {
            Console.Clear();
            Console.Write("You stand on top of a hill to see all of the suburb options. You have a map of the place from a scout who scouted the area. There are two houses with known medicine, the red house and blue house. The red house is being occupied by a couple of the Last Judgment Gang, hostile bandits. The blue house is filled with zombies. You only have enough time to search one house. ");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Red House");
            Console.WriteLine("Choice 2: Blue House");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            while (input != "1" && input != "2")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 6;
            }
            else if (input == "2")
            {
                choiceState.eventVariable = 10;
            }

            Console.WriteLine("\n");

        }

        public static void DoFirstMiddleEventTwoA2()
        {
            Console.Clear();
            Console.Write("There is a bandit guarding from the windows of the red house. There’s a back entrance, but he is patrolling watching the front and back entrance. You are unsure where the second bandit is. There are two ways to distract him. You can throw a rock at a window to attract zombies to attack the house’s entrance, or you can turn on a lawn mower to do the same thing.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Throw Rock");
            Console.WriteLine("Choice 2: Turn on lawn mower");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1" && input != "2")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 7;
            }
            else if (input == "2")
            {
                choiceState.eventVariable = 7;
            }

        }

        public static void DoFirstMiddleEventThreeA3()
        {
            Console.Clear();

            scavenger.AddItem(soda);
            scavenger.AddItem(soda);
            scavenger.AddItem(shovel);

            Console.Write("The bandit yells that the outpost is under attack, who calls his friend to come help him defend as she comes down the stairs. They shoot with their pistols at the zombies, which attracts more undead. While they’re distracted, you sneak behind the house. When you enter, you see a kitchen and stairs that go up. You search the kitchen and find a shovel and two sodas. Then you go up the stairs. There are two doors, one to the left and one to the right.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Left Door");
            Console.WriteLine("Choice 2: Right Door");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1" && input != "2")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 8;
            }
            else if (input == "2")
            {
                choiceState.eventVariable = 9;
            }

        }

        public static void DoFirstMiddleEventFourA4()
        {
            Console.Clear();

            scavenger.AddItem(revolver);

            Console.Write("You enter the bedroom with a bunk bed and find a revolver. No medicine. As you exit to find rooms with medicine, one of the bandits comes upstairs. PREPARE FOR COMBAT!");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: FIGHT!");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }
            if (input == "1")
            {
                choiceState.eventVariable = 9;
                context.setState(fightState);
            }
            DoCombatScavengerBandit();
            context.setState(choiceState);
        }

        public static void DoFirstMiddleEventFiveA5()
        {
            Console.Clear();

            Console.Write("You enter the bathroom on the left door and find a whole stash of medicine, including a bunch antibiotics! You came what you were looking for and decided to leave back to the settlement.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Return to Settlement");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 27;
            }

        }

        //case 10
        public static void DoFirstMiddleEventTwoB2()
        {
            Console.Clear();

            scavenger.AddItem(shovel);

            Console.Write("You go to the entrance of a blue house. You see a shovel, so you pick it up. When you sneak next to the front door and peek inside, there is a zombie standing to the right in the dining room. You also see a living room further ahead and stairs to your left. Behind the stairs, you think there’s a kitchen. You could attack the zombie or sneak behind the house.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Attack the zombie.");
            Console.WriteLine("Choice 2: Sneak behind the house.");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1" && input != "2")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 11;
            }
            else if (input == "2")
            {
                choiceState.eventVariable = 12;
            }
            context.setState(fightState);
            DoCombatScavengerZombie();
            context.setState(choiceState);

        }

        //case 11
        public static void DoFirstMiddleEventThreeB3()
        {
            Console.Clear();

            scavenger.AddItem(soda);
            scavenger.AddItem(soda);
            scavenger.AddItem(soda);
            scavenger.AddItem(soda);

            Console.Write("After you kill the zombie, you go further into the house. Inside the kitchen, there's a door to the laundry room, but after searching that, you find nothing. Searching the kitchen itself, you find four sodas. The rest of the first floor has nothing else useful. You go up the stairs, and there are three doors. There is a left and right door pretty close, and a third door far to the right.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Left Door");
            Console.WriteLine("Choice 2: Close Right Door");
            Console.WriteLine("Choice 3: Far Right Door");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1" && input != "2" && input != "3")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 13;
            }
            else if (input == "2")
            {

                choiceState.eventVariable = 17;
            }
            else if (input == "3")
            {

                choiceState.eventVariable = 15;
            }

        }

        //case 12
        public static void DoFirstMiddleEventFourB4()
        {
            Console.Clear();

            scavenger.AddItem(soda);
            scavenger.AddItem(soda);
            scavenger.AddItem(soda);
            scavenger.AddItem(soda);

            Console.Write("You go behind the house and enter a small laundry room. The door leads to the kitchen, and when you look at the other rooms, you notice the zombie shambling to the front door of the house. You decide to sneak attack the zombie from behind and BONK! As you go back to the kitchen, you loot four sodas. The rest of the first floor has nothing else useful.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Left Door");
            Console.WriteLine("Choice 2: Close Right Door");
            Console.WriteLine("Choice 3: Far Right Door");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1" && input != "2" && input != "3")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 13;
            }
            else if (input == "2")
            {

                choiceState.eventVariable = 17;
            }
            else if (input == "3")
            {

                choiceState.eventVariable = 15;
            }

        }

        //case 13
        public static void DoFirstMiddleEventFiveB5()
        {
            Console.Clear();

            scavenger.AddItem(soda);

            Console.Write("The left door was a bedroom with a soda. No zombies nor other things of note. You go back to the hallway.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Close Right Door");
            Console.WriteLine("Choice 2: Far Right Door");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1" && input != "2")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 17;
            }
            else if (input == "2")
            {

                choiceState.eventVariable = 14;
            }

        }

        //case 14
        public static void DoFirstMiddleEventSixB6()
        {
            Console.Clear();

            Console.Write("The far right door was a bedroom, but it was empty. No zombies nor other things of note. You go back to the hallway.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Close Right Door");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }
            if (input == "1")
            {
                choiceState.eventVariable = 17;
            }

        }

        //case 15
        public static void DoFirstMiddleEventSevenB7()
        {
            Console.Clear();

            Console.Write("The far right door was a bedroom, but it was empty. No zombies nor other things of note. You go back to the hallway.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Left Door");
            Console.WriteLine("Choice 2: Close Right Door");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1" && input != "2")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 16;
            }
            else if (input == "2")
            {

                choiceState.eventVariable = 17;
            }

        }

        //case 16
        public static void DoFirstMiddleEventEightB8()
        {
            Console.Clear();

            scavenger.AddItem(soda);

            Console.Write("The left door was a bedroom with a soda. No zombies nor other things of note. You go back to the hallway.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Close Right Door");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 17;
            }

        }


        //case 17
        public static void DoFirstMiddleEventNineB9()
        {
            Console.Clear();

            Console.Write("You enter a bathroom. There is a dead body sitting on the floor. You whack it with the shovel to be sure. The body seems to have doctor’s clothes, and you open a medical duffle bag. It has a bunch of pill bottles, and you find a bunch of antibiotics! You got what you were looking for and decided to head back to the settlement. On your way back on the road, you notice a human survivor resting next to the car. He looks alive but tired and injured.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Help the injured survivor.");
            Console.WriteLine("Choice 2: Keep moving on to the settlement.");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1" && input != "2")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 18;
            }
            else if (input == "2")
            {

                choiceState.eventVariable = 27;
            }

        }

        //case 18
        public static void DoFirstMiddleEventTenB10()
        {
            Console.Clear();

            Console.Write("You go to the injured survivor, and he does not seem to notice you. As you inspect him, there were no bite marks nor claw marks, so he probably does not have the zombie infection. You notice some cuts from a blade though. You help the injured survivor by applying some spare rags, sterilizing the wounds from the medical duffle bag, and giving him some painkillers. Before you leave, the survivor says:");
            Console.WriteLine("\n");
            Console.Write("Survivor: Thank you");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Go to the settlement.");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {

                choiceState.eventVariable = 27;
            }

        }

        //case 19
        public static void DoSecondMiddleEvent1()
        {
            Console.Clear();

            scavenger.AddItem(axe);

            Console.Write("You stand behind a car to view the entrance of the hospital. You find a sitting corpse holding an axe. You take the axe and add it to your inventory. There are many zombies shambling around outside, so you have to sneak your way to the hospital. There is the back entrance and the front entrance. They both look equally risky; which do you take?");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Front Entrance");
            Console.WriteLine("Choice 2: Back Entrance");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1" && input != "2")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 20;
            }
            else if (input == "2")
            {

                choiceState.eventVariable = 20;
            }

        }

        //case 20
        public static void DoSecondMiddleEvent2()
        {
            Console.Clear();

            Console.Write("As you enter the hospital, a zombie comes out of a medical room. You are forced to fight it!");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Fight zombie");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 21;
            }

            context.setState(fightState);
            DoCombatScavengerZombie();
            context.setState(choiceState);

        }

        //case 21
        public static void DoSecondMiddleEvent3()
        {
            Console.Clear();

            Console.Write("After fighting the zombie, multiple come from behind where you entered, so you start running further into the hospital. Eventually, you find a security guard room and close the door behind you. The room is cleared of zombies. For notable loot, you see two gun safes. Hearing the zombies coming for you, you only have time to picklock one. Which gun lock do you choose?");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Left Gun Safe");
            Console.WriteLine("Choice 2: Right Gun Safe");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1" && input != "2")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 22;
            }
            else if (input == "2")
            {

                choiceState.eventVariable = 23;
            }

        }

        //case 22
        public static void DoSecondMiddleEvent4()
        {
            Console.Clear();

            scavenger.AddItem(huntingRifle);

            Console.Write("You unlock the left gun safe and find a hunting rifle. A zombie breaks down the door. Prepare to fight a zombie!");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Fight!");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 24;
            }

            context.setState(fightState);
            DoCombatScavengerZombie();
            context.setState(choiceState);

        }

        //case 23
        public static void DoSecondMiddleEvent5()
        {
            Console.Clear();

            scavenger.AddItem(revolver);

            Console.Write("You unlock the right gun safe and find a revolver. A zombie breaks down the door. Prepare to fight a zombie!");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Fight!");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 24;
            }

            context.setState(fightState);
            DoCombatScavengerZombie();
            context.setState(choiceState);

        }

        //case 24
        public static void DoSecondMiddleEvent6()
        {
            Console.Clear();

            scavenger.AddItem(medKit);
            scavenger.AddItem(medKit);

            Console.Write("After fighting the zombies, you push on in the hospital and eventually find the pharmacy. As you are being chased by a bunch of zombies, you enter the pharmacy and close the door behind you. You quickly search the room, and find two medkits. You also find a safe labeled ‘antibiotics’. To pick the safe’s lock, do you force the lock or carefully pick it?");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Force Lock");
            Console.WriteLine("Choice 2: Carefully Pick Lock");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1" && input != "2")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 25;
            }
            else if (input == "2")
            {

                choiceState.eventVariable = 25;
            }

        }

        //case 25
        public static void DoSecondMiddleEvent7()
        {
            Console.Clear();

            Console.Write("You pick the lock successfully and grab the large bag of antibiotics. The zombies have the door half open. For some reason, the pharmacy’s window has stairs outside that go downwards like a city as an emergency exit. You break the glass and go down the stairs. You run through the horde of zombies and leave the hospital area. You lose the zombies in a chase and make your way back to the settlement.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Go to the settlement.");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 28;
            }

        }

        //case 26
        public static void DoScavengerFirstEndingLose()
        {
            Console.Clear();

            Console.Write("You have died. Your mission failed, and your son’s fate is unknown.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Restart");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 0;
            }

        }

        //case 27
        public static void DoScavengerSecondEndingVictory()
        {
            Console.Clear();

            Console.Write("After arriving from the suburban house area, you successfully find a years worth of antibiotics to save your son! You win!");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Play as Character 2");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 29;
            }

        }

        //case 28
        public static void DoScavengerThirdEndingVictory()
        {
            Console.Clear();

            Console.Write("After arriving from the hospital, you successfully find two years worth of antibiotics to save your son! You win!");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Play as Character 2");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 29;
            }

        }

        //case 29
        public static void DoSoldierEventOne()
        {
            soldier.AddItems(scavenger.GetItems());
            soldier.SetCurrentItem(scavenger.GetCurrentItem());

            Console.Clear();

            Console.Write("You are the son of the Scavenger. You are known as the Soldier. You are asked to fight zombies outside the walls near the settlement to ensure that defending the Union Survivors from the inside is easier and to make traveling in and out safer. You start with near the gate entrance.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Fight zombie.");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 30;
            }

            context.setState(fightState);
            DoCombatSoldierZombie();
            context.setState(choiceState);

        }

        //case 30
        public static void DoSoldierEventTwo()
        {
            Console.Clear();

            Console.Write("You move on to fight a zombie outside a Game Stop.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Fight zombie.");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 31;
            }
            context.setState(fightState);
            DoCombatSoldierZombie();
            context.setState(choiceState);

        }

        //case 31
        public static void DoSoldierEventThree()
        {
            Console.Clear();

            Console.Write("You move on to fight a zombie outside a Barnes & Nobles.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Fight zombie.");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 32;
            }
            context.setState(fightState);
            DoCombatSoldierZombie();
            context.setState(choiceState);

        }

        //case 32
        public static void DoSoldierEventFour()
        {
            Console.Clear();

            Console.Write("You move on to fight a zombie outside a McDonalds.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Fight zombie.");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 33;
            }
            context.setState(fightState);
            DoCombatSoldierZombie();
            context.setState(choiceState);

        }

        //case 33
        public static void DoSoldierEventFive()
        {
            Console.Clear();

            Console.Write("You cleared the outside of the Union of Survivors’ settlement, and you are regarded as one of the settlement’s best soldiers.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: You win! Play as Character 3.");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 35;
            }

        }

        //case 34
        public static void DoSoldierEventSix()
        {
            Console.Clear();

            Console.Write("You died and lost.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Restart");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 0;
            }

        }

        //case 35
        public static void DoMayorBeginningEventOne()
        {
            //Mayor Setup
            mayor.SetCurrentItem(army);

            Console.Clear();

            Console.Write("You are the son of The Soldier. You are elected mayor of the settlement for the Union of Survivors. The settlement is ruled by a democracy where everyone has a say in settlement policy. However, the major decisions are made by you. For your first decision, there are two groups of people wanting different things to be done with the town builders’ time. The scientists want to build a new library to make it easier to learn for themselves, those interested in science, and the children. On the other hand, a group of priests want a new church to pray, arrange marriages, and host social gatherings. Eventually, the settlement might make both some day, but the builders only have time and resources for one currently.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Build a new library.");
            Console.WriteLine("Choice 2: Build a new church.");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1" && input != "2")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 36;
            }
            else if (input == "2")
            {
                choiceState.eventVariable = 36;
            }

        }

        //case 36
        public static void DoMayorBeginningEventTwo()
        {
            Console.Clear();

            Console.Write("The builder guild’s leader nods his head and gets to work. For the second decision of the day, a group of traders are passing by outside the settlement. You have heard of their leader, Gustav. While he is a friendly person, he has many strong mercenaries protecting him. Obviously, you could trade for his goods with the settlement’s goods, but attacking him could get you all of his goods. Ignoring him is not an option since the settlement is in need of some resources.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Trade with traders");
            Console.WriteLine("Choice 2: Attack traders");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1" && input != "2")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 37;
            }
            else if (input == "2")
            {
                choiceState.eventVariable = 37;
            }

        }

        //case 37
        public static void DoMayorBeginningEventThree()
        {
            Console.Clear();

            Console.Write("You send the appropriate people to handle Gustav. For the last decision of the day, someone stole a sweetroll and a MP3 player. This someone is a new recruit, but she is a promising soldier. What is her punishment?");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Imprison the thief.");
            Console.WriteLine("Choice 2: Force the thief to work on the farms.");
            Console.WriteLine("Choice 3: Exile the thief.");
            Console.WriteLine("Choice 4: Forgive the thief.");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1" && input != "2" && input != "3" && input != "4")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 38;
            }
            else if (input == "2")
            {
                choiceState.eventVariable = 38;
            }
            else if (input == "3")
            {
                choiceState.eventVariable = 38;
            }
            else if (input == "4")
            {
                choiceState.eventVariable = 38;
            }

        }

        //case 38
        public static void DoMayorMiddleEventOne()
        {
            Console.Clear();

            Console.Write("A day passes. You hear from scout reports that the Last Judgment Gang is preparing a large attack on the settlement, and they arrive in two days. You have to organize everyone to help defend. The general is preparing the soldiers, but you have to manage everyone else in the settlement. Firstly, you have your two diplomats. They can either recruit new soldiers from outside the walls, or they can form an alliance with the Pig Farmers. With the first option, your diplomats only have time to convince four people in the nearby church. With the second, the Pig Farmers have around 16 able fighters, but they are known cannibals.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: New Recruits");
            Console.WriteLine("Choice 2: Pig Farmers");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1" && input != "2")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                army.SetDamage(army.Attack() + 10);
                mayor.setMaxHealth(mayor.GetMaxHealth() + 20);
                mayor.SetHealth(20);
                mayor.SetCurrentItem(army);
                choiceState.eventVariable = 39;
            }
            else if (input == "2")
            {
                army.SetDamage(army.Attack() + 20);
                mayor.setMaxHealth(mayor.GetMaxHealth() + 40);
                mayor.SetHealth(40);
                mayor.SetCurrentItem(army);
                choiceState.eventVariable = 39;
            }

            
        }

        //case 39
        public static void DoMayorMiddleEventTwo()
        {
            Console.Clear();

            Console.Write("Next, we have three builders. They can either expand the walls around a park, which has a watch tower for a good sniping position. Alternatively, the walls can be further reinforced with more metal, wood, and other supplies.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Expand to Park");
            Console.WriteLine("Choice 2: Reinforce Walls");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1" && input != "2")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                army.SetDamage(army.Attack() + 10);
                mayor.SetCurrentItem(army);
                choiceState.eventVariable = 40;
            }
            else if (input == "2")
            {
                mayor.setMaxHealth(mayor.GetMaxHealth() + 40);
                mayor.SetHealth(40);
                choiceState.eventVariable = 40;
            }

            
        }

        //case 40
        public static void DoMayorMiddleEventThree()
        {
            Console.Clear();

            Console.Write("There are five scavengers available to loot outside the walls. You can either send them to the police station and gun store for more guns, or you can send them to the hospital and Walgreens to find more medicine.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Scavenge Guns");
            Console.WriteLine("Choice 2: Scavenge Medicine");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1" && input != "2")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }
            if (input == "1")
            {
                army.SetDamage(army.Attack() + 10);
                mayor.SetCurrentItem(army);
                choiceState.eventVariable = 41;
            }
            else if (input == "2")
            {
                mayor.setMaxHealth(mayor.GetMaxHealth() + 40);
                mayor.SetHealth(40);
                choiceState.eventVariable = 41;
            }

            
        }

        //case 41
        public static void DoMayorMiddleEventFour()
        {
            Console.Clear();

            Console.Write("Finally, you have two scientists. They can either craft better armor, or they can craft pipe bombs.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Craft Armor");
            Console.WriteLine("Choice 2: Craft Pipe Bombs");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1" && input != "2")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                mayor.setMaxHealth(mayor.GetMaxHealth() + 40);
                mayor.SetHealth(40);
                choiceState.eventVariable = 42;
            }
            else if (input == "2")
            {
                army.SetDamage(army.Attack() + 10);
                mayor.SetCurrentItem(army);
                choiceState.eventVariable = 42;
            }
        }

        //case 42
        public static void DoMayorEndingEventEventOne()
        {
            Console.Clear();

            Console.Write("Everyone is at the walls, waiting for the Last Judgment Gang’s raid. After a few minutes, you hear the roar of motorcycles as a horde of about a hundred bandits attack. This is it. Prepare for battle!");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Battle!");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 43;
            }
            context.setState(fightState);
            DoCombatMayorJudgmentGang();
            context.setState(choiceState);

        }

        //case 43
        public static void DoMayorEndingEventEventTwo()
        {
            Console.Clear();

            Console.Write("The Last Judgment Gang gangsters rout in defeat. Their leader shouts on a megaphone.");
            Console.WriteLine("\n");
            Console.Write("Father O’Grady: This ain’t the last of us. We’ll be back!");
            Console.WriteLine("\n");
            Console.Write("For now, you have won. You will one day have to take the fight to them, but the Union of Survivors is safe. You did it, hooray!");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Victory!!");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                gameEnded = true;
            }

            
        }

        //case 44
        public static void DoMayorEndingEventEventThree()
        {
            Console.Clear();

            Console.Write("A bloody battle was fought, and the wall has fallen. The Last Judgment gangsters breach the settlement as the rest of the Union of Survivors flee. Those captured are either enslaved, or they are executed if they resist. The settlement is now run by Father O’Grady. You are injured, but you manage to flee. Although the settlement was lost, there is hope.");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Input the choice number to select the choice.");
            Console.WriteLine("Choice 1: Restart");
            var input = Console.ReadLine();
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            Console.WriteLine("\n");
            while (input != "1")
            {
                Console.WriteLine("Please type the right number.");
                input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            }

            if (input == "1")
            {
                choiceState.eventVariable = 0;
            }

            
        }
        #endregion

        #region Inventory
        public static AverageItem doScavengerInventory()
        {

            Console.Write("INVENTORY SCREEN");
            Console.WriteLine("\n");
            var items = scavenger.GetItems();
            int itemCount = 0;
            foreach (var item in items)
            {
                itemCount += 1;
                Console.WriteLine(itemCount + ") " + item.GetName());
            }

            Console.WriteLine("\n");
            Console.WriteLine("Type number of the item to use or equip it.");
            Console.WriteLine("Type 0 to leave the the inventory screen and leave you current weapon equipped.");
            var input = Console.ReadLine();
            Console.WriteLine("\n");
            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
            while (input == "-1" && int.Parse(input) > items.Count())
            {
                Console.WriteLine("Please type the right number.");
                itemCount = 0;
                foreach (var item in items)
                {
                    itemCount += 1;
                    Console.WriteLine(itemCount + ") " + item.GetName());
                }
                input = Console.ReadLine();
                Console.WriteLine("\n");
            }
            if (input == "0")
            {
                return null;
            }
            else
            {
                return items.ElementAt(int.Parse(input) - 1);
            }
        }

        public static AverageItem doSoldierInventory()
        {

            Console.Write("INVENTORY SCREEN");
            Console.WriteLine("\n");
            var items = soldier.GetItems();
            int itemCount = 0;
            foreach (var item in items)
            {
                itemCount += 1;
                Console.WriteLine(itemCount + ") " + item.GetName());
            }

            Console.WriteLine("\n");
            Console.WriteLine("Type number of the item to use or equip it.");
            Console.WriteLine("Type 0 to leave the the inventory screen and leave you current weapon equipped.");
            var input = Console.ReadLine();
            Console.WriteLine("\n");
            while (input == "-1" && int.Parse(input) > items.Count())
            {
                Console.WriteLine("Please type the right number.");
                itemCount = 0;
                foreach (var item in items)
                {
                    itemCount += 1;
                    Console.WriteLine(itemCount + ") " + item.GetName());
                }
                input = Console.ReadLine();
                Console.WriteLine("\n");
            }
            if (input == "0")
            {
                return null;
            }
            else
            {
                return items.ElementAt(int.Parse(input) - 1);
            }

        }

        #endregion


        #region Combat

        public static void DoCombatScavengerBandit()
        {
            bandit.ClearCharacter();
            var banditDmg = 2;
            while (!bandit.IsDead() && !scavenger.IsDead())
            {
                var item = scavenger.GetCurrentItem(); //initial item
                Console.Clear();

                Console.Write("COMBAT SCREEN");
                Console.WriteLine("\n");
                Console.WriteLine("Enemy: {0}", bandit.GetName());
                Console.WriteLine("Enemy Health: {0}", bandit.GetHealth());
                Console.WriteLine("Enemy Weapon Damage: {0}", banditDmg);

                Console.WriteLine("\n");
                Console.WriteLine("Player Health: {0}", scavenger.GetHealth());
                Console.WriteLine("Player Weapon Damage: {0}", item.Attack());
                Console.WriteLine("Weapon Equipped: {0}", item.GetName());
                Console.WriteLine("\n");

                Console.WriteLine("Type 1 to attack.");
                Console.WriteLine("Type 2 to change weapons or use a healing item.");

                var input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
                while(input != "1" && input != "2")
                {
                    Console.WriteLine("Please type the right number.");
                    input = Console.ReadLine();
                    Console.WriteLine("\n");
                    input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
                }
                if(input == "1")
                {
                    bandit.SetHealth(item.Attack());

                }
                else if(input == "2")
                {
                    context.setState(inventoryState);
                    var inventoryItem = doScavengerInventory();
                    if(inventoryItem != null)
                    {
                        if (inventoryItem.GetItemType() == (int)ItemTypeEnum.Healing)
                        {
                            scavenger.SetHealth(inventoryItem.Heal());
                            scavenger.RemoveItem(inventoryItem);
                        }
                        else
                        {
                            scavenger.SetCurrentItem(inventoryItem);
                        }
                    }
                    context.setState(fightState);
                }
                //antagonist attacks protagonist
                if (!bandit.IsDead())
                {
                    scavenger.SetHealth(banditDmg * -1);
                }

                if (scavenger.IsDead())
                {
                    choiceState.eventVariable = 0;
                    context.setState(choiceState);
                }
            }

            
        }

        public static void DoCombatScavengerZombie()
        {
            zombie.ClearCharacter();
            var zombieDmg = 5;
            while(!zombie.IsDead() && !scavenger.IsDead())
            {
                
                var item = scavenger.GetCurrentItem();
                Debug.WriteLine(item.Attack());
                Console.Clear();

                Console.Write("COMBAT SCREEN");
                Console.WriteLine("\n");
                Console.WriteLine("Enemy: {0}", zombie.GetName());
                Console.WriteLine("Enemy Health: {0}", zombie.GetHealth());
                Console.WriteLine("Enemy Weapon Damage: {0}", zombieDmg);

                Console.WriteLine("\n");
                Console.WriteLine("Player Health: {0}", scavenger.GetHealth());
                Console.WriteLine("Player Weapon Damage: {0}", item.Attack());
                Console.WriteLine("Weapon Equipped: {0}", item.GetName());
                Console.WriteLine("\n");

                Console.WriteLine("Type 1 to attack.");
                Console.WriteLine("Type 2 to change weapons or use a healing item.");

                var input = Console.ReadLine();
                Console.WriteLine("\n");
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
                while (input != "1" && input != "2")
                {
                    Console.WriteLine("Please type the right number.");
                    input = Console.ReadLine();
                    Console.WriteLine("\n");
                    input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
                }
                if (input == "1")
                {
                    zombie.SetHealth(item.Attack());

                }
                else if (input == "2")
                {
                    context.setState(inventoryState);
                    var inventoryItem = doScavengerInventory();
                    if (inventoryItem != null)
                    {
                        if (inventoryItem.GetItemType() == (int)ItemTypeEnum.Healing)
                        {
                            scavenger.SetHealth(inventoryItem.Heal());
                            scavenger.RemoveItem(inventoryItem);
                        }
                        else
                        {
                            scavenger.SetCurrentItem(inventoryItem);
                        }
                        context.setState(fightState);
                    }
                }
                //antagonist attacks protagonist
                if (!zombie.IsDead())
                {
                    scavenger.SetHealth(zombieDmg * -1);
                }

                if (scavenger.IsDead())
                {
                    choiceState.eventVariable = 0;
                    context.setState(choiceState);
                }
            }
            
        }


        //public static void DoCombatScavengerThreeZombies()
        //{
        //    zombie.ClearCharacter();
        //    var zombieDmg = 5;
        //    while (!zombie.IsDead() && !zombie2.IsDead() && !zombie3.IsDead() && !scavenger.IsDead())
        //    {
        //        var numZombies = 0;
        //        var item = scavenger.GetCurrentItem(); //initial item
        //        Console.Clear();

        //        Console.Write("COMBAT SCREEN");
        //        Console.WriteLine("\n");
        //        if (!zombie.IsDead())
        //        {
        //            Console.WriteLine("Enemy: {0}", zombie.GetName());
        //            Console.WriteLine("Enemy Health: {0}", zombie.GetHealth());
        //            Console.WriteLine("\n");
        //            numZombies++;
        //        }
        //        if (!zombie2.IsDead())
        //        {
        //            Console.WriteLine("Enemy: {0}", zombie2.GetName());
        //            Console.WriteLine("Enemy Health: {0}", zombie2.GetHealth());
        //            Console.WriteLine("\n");
        //            numZombies++;
        //        }
        //        if (!zombie3.IsDead())
        //        {
        //            Console.WriteLine("Enemy: {0}", zombie3.GetName());
        //            Console.WriteLine("Enemy Health: {0}", zombie3.GetHealth());
        //            Console.WriteLine("\n");
        //            numZombies++;
        //        }

        //        Console.WriteLine("Enemy Weapon Total Damage: {0}", zombieDmg * numZombies);

        //        Console.WriteLine("\n");
        //        Console.WriteLine("Player Health: ", scavenger.GetHealth());
        //        Console.WriteLine("Player Weapon Damage: {0}", item.Attack());
        //        Console.WriteLine("Weapon Equipped: {0}", item.GetName());
        //        Console.WriteLine("\n");

        //        Console.WriteLine("Type 1 to attack.");
        //        Console.WriteLine("Type 2 to change weapons or use a healing item.");

        //        var input = Console.ReadLine();
        //        input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
        //        Console.WriteLine("\n");
        //        while (input != "1" && input != "2")
        //        {
        //            Console.WriteLine("Please type the right number.");
        //            input = Console.ReadLine();
        //            Console.WriteLine("\n");
        //            input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
        //        }

        //        if (input == "1")
        //        {
        //            if (!zombie.IsDead())
        //            {
        //                zombie.SetHealth(item.Attack());
        //            }
        //            else if (!zombie2.IsDead())
        //            {
        //                zombie2.SetHealth(item.Attack());
        //            }
        //            else
        //            {
        //                zombie3.SetHealth(item.Attack());
        //            }

        //        }
        //        else if (input == "2")
        //        {
        //            context.setState(inventoryState);
        //            var inventoryItem = doScavengerInventory();
        //            if (inventoryItem != null)
        //            {
        //                if (inventoryItem.GetItemType() == (int)ItemTypeEnum.Healing)
        //                {
        //                    scavenger.SetHealth(inventoryItem.Heal());
        //                    scavenger.RemoveItem(inventoryItem);
        //                }
        //                else
        //                {
        //                    scavenger.SetCurrentItem(inventoryItem);
        //                }
        //                context.setState(fightState);
        //            }
        //        }
        //        //antagonist attacks protagonist
        //        if(numZombies > 0)
        //        {
        //            scavenger.SetHealth(zombieDmg * numZombies * -1);
        //        }

        //        if (scavenger.IsDead())
        //        {
        //            choiceState.eventVariable = 0;
        //            context.setState(choiceState);
        //        }

        //    }
            
            
        //}

        public static void DoCombatSoldierZombie()
        {
            zombie.ClearCharacter();
            var zombieDmg = 5;
            while (!zombie.IsDead() && !soldier.IsDead())
            {
                var item = soldier.GetCurrentItem(); //initial item
                Console.Clear();

                Console.Write("COMBAT SCREEN");
                Console.WriteLine("\n");
                Console.WriteLine("Enemy: {0}", zombie.GetName());
                Console.WriteLine("Enemy Health: {0}", zombie.GetHealth());
                Console.WriteLine("Enemy Weapon Damage: {0}", zombieDmg);

                Console.WriteLine("\n");
                Console.WriteLine("Player Health: {0}", soldier.GetHealth());
                Console.WriteLine("Player Weapon Damage: {0}", item.Attack());
                Console.WriteLine("Weapon Equipped: {0}", item.GetName());
                Console.WriteLine("\n");

                Console.WriteLine("Type 1 to attack.");
                Console.WriteLine("Type 2 to change weapons or use a healing item.");

                var input = Console.ReadLine();
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
                Console.WriteLine("\n");
                while (input != "1" && input != "2")
                {
                    Console.WriteLine("Please type the right number.");
                    input = Console.ReadLine();
                    Console.WriteLine("\n");
                    input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
                }
                if (input == "1")
                {
                    zombie.SetHealth(item.Attack());
                }
                else if (input == "2")
                {
                    context.setState(inventoryState);
                    var inventoryItem = doSoldierInventory();
                    if (inventoryItem != null)
                    {
                        if (inventoryItem.GetItemType() == (int)ItemTypeEnum.Healing)
                        {
                            soldier.SetHealth(inventoryItem.Heal());
                            soldier.RemoveItem(inventoryItem);
                        }
                        else
                        {
                            soldier.SetCurrentItem(inventoryItem);
                        }
                        context.setState(fightState);
                    }
                }
                //antagonist attacks protagonist
                if (!zombie.IsDead())
                {
                    soldier.SetHealth(zombieDmg * -1);
                }

                if (soldier.IsDead())
                {
                    choiceState.eventVariable = 0;
                    context.setState(choiceState);
                }
            }
        }


        public static void DoCombatMayorJudgmentGang()
        {
            judgmentGang.ClearCharacter();
            var judgmentGangDmg = 20;
            while (!judgmentGang.IsDead() && !mayor.IsDead())
            {
                var item = mayor.GetCurrentItem(); //initial item
                Console.Clear();

                Console.Write("COMBAT SCREEN");
                Console.WriteLine("\n");
                Console.WriteLine("Enemy: {0}", judgmentGang.GetName());
                Console.WriteLine("Enemy Health: {0}", judgmentGang.GetHealth());
                Console.WriteLine("Enemy Weapon Damage: {0}", judgmentGangDmg);

                Console.WriteLine("\n");
                Console.WriteLine("Player Health: {0}", mayor.GetHealth());
                Console.WriteLine("Player Weapon Damage: {0}", item.Attack());
                Console.WriteLine("Weapon Equipped: {0}", item.GetName());
                Console.WriteLine("\n");

                Console.WriteLine("Type 1 to attack.");

                var input = Console.ReadLine();
                input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
                Console.WriteLine("\n");
                while (input != "1")
                {
                    Console.WriteLine("Please type the right number.");
                    input = Console.ReadLine();
                    Console.WriteLine("\n");
                    input = correctInput.GetInput(specialCharacterRemover.GetInput(spaceRemover.GetInput(input)));
                }
                if (input == "1")
                {
                    judgmentGang.SetHealth(item.Attack());
                }
                if (!judgmentGang.IsDead())
                {
                    mayor.SetHealth(judgmentGangDmg * -1);
                }

                if (judgmentGang.IsDead())
                {
                    choiceState.eventVariable = 43;
                    context.setState(choiceState);
                }
            }
        }

        #endregion

        static void Init()
        {
            context.setState(choiceState);

            army = absLoadableItem.Load("Army");

            shovel.SetName("Shovel");
            shovel.SetDamage(3);
            axe.SetName("Axe");
            axe.SetDamage(5);
            revolver.SetName("Revolver");
            revolver.SetDamage(5);
            huntingRifle.SetName("Hunting Rifle");
            huntingRifle.SetDamage(10);
            soda.SetName("Soda");
            soda.SetHealing(5);
            medKit.SetName("MedKit");

            zombie2 = cm.LoadCharacter(zombie);
            zombie2.SetName(zombie.GetName() + "2");
            zombie3 = cm.LoadCharacter(zombie);
            zombie2.SetName(zombie.GetName() + "3");
            bandit = cm.LoadCharacter(zombie);
            bandit.SetName("Bandit");
            bandit.setMaxHealth(10);
            judgmentGang = cm.LoadCharacter(zombie);
            judgmentGang.SetName("Last Judgment Gang");
            judgmentGang.setMaxHealth(200);

        }
    }
}
