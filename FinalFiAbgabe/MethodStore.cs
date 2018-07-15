using System;
using System.Collections.Generic;

namespace FinalFiAbgabe
{
    public class MethodStore
    {
        public static GameData.Character Godess = GameData.Characters["Godess of the forest"];
        public static GameData.Room AvatarCurrentRoom = Godess.CurrentLocation;
        public static string[] Words;
        public static bool IsFightCase = false;
        public static GameData.Character Enemy;
        public static int CharacterNumber;
        public static int InteractionCounter = 0;

        public static void GameIntro()
        {
            GameData.CreateRooms();
            GameData.CreateCharaters();
            string _intro = "Welcome adventurer! You just entered the sacred forest of Dzed..." + Environment.NewLine + Godess.Information;
            Console.WriteLine(_intro);
            Look(AvatarCurrentRoom);
        }

        public static void Look(GameData.Room _room)
        {
            _room = AvatarCurrentRoom;
            Console.WriteLine(_room.Information);
            if (_room.RoomInventory.Count != 0)
            {
                Console.WriteLine("You see..."+ Environment.NewLine);
                foreach (var item in _room.RoomInventory)
                {
                    Console.WriteLine("a/an " + item.Name);
                }
            }
            else
            {
                Console.WriteLine("There's nothing to find in this place.");
            }
        }

