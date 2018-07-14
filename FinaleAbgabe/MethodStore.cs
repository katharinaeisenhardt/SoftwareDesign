using System;
using System.Collections.Generic;

namespace FinaleAbgabe
{
    class MethodStore
    {
        public static GameData.Room AvatarCurrentLocation = GameData.characters["Godess of the forest"]._currentLocation;
        public static string[] _words;
        public static bool isFightCase = false;

        public static GameData.Character _enemy;

        public static int characterNumber;

        public static void GameIntroduction()
        {
            string intro = "Welcome adventurer! You just entered the sacred forest of Dzed..."/*+Avatar.information*/;
            Console.WriteLine(intro);
            GameData.CreateRooms();
            GameData.CreateCharaters();
            Look(AvatarCurrentLocation);
        }

        public static void Look(GameData.Room room)
        {
            room = AvatarCurrentLocation;
            Console.Write(room._information + Environment.NewLine);
            if(room._roomInventory.Count != 0)
            {
                Console.Write("You see..."+ Environment.NewLine);
                foreach(var item in room._roomInventory)
                {
                    Console.WriteLine("a/an " + item.name);
                }
            }
            else
            {
                Console.WriteLine("There's nothing to find in this place.");
            }
        }

        public static void Take(string input)
        {
            input = _words[1];
            foreach(var item in AvatarCurrentLocation._roomInventory)
            {
                if(item.name == input)
                {
                    GameData.characters["Godess of the forest"]._characterInventory.Add(item);
                }
            }
        }

        public static void DisplayInventory()
        {
            Console.WriteLine("Take a look at your inventory:");
            if(GameData.characters["Godess of the forest"]._characterInventory.Count > 0)
            {
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("  {0,-10}  |  {1,-10}  |  {2,-30}  |  {3,-10}  |  {4,-10}  ", "Name", "Type", "Information", "Armed?", "Hit/Heal"));
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                foreach(var item in GameData.characters["Godess of the forest"]._characterInventory)
                {
                    Console.WriteLine(String.Format("  {0,-10}  |  {1,-10}  |  {2,-30}  |  {3,-10}  |  {4,-10}  ", item.name, item.type, item.information, 1, 1));
                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Woops! Your inventory is empty...");
            }
        }

        public static void Drop()
        {
        }

        public static void Talk()
        {
            Console.WriteLine("Greetings, brave adventurer. I'm the Dragon of the sea! I have some good advice for you..." + Environment.NewLine + "In the north you will find the strongest person in this world! At least the strongest enemy." + Environment.NewLine +"Allow me to ask you a question: 'Did you take the chance to slay a Golem yet?'");
            MethodStore.TalkCases();
        }
        public static void TalkCases()
        {
            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "y":
                case "yes":
                Console.WriteLine("Excellent, my mighty warrior. Go now and fulfill your fate on the darkest path in the north!"); 
                break;

                case "n":
                case "no":
                Console.WriteLine("Ohhh little one! You might want to go back and equip yourself to be the strongest monster slayer ever...");
                break;

                default:
                Console.WriteLine("I'm sorry little one... I could not understand you. Please try again and answer with [yes/y] or [no/n].");
                TalkCases();
                break;
            }
        }

        public static void Help()
        {
            Console.WriteLine("You can use the following commands:"+ Environment.NewLine);
            foreach (var command in GameData.commands)
                Console.WriteLine(command);
        }

        public static void CheckCases()
        {
            Console.WriteLine("What would you like to do?");
            string input = Console.ReadLine().ToLower();
            SplitInput(input);
            CheckFightCases(_words);
        }

        public static Array SplitInput(string input) 
        {
            _words = input.Split(" ");
            return _words;
        }

        public static void CheckFightCases(string[] input)
        {
            _words = input;

            switch (_words[0])
            {
                case "u":
                case "use":
                //Use(string [] input);
                break;

                case "a":
                case "arm":
                //Arm(string [] input);
                break;

                case "i":
                case "inventory":
                DisplayInventory();
                break;

                case "q":
                case "quit":
                //QuitGame();
                break;

                default:
                if(isFightCase == true)
                {
                    Fight(_enemy, _words);
                }
                else{
                CheckNonFightCases(_words);
                }
                break;
            }
        }


        public static void CheckNonFightCases(string[] input)
        {
            _words = input;

            switch (_words[0])
            {
                case "h":
                case "help":
                Help();
                break;

                case "l":
                case "look":
                Look(AvatarCurrentLocation);
                break;

                case "t":
                case "take":
                Take(_words[1]);
                break;

                case "d":
                case "drop":
                //Drop(_words[1]);
                break;

                case "n":
                case "north":
                if (AvatarCurrentLocation.north != null)
                {
                    AvatarCurrentLocation = AvatarCurrentLocation.north;
                    EnemyChangeRoom();
                    Look(AvatarCurrentLocation);
                }
                else
                {
                    Console.WriteLine("What to do?! There's a dead end...");
                }
                break;

                case "e":
                case "east":
                if (AvatarCurrentLocation.east != null)
                {
                    AvatarCurrentLocation = AvatarCurrentLocation.east;
                    EnemyChangeRoom();
                    Look(AvatarCurrentLocation);
                }
                else
                {
                    Console.WriteLine("What to do?! There's a dead end...");
                }
                break;

                case "s":
                case "south":
                if (AvatarCurrentLocation.south != null)
                {
                    AvatarCurrentLocation = AvatarCurrentLocation.south;
                    EnemyChangeRoom();
                    Look(AvatarCurrentLocation);
                }
                else
                {
                    Console.WriteLine("What to do?! There's a dead end...");
                }
                break;

                case "w":
                case "west":
                if (AvatarCurrentLocation.west != null)
                {
                    AvatarCurrentLocation = AvatarCurrentLocation.west;
                    EnemyChangeRoom();
                    Look(AvatarCurrentLocation.west);
                }
                else
                {
                    Console.WriteLine("What to do?! There's a dead end...");
                }
                break;

                default:
                Console.WriteLine("Oh Lord... You used some invalid input. Take another shot!");
                break;
            }
        }

