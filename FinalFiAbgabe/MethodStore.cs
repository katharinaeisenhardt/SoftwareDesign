using System;
using System.Collections.Generic;

namespace FinalFiAbgabe
{
    public class MethodStore
    {
        public static GameData.Character Godess = GameData.Characters["Godess of the forest"];
        public static GameData.Room AvatarCurrentRoom = Godess._currentLocation;
        public static string[] Words;
        public static bool IsFightCase = false;
        public static GameData.Character Enemy;
        public static int CharacterNumber;
        public static int InteractionCounter = 0;


        public static void GameIntro()
        {
            string intro = "Welcome adventurer! You just entered the sacred forest of Dzed..." + Environment.NewLine + Godess._information;
            Console.WriteLine(intro);
            GameData.CreateRooms();
            GameData.CreateCharaters();
            Look(AvatarCurrentRoom);
        }

        public static void Look(GameData.Room room)
        {
            room = AvatarCurrentRoom;

            Console.WriteLine(room._information + Environment.NewLine);
            try
            {
                if (room._roomInventory.Count != 0)
                {
                    Console.WriteLine("You see..."+ Environment.NewLine);
                    foreach (var item in room._roomInventory)
                    {
                        Console.WriteLine("a/an " + item._name);
                    }
                }
                else
                {
                    Console.WriteLine("There's nothing to find in this place.");
                }
            }
            catch
            {
                Console.WriteLine("Exception Handle");
            }
        }

        public static void Take(string input)
        {
            input = Words[1];
            GameData.Item foundItem = AvatarCurrentRoom._roomInventory.Find(x => x._name.ToLower().Contains(input));
            if (foundItem != null)
            {
                Console.WriteLine("You added " + foundItem._name + "to your inventory...");
                Godess._characterInventory.Add(foundItem);
                AvatarCurrentRoom._roomInventory.Remove(foundItem);
            }
            else
            {
                Console.WriteLine("Well, you really can't take this!");
            }
        }

        public static void Drop(string input)
        {
            input = Words[1];
            GameData.Item foundItem = Godess._characterInventory.Find(x => x._name.ToLower().Contains(input));
            if (foundItem != null)
            {
                Console.WriteLine("You removed"+ foundItem._name + "from your inventory...");
                AvatarCurrentRoom._roomInventory.Add(foundItem);
                Godess._characterInventory.Remove(foundItem);
            }
            else
            {
                Console.WriteLine("Oh mighty one! You really can't drop this!");
            }
        }

