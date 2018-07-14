using System;
using System.Collections.Generic;

namespace FinaleAbgabe
{
    class MethodStore
    {
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
                //DisplayInventory();
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
                GameData.Room.RoomDescription(GameData.characters["Godess of the forest"]._currentLocation);
                break;

                case "t":
                case "take":
                //DisplayInventory();
                break;

                case "d":
                case "drop":
                //Drop();
                break;

                case "n":
                case "north":
                if (GameData.characters["Godess of the forest"]._currentLocation.north != null)
                {
                    GameData.characters["Godess of the forest"]._currentLocation = GameData.characters["Godess of the forest"]._currentLocation.north;
                    EnemyChangeRoom();
                    GameData.Room.RoomDescription(GameData.characters["Godess of the forest"]._currentLocation);
                }
                else
                {
                    Console.WriteLine("What to do?! There's a dead end...");
                }
                break;

                case "e":
                case "east":
                if (GameData.characters["Godess of the forest"]._currentLocation.east != null)
                {
                    GameData.characters["Godess of the forest"]._currentLocation = GameData.characters["Godess of the forest"]._currentLocation.east;
                    EnemyChangeRoom();
                    GameData.Room.RoomDescription(GameData.characters["Godess of the forest"]._currentLocation);
                }
                else
                {
                    Console.WriteLine("What to do?! There's a dead end...");
                }
                break;

                case "s":
                case "south":
                if (GameData.characters["Godess of the forest"]._currentLocation.south != null)
                {
                    GameData.characters["Godess of the forest"]._currentLocation = GameData.characters["Godess of the forest"]._currentLocation.south;
                    EnemyChangeRoom();
                    GameData.Room.RoomDescription(GameData.characters["Godess of the forest"]._currentLocation);
                }
                else
                {
                    Console.WriteLine("What to do?! There's a dead end...");
                }
                break;

                case "w":
                case "west":
                if (GameData.characters["Godess of the forest"]._currentLocation.west != null)
                {
                    GameData.characters["Godess of the forest"]._currentLocation = GameData.characters["Godess of the forest"]._currentLocation.west;
                    EnemyChangeRoom();
                    GameData.Room.RoomDescription(GameData.characters["Godess of the forest"]._currentLocation.west);
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
                if (charac._currentLocation == GameData.characters["Godess of the forest"]._currentLocation)
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