        public static void EnemyChangeRoom()
        {
            List<GameData.Room> allRooms = new List<GameData.Room>(GameData.rooms.Values);
            Random rand = new Random();
            int randomIndex = rand.Next(allRooms.Count);
            GameData.characters["Golem"]._currentLocation = allRooms[randomIndex];
            CountCharacterNumber();
        }
        public static void CountCharacterNumber()
        {
            List<string> currentRooms = new List<string>();
            foreach(var character in GameData.characters)
            {
                currentRooms.Add(character.Value._currentLocation._name);
            }
            List<string> sublist = currentRooms.FindAll(IsInList);
            characterNumber = sublist.Count;
            
            if(characterNumber >= 2)
            {
                EnemyChangeRoom();
            }
        }

        public static bool IsInList(string s)
        {
            if(s == GameData.characters["Golem"]._currentLocation._name)
            {
                return true;
            }
            else{
                return false;
            }
        }

        public static void CheckEnemy()
        {
            foreach(var charac in GameData.characters.Values)
            { 
                if (charac._currentLocation == AvatarCurrentLocation)
                {
                    string name = charac._name;
                    switch(name)
                    {
                        case "Golem":
                        _enemy = charac;
                        isFightCase = true;
                        Console.WriteLine("There's an enemy! You're getting attacked."+ Environment.NewLine + "Fight him!");
                        CheckCases();
                        CheckCases();
                        break;

                        case "King of death":
                        _enemy = charac;
                        isFightCase = true;
                        Console.WriteLine("There's a pressuring killing intent..."+ Environment.NewLine + "Before you stands the King of death! Defeat him to complete the mission and free the spirits of the tyranny!");
                        CheckCases();
                        //quitgame();
                        break;

                        case "Dragon of the sea":
                        Talk();
                        CheckCases();
                        break;

                        default: 
                        CheckCases();
                        break;
                    }
                }
            }
        }

        public static void Fight(GameData.Character enemycharac, string[] words)
        {
            words = _words;
            enemycharac = _enemy;
            switch(words[0])
            {
                case "f":
                case "fight":
                enemycharac._lifepoints = (float)(Math.Round((enemycharac._lifepoints - GameData.characters["Godess of the forest"]._hitpoints), 2));
                if(enemycharac._lifepoints > 0F)
                {
                    Console.WriteLine("Woooo!!!" + Environment.NewLine +"Damn! The " + enemycharac._name + "'s still alive...He still has got " + enemycharac._lifepoints + " lifepoints.");
                    GameData.characters["Godess of the forest"]._lifepoints = (float)(Math.Round((GameData.characters["Godess of the forest"]._lifepoints - enemycharac._hitpoints), 2));
                    if(GameData.characters["Godess of the forest"]._lifepoints > 0F)
                    {
                        Console.WriteLine("Oouuuch! Augh!!! Oh, you dirty creature! I'm gonna finish you on the spot!" + Environment.NewLine + "You've got " + GameData.characters["Godess of the forest"]._lifepoints + " lifepoints left. Fight him 'till the end!");
                        CheckCases();
                    }
                    else
                    {
                        Console.WriteLine("NOOOOOOOO! How could you! Now you're dead! Stupid! Loser! Try this game again...");
                        //quitgame();
                    }
                }
                else
                {
                    Console.WriteLine("Wahhh! Nooo!!!" + Environment.NewLine +"Congratulations, great adventurer! You slayed the " + enemycharac._name + "! Awesome!");
                    isFightCase = false;
                    enemycharac._lifepoints = 1F;
                }
                break;

                default:
                Console.WriteLine("Ohhh little one! You're far too slow for this. It's kind of impossible...");
                GameData.characters["Godess of the forest"]._lifepoints = (float)(Math.Round((GameData.characters["Godess of the forest"]._lifepoints - enemycharac._hitpoints), 2));
                if(GameData.characters["Godess of the forest"]._lifepoints > 0F)
                {
                    Console.WriteLine("Oouuuch! Augh!!! Oh, you dirty creature! I'm gonna finish you on the spot!" + Environment.NewLine + "You've got " + GameData.characters["Godess of the forest"]._lifepoints + " lifepoints left. Fight him 'till the end!");
                    Console.WriteLine("You can't fight like this! Try another input. Valid inputs are: [fight/f] [arm/a <item>] [use/u <item>] [inventory/i] and [quit/q]");
                    CheckCases();
                }
                else
                {
                    Console.WriteLine("NOOOOOOOO! How could you! Now you're dead! Stupid! Loser! Try this game again...");
                    //quitgame();
                }
                break;
            }
        }
    }
}