        public static void DisplayInventory()
        {
            Console.WriteLine("Take a look at your inventory:");
            if (Godess._characterInventory.Count > 0)
            {
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("  {0,-10}  |  {1,-10}  |  {2,-30}  |  {3,-10}  |  {4,-10}  ", "Name", "Type", "Information", "Armed?", "Hit/Heal"));
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                foreach (var item in Godess._characterInventory)
                {
                    Console.WriteLine(String.Format("  {0,-10}  |  {1,-10}  |  {2,-30}  |  {3,-10}  |  {4,-10}  ", item._name, item._type, item._information, item._isArmed, item._points));
                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Woops! Your inventory is empty...");
            }
        }
        public static void Talk()
        {
            Console.WriteLine(GameData.Characters["Dragon of the sea"]._information + "I have some good advice for you..." + Environment.NewLine + "In the north you will find the strongest person in this world! At least the strongest enemy." + Environment.NewLine +"Allow me to ask you a question: 'Did you take the chance to slay a Golem yet?'");
            MethodStore.talkCases();
        }
        public static void talkCases()
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
                talkCases();
                break;
            }
        }

        public static void Help()
        {
            Console.WriteLine("You can use the following commands:"+ Environment.NewLine);
            foreach (var command in GameData.Commands)
            {
                Console.WriteLine(command);
            }
        }

        public static void CheckCases()
        {
            Console.WriteLine("What would you like to do?");
            string input = Console.ReadLine().ToLower();
            SplitInput(input);
            CheckFightCases(Words);
        }

        public static Array SplitInput(string input)
        {
            Words = input.Split(" ");
            return Words;
        }

        public static void CheckFightCases(string[] input)
        {
            Words = input;
            switch (Words[0])
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
                QuitGame();
                break;

                default:
                if (IsFightCase == true)
                {
                    Fight(Enemy, Words);
                }
                else
                {
                    CheckNonFightCases(Words);
                }
                break;
            }
        }


        public static void CheckNonFightCases(string[] input)
        {
            Words = input;
            switch (Words[0])
            {
                case "h":
                case "help":
                Help();
                break;

                case "l":
                case "look":
                Look(AvatarCurrentRoom);
                break;

                case "t":
                case "take":
                Take(Words[1]);
                break;

                case "d":
                case "drop":
                Drop(Words[1]);
                break;

                case "n":
                case "north":
                if (AvatarCurrentRoom.north != null)
                {
                    AvatarCurrentRoom = AvatarCurrentRoom.north;
                    EnemyChangeRoom();
                    Look(AvatarCurrentRoom);
                }
                else
                {
                    Console.WriteLine("What to do?! There's a dead end...");
                }
                break;

                case "e":
                case "east":
                if (AvatarCurrentRoom.east != null)
                {
                    AvatarCurrentRoom = AvatarCurrentRoom.east;
                    EnemyChangeRoom();
                    Look(AvatarCurrentRoom);
                }
                else
                {
                    Console.WriteLine("What to do?! There's a dead end...");
                }
                break;

                case "s":
                case "south":
                if (AvatarCurrentRoom.south != null)
                {
                    AvatarCurrentRoom = AvatarCurrentRoom.south;
                    EnemyChangeRoom();
                    Look(AvatarCurrentRoom);
                }
                else
                {
                    Console.WriteLine("What to do?! There's a dead end...");
                }
                break;

                case "w":
                case "west":
                if (AvatarCurrentRoom.west != null)
                {
                    AvatarCurrentRoom = AvatarCurrentRoom.west;
                    EnemyChangeRoom();
                    Look(AvatarCurrentRoom.west);
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
            InteractionCounter = 0;
            List<GameData.Room> allRooms = new List<GameData.Room>(GameData.Rooms.Values);
            try
            {
                Random rand = new Random();
                int randomIndex = rand.Next(allRooms.Count);
                GameData.Characters["Goyl"]._currentLocation = allRooms[randomIndex];
                CountCharacterNumber();
            }
            catch
            {
                Console.WriteLine("Exeption handle.");
            }
        }

        public static bool isInList(string s)
        {
            if (s == GameData.Characters["Goyl"]._currentLocation._name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void CountCharacterNumber()
        {
            List<string> currentRooms = new List<string>();

            foreach (var character in GameData.Characters)
            {
                currentRooms.Add(character.Value._currentLocation._name);
            }

            List<string> sublist = currentRooms.FindAll(isInList);
            CharacterNumber = sublist.Count;

            if (CharacterNumber >= 2)
            {
                EnemyChangeRoom();
            }
        }

        public static void CheckEnemy()
        {
            foreach (var character in GameData.Characters.Values)
            {
                if (character._currentLocation == AvatarCurrentRoom)
                {
                    string name = character._name;
                    switch (name)
                    {
                        case "Golem":
                        if (InteractionCounter == 0)
                        {
                            Enemy = character;
                            IsFightCase = true;
                            Console.WriteLine("There's an enemy! You're getting attacked."+ Environment.NewLine + "Fight him!");
                            CheckCases();
                            InteractionCounter++;
                        }
                        CheckCases();
                        break;

                        case "King of death":
                        Enemy = character;
                        IsFightCase = true;
                        Console.WriteLine("There's a pressuring killing intent..."+ Environment.NewLine + "Before you stands the King of death! Defeat him to complete the mission and free the spirits of the tyranny!");
                        CheckCases();
                        QuitGame();
                        break;

                        case "Dragon of the sea":
                        if (InteractionCounter == 0)
                        {
                            Talk();
                            InteractionCounter++;
                        }
                        CheckCases();
                        break;

                        default:
                        CheckCases();
                        break;
                    }
                }
            }
        }
        public static void Fight(GameData.Character enemy, string[] input)
        {
            input = Words;
            enemy = Enemy;
            switch (input[0])
            {
                case "f":
                case "fight":
                enemy._lifepoints = (float)(Math.Round((enemy._lifepoints - Godess._hitpoints), 2));
                if (enemy._lifepoints > 0F)
                {
                    Console.WriteLine("Woooo!!!" + Environment.NewLine +"Damn! The " + enemy._name + "'s still alive...He still has got " + enemy._lifepoints + " lifepoints.");
                    Godess._lifepoints = (float)(Math.Round((Godess._lifepoints - Enemy._hitpoints), 2));

                    if (Godess._lifepoints > 0F)
                    {
                        Console.WriteLine("You're getting hit!"+ Environment.NewLine + "Oouuuch! Augh!!! Oh, you dirty creature! I'm gonna finish you on the spot!" + Environment.NewLine + "You've got " + Godess._lifepoints + " lifepoints left. Fight him 'till the end!");
                    }
                    else
                    {
                        Console.WriteLine("NOOOOOOOO! How could you! Now you're dead! Stupid! Try this game again...");
                        QuitGame();
                    }

                }
                else
                {
                    Console.WriteLine("Wahhh! Nooo!!!" + Environment.NewLine +"Congratulations, great adventurer! You slayed the " + enemy._name + "! Awesome!");
                    if (enemy._characterInventory.Count != 0)
                    {
                        Godess._characterInventory.Add(enemy._characterInventory[0]);
                        enemy._characterInventory.Remove(enemy._characterInventory[0]);
                        Console.WriteLine("Awesome! You snatched the {0}",enemy._characterInventory[0]);
                    }
                    IsFightCase = false;
                    enemy._lifepoints = 1F;
                }
                CheckCases();
                break;

                default:
                Console.WriteLine("Ohhh little one! You're far too slow for this. It's kind of impossible...");
                Godess._lifepoints = (float)(Math.Round((Godess._lifepoints - Enemy._hitpoints), 2));
                if (Godess._lifepoints > 0F)
                {
                    Console.WriteLine("You're getting hit!"+ Environment.NewLine +"Oouuuch! Augh!!! Oh, you dirty creature! I'm gonna finish you on the spot!" + Environment.NewLine + "You've got " + Godess._lifepoints + " lifepoints left. Fight him 'till the end!");
                    Console.WriteLine("You can't fight like this! Try another input. Valid inputs are: [fight/f] [arm/a <item>] [use/u <item>] [inventory/i] and [quit/q]");
                    CheckCases();
                }
                else
                {
                    Console.WriteLine("NOOOOOOOO! How could you! Now you're dead! Stupid! Try this game again...");
                    QuitGame();
                }
                break;
            }
        }
        public static void QuitGame()
        {
            Console.WriteLine("Game over!");
            Environment.Exit(0);
        }
    }
}