        public static void CheckCharacters()
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
                    }
                }
                CheckCases();
            }
        }

        public static void Talk()
        {
            Console.WriteLine(GameData.Characters["Dragon of the sea"].Information + "I have some good advice for you..." + Environment.NewLine + "In the north you will find the strongest person in this world! At least the strongest enemy." + Environment.NewLine +"Allow me to ask you a question: 'Did you take the chance to slay a Golem yet?'");
            MethodStore.TalkCases();
        }

        public static void TalkCases()
        {
            string _input = Console.ReadLine().ToLower();
            switch (_input)
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

        public static void CheckCases()
        {
            Console.WriteLine("What would you like to do?");
            string _input = Console.ReadLine().ToLower();
            SplitInput(_input);
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
                Use(Words[1]);
                break;

                case "a":
                case "arm":
                Arm(Words[1]);
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

        public static void Use(string input)
        {
            input = Words[1];
            GameData.Item foundItem = Godess.CharacterInventory.Find(x => x.Name.ToLower().Contains(input));
            if (foundItem != null)
            {
                switch (foundItem.Type)
                {
                    case "Gear":
                    if(foundItem.IsArmed == false)
                    {
                        if (IsFightCase == true && Enemy.Lifepoints > 0 && Godess.Lifepoints > 0)
                        {
                            Godess.Hitpoints =  (float)(Math.Round((Godess.Hitpoints + foundItem.Points), 2));
                            Console.WriteLine("You got temporarily stronger with the help of the " + foundItem.Name + ".");
                            GameData.Characters["Golem"].Lifepoints = (float)(Math.Round((GameData.Characters["Golem"].Lifepoints - Godess.Hitpoints), 2));
                            Console.WriteLine("Ouch!!!  Golem's lifepoints: " + GameData.Characters["Golem"].Lifepoints);
                            Godess.Hitpoints = (float)(Math.Round((Godess.Hitpoints - foundItem.Points), 2));
                            Godess.Lifepoints = (float)(Math.Round((Godess.Lifepoints - Enemy.Hitpoints), 2));
                            Console.WriteLine("You're getting hit!"+ Environment.NewLine + "Oouuuch! Augh!!! Oh, you dirty creature! I'm gonna finish you on the spot!" + Environment.NewLine + "You've got " + Godess.Lifepoints + " lifepoints left. Fight him 'till the end!");
                        }
                        else
                            Console.WriteLine("There's no enemy to fight! Try another time.");
                    }
                    else
                        Console.WriteLine("You're already equipped with " + foundItem.Name);
                    break;

                    case "Health":
                        Godess.Lifepoints =  (float)(Math.Round((Godess.Lifepoints + foundItem.Points), 2));
                        Console.WriteLine("You used the healing item, new lifepoints: " + Godess.Lifepoints);
                        Godess.CharacterInventory.Remove(foundItem);
                    break;
                }
            }
            else
            {
                Console.WriteLine("Invalid item!");
            }
        }

        public static void Arm(string input)
        {
            input = Words[1];
            GameData.Item foundItem = Godess.CharacterInventory.Find(x => x.Name.ToLower().Contains(input));
            if (foundItem != null)
            {
                switch (foundItem.Type)
                {
                    case "gear":
                    if(foundItem.IsArmed == false)
                    {
                        Godess.Hitpoints =  (float)(Math.Round((Godess.Hitpoints + foundItem.Points), 2));
                        foundItem.IsArmed = true;
                        Console.WriteLine("You successfully equipped the " + foundItem.Name + ", new hitpoints: " + Godess.Hitpoints);
                    }
                    else
                    {
                        Console.WriteLine("You're already equipped with " + foundItem.Name);
                    }
                    break;

                    case "health":
                        Console.WriteLine("Health item! You can not equip this stuff... Try to use it damnit!");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Invalid item!");
            }
        }

        public static void DisplayInventory()
        {
            Console.WriteLine("Take a look at your inventory:");
            if (Godess.CharacterInventory.Count > 0)
            {
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("  {0,-10}  |  {1,-10}  |  {2,-30}  |  {3,-10}  |  {4,-10}  ", "Name", "Type", "Information", "Armed?", "Hit/Heal"));
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                foreach (var _item in Godess.CharacterInventory)
                {
                    Console.WriteLine(String.Format("  {0,-10}  |  {1,-10}  |  {2,-30}  |  {3,-10}  |  {4,-10}  ", _item.Name, _item.Type, _item.Information, _item.IsArmed, _item.Points));
                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
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

        public static void Fight(GameData.Character _enemy, string[] _input)
        {
            _input = Words;
            _enemy = Enemy;
            switch (_input[0])
            {
                case "f":
                case "fight":
                _enemy.Lifepoints = (float)(Math.Round((_enemy.Lifepoints - Godess.Hitpoints), 2));
                if (_enemy.Lifepoints > 0F)
                {
                    Console.WriteLine("Woooo!!!" + Environment.NewLine +"Damn! The " + _enemy.Name + "'s still alive...He still has got " + _enemy.Lifepoints + " lifepoints.");
                    Godess.Lifepoints = (float)(Math.Round((Godess.Lifepoints - Enemy.Hitpoints), 2));

                    if (Godess.Lifepoints > 0F)
                    {
                        Console.WriteLine("You're getting hit!"+ Environment.NewLine + "Oouuuch! Augh!!! Oh, you dirty creature! I'm gonna finish you on the spot!" + Environment.NewLine + "You've got " + Godess.Lifepoints + " lifepoints left. Fight him 'till the end!");
                    }
                    else
                    {
                        Console.WriteLine("NOOOOOOOO! How could you! Now you're dead! Stupid! Try this game again...");
                        QuitGame();
                    }
                }
                else
                {
                    Console.WriteLine("Wahhh! Nooo!!!" + Environment.NewLine +"Congratulations, great adventurer! You slayed the " + _enemy.Name + "! Awesome!");
                    if (_enemy.CharacterInventory.Count != 0)
                    {
                        Godess.CharacterInventory.Add(_enemy.CharacterInventory[0]);
                        _enemy.CharacterInventory.Remove(_enemy.CharacterInventory[0]);
                        Console.WriteLine("Awesome! You snatched the enemy's inventory!");
                    }
                    IsFightCase = false;
                    _enemy.Lifepoints = 1F;
                }
                CheckCases();
                break;

                default:
                Console.WriteLine("Ohhh little one! You're far too slow for this. It's kind of impossible...");
                Godess.Lifepoints = (float)(Math.Round((Godess.Lifepoints - Enemy.Hitpoints), 2));
                if (Godess.Lifepoints > 0F && Enemy.Lifepoints > 0F)
                {
                    Console.WriteLine("You're getting hit!"+ Environment.NewLine +"Oouuuch! Augh!!! Oh, you dirty creature! I'm gonna finish you on the spot!" + Environment.NewLine + "You've got " + Godess.Lifepoints + " lifepoints left. Fight him 'till the end!");
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
                Take(Words[1]);
                break;

                case "d":
                case "drop":
                Drop(Words[1]);
                break;

                case "n":
                case "north":
                if (AvatarCurrentRoom.North != null)
                {
                    AvatarCurrentRoom = AvatarCurrentRoom.North;
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
                if (AvatarCurrentRoom.East != null)
                {
                    AvatarCurrentRoom = AvatarCurrentRoom.East;
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
                if (AvatarCurrentRoom.South != null)
                {
                    AvatarCurrentRoom = AvatarCurrentRoom.South;
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
                if (AvatarCurrentRoom.West != null)
                {
                    AvatarCurrentRoom = AvatarCurrentRoom.West;
                    EnemyChangeRoom();
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
            "[move/m <direction>]",
            "[quit/q]"
        };

        public static void Take(string _input)
        {
            _input = Words[1];
            GameData.Item _foundItem = AvatarCurrentRoom.RoomInventory.Find(x => x.Name.ToLower().Contains(_input));
            if (_foundItem != null)
            {
                Console.WriteLine("You added " + _foundItem.Name + "to your inventory...");
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
                Console.WriteLine("You removed"+ _foundItem.Name + "from your inventory...");
                AvatarCurrentRoom.RoomInventory.Add(_foundItem);
                Godess.CharacterInventory.Remove(_foundItem);
            }
            else
            {
                Console.WriteLine("Oh mighty one! You really can't drop this!");
            }
        }

        public static void EnemyChangeRoom()
        {
            InteractionCounter = 0;
            List<GameData.Room> _allRooms = new List<GameData.Room>(GameData.Rooms.Values);
            try
            {
                Random rand = new Random();
                int randomIndex = rand.Next(_allRooms.Count);
                GameData.Characters["Golem"].CurrentLocation = _allRooms[randomIndex];
                CountCharacterNumber();
            }
            catch
            {
                Console.WriteLine("Exeption handle.");
            }
        }

        public static void CountCharacterNumber()
        {
            List<string> _currentRooms = new List<string>();

            foreach (var _character in GameData.Characters)
            {
                _currentRooms.Add(_character.Value.CurrentLocation.Name);
            }

            List<string> _sublist = _currentRooms.FindAll(isInList);
            CharacterNumber = _sublist.Count;

            if (CharacterNumber >= 2)
            {
                EnemyChangeRoom();
            }
        }

        public static bool isInList(string _s)
        {
            if (_s == GameData.Characters["Golem"].CurrentLocation.Name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
