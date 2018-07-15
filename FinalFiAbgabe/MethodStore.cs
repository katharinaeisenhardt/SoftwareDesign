using System;
using System.Collections.Generic;

namespace FinalFiAbgabe
{
    public class MethodStore
    {
        public static GameData.Character Godess = GameData.Characters["Godess of the forest"];
        public static GameData.Room AvatarCurrentRoom = Godess.CurrentLocation;
        public static string[] Words;
        public static bool IsFighting = false;
        public static GameData.Character Enemy;
        public static int InteractionCounter = 0;

        public static void LoadGameData()
        {
            GameData.CreateRooms();
            GameData.CreateCharaters();
            GameIntroduction();
        }

        public static void GameIntroduction()
        {
            string _intro = "Welcome adventurer! You just entered the sacred forest of Dzed..." + Environment.NewLine + Godess.Information;
            Console.WriteLine(_intro);
            Look(AvatarCurrentRoom);
        }

        public static void Look(GameData.Room room)
        {
            room = AvatarCurrentRoom;
            Console.WriteLine(room.Information);
            if (room.RoomInventory.Count != 0)
            {
                Console.WriteLine("You see..."+ Environment.NewLine);
                foreach (var item in room.RoomInventory)
                {
                    Console.WriteLine("a/an " + item.Name);
                }
            }
            else
            {
                Console.WriteLine("There's nothing to find in this place.");
            }
        }

        public static void CheckCharactersInRoom()
        {
            foreach (var character in GameData.Characters.Values)
            {
                if (character.CurrentLocation == AvatarCurrentRoom)
                {
                    string name = character.Name;
                    switch (name)
                    {
                        case "Golem":
                        if (InteractionCounter == 0)
                        {
                            Enemy = character;
                            IsFighting = true;
                            Console.WriteLine("There's an enemy! You're getting attacked."+ Environment.NewLine + "Fight him!");
                            InputPrompt();
                            InteractionCounter++;
                        }
                        InputPrompt();
                        break;

                        case "King of death":
                        Enemy = character;
                        IsFighting = true;
                        Console.WriteLine("There's a pressuring killing intent..."+ Environment.NewLine + "Before you stands the King of death! Defeat him to complete the mission and free the spirits of the tyranny!");
                        InputPrompt();
                        QuitGame();
                        break;

                        case "Dragon of the sea":
                        if (InteractionCounter == 0)
                        {
                            GameData.Helper.Talk();
                            InteractionCounter++;
                        }
                        InputPrompt();
                        break;

                        default:
                        InputPrompt();
                        break;
                    }
                }
            }
        }

        public static void InputPrompt()
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
                try{
                    GameData.Item.Use(Words[1]);
                }
                catch
                {
                    Console.WriteLine("WROOOOONG!  You should choose an item!");
                }
                break;

                case "a":
                case "arm":
                try{
                    GameData.Gear.Arm(Words[1]);
                }
                catch
                {
                    Console.WriteLine("WROOOOONG!  You should choose an item!");
                }
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
                if (IsFighting == true)
                {
                    GameData.Avatar.Fight(Enemy, Words);
                }
                else
                {
                    CheckNonFightCases(Words);
                }
                break;
            }
        }

        public static void DisplayInventory()
        {
            Console.WriteLine("Take a look at your inventory:");
            if (Godess.CharacterInventory.Count > 0)
            {
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("  {0,-10}  |  {1,-10}  |  {2,-10}  |  {3,-10}  |  {4,-65}  |", "Name", "Type", "Armed?", "Hit/Heal", "Information"));
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------");
                foreach (var item in Godess.CharacterInventory)
                {
                    Console.WriteLine(String.Format("  {0,-10}  |  {1,-10}  |  {2,-10}  |  {3,-10}  |  {4,-65}  |", item.Name, item.Type, item.IsArmed, item.Points, item.Information));
                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Woops! Your inventory is empty...");
            }
        }

        public static void QuitGame()
        {
            Console.WriteLine("Game over!");
            Environment.Exit(0);
        }

        public static void CheckNonFightCases(string[] _input)
        {
            Words = _input;
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
                try{
                    Take(Words[1]);
                }
                catch
                {
                    Console.WriteLine("WROOOOONG!  You should choose an item!");
                }
                break;

                case "d":
                case "drop":
                try{
                    Drop(Words[1]);
                }
                catch
                {
                    Console.WriteLine("WROOOOONG!  You should choose an item!");
                }
                break;

                case "n":
                case "north":
                if (AvatarCurrentRoom.North != null)
                {
                    AvatarCurrentRoom = AvatarCurrentRoom.North;
                    GameData.Enemy.EnemyChangeRoom();
                    Look(AvatarCurrentRoom);
                }
                else
                {
                    Console.WriteLine("What to do?! There's a dead end...");
                }
                break;

                case "e":
                case "east":
                if (AvatarCurrentRoom.East != null)
                {
                    AvatarCurrentRoom = AvatarCurrentRoom.East;
                    GameData.Enemy.EnemyChangeRoom();
                    Look(AvatarCurrentRoom);
                }
                else
                {
                    Console.WriteLine("What to do?! There's a dead end...");
                }
                break;

                case "s":
                case "south":
                if (AvatarCurrentRoom.South != null)
                {
                    AvatarCurrentRoom = AvatarCurrentRoom.South;
                    GameData.Enemy.EnemyChangeRoom();
                    Look(AvatarCurrentRoom);
                }
                else
                {
                    Console.WriteLine("What to do?! There's a dead end...");
                }
                break;

                case "w":
                case "west":
                if (AvatarCurrentRoom.West != null)
                {
                    AvatarCurrentRoom = AvatarCurrentRoom.West;
                    GameData.Enemy.EnemyChangeRoom();
                    Look(AvatarCurrentRoom.West);
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

        public static void Help()
        {
            Console.WriteLine("You can use the following commands:"+ Environment.NewLine);
            foreach (var _command in HelpCommands)
            {
                Console.WriteLine(_command);
            }
        }

        public static List<string> HelpCommands = new List<string>
        {
            "[help/h]   [look/l]   [inventory/i]",
            "[take/t <item>]   [drop/d <item>]   [arm/a <item>]   [use/u <item>]",
            "[north/n]   [east/e]   [south/s]   [west/w]",
            "[quit/q]"
        };

        public static void Take(string _input)
        {
            _input = Words[1];
            GameData.Item _foundItem = AvatarCurrentRoom.RoomInventory.Find(x => x.Name.ToLower().Contains(_input));
            if (_foundItem != null)
            {
                Console.WriteLine("You added " + _foundItem.Name + " to your inventory...");
                Godess.CharacterInventory.Add(_foundItem);
                AvatarCurrentRoom.RoomInventory.Remove(_foundItem);
            }
            else
            {
                Console.WriteLine("Well, you really can't take this!");
            }
        }

        public static void Drop(string _input)
        {
            _input = Words[1];
            GameData.Item _foundItem = Godess.CharacterInventory.Find(x => x.Name.ToLower().Contains(_input));
            if (_foundItem != null)
            {
                Console.WriteLine("You removed "+ _foundItem.Name + " from your inventory...");
                AvatarCurrentRoom.RoomInventory.Add(_foundItem);
                Godess.CharacterInventory.Remove(_foundItem);
            }
            else
            {
                Console.WriteLine("Oh mighty one! You really can't drop this!");
            }
        }
    }
}
