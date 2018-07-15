using System;
using System.Collections.Generic;

namespace FinalFiAbgabe
{
    public class GameData
    {
        public static Dictionary<string, Room> Rooms;
        public static Dictionary<string, Character> Characters;
        public static Dictionary<string, Item> Items = new Dictionary<string, Item>();
        
        public static int CharacterNumber;

        public class Room
        {
            public string Name;
            public string Information;
            public Room North;
            public Room East;
            public Room South;
            public Room West;
            public List<Item> RoomInventory = new List<Item>();

            public Room(string name, string information)
            {
                this.Name = name;
                this.Information = information;
            }
        }

        public static void CreateRooms()
        {
            Room Glade = new Room
            (
                "Silent Wood Glade",
                "You just arrived at the Silent Wood Glade..."
            );
            Gear Arrow = new Gear
            (
            "Arrow","gear","You can use me to stab an enemy or send me flying!",0.1F,false
            );
            Health Herb = new Health
            (
            "Herb","health","You can use me to get stronger!", 0.1F, false
            );
            Glade.RoomInventory.AddRange(new List<Item>(){Arrow, Herb});

            Room StoneQuarry = new Room
            (
                "Brachial Stone Quarry",
                "You just arrived at the Brachial Stone Quarry..."
            );
            Gear Stone = new Gear
            (
            "Rock", "gear", "You can use me to provoke an enemy or to throw me!", 0.05F, false
            );
            StoneQuarry.RoomInventory.Add(Stone);

            Room RabbitHole = new Room
            (
               "Dark Rabbit Hole",
                "You just entered the Dark Rabbit Hole..."
            );

            Room Sea = new Room
            (
                "Sacred Sea",
                "You just arrived at the bay of the Sacred Sea..."
            );
            Health Potion = new Health
            (
            "Potion","health","You can use me to get invincible!",0.3F, false
            );
            Sea.RoomInventory.Add(Potion);

            Room DeathValley = new Room
            (
                "Haunted Valley of Death",
                "You just entered the Haunted Valley of Death..."
            );
 
            Glade.North = StoneQuarry;

            StoneQuarry.East = Sea;
            StoneQuarry.South = Glade;
            StoneQuarry.West = RabbitHole;

            RabbitHole.East = StoneQuarry;
            RabbitHole.South = Glade;

            Sea.North = DeathValley;
            Sea.West = StoneQuarry;

            DeathValley.South = Sea;

            Rooms = new Dictionary<string, Room>();
            Rooms["Silent Wood Glade"] = Glade;
            Rooms["Brachial Stone Quarry"] = StoneQuarry;
            Rooms["Dark Rabbit Hole"] = RabbitHole;
            Rooms["Sacred Sea"] = Sea;
            Rooms["Haunted Valley of Death"] = DeathValley;

            Items["Arrow"] = Arrow;
            Items["Rocks"] = Stone;
            Items["Herb"] = Herb;
            Items["Potion"] = Potion;
        }

        public class Character
        {
            public string Name;
            public float Lifepoints;
            public float Hitpoints;
            public string Information;
            public Room CurrentLocation;
            public List<Item> CharacterInventory = new List <Item>();
        }

        public class Avatar : Character
        {
            public Avatar(string name, float lifepoints, float hitpoints, string information, Room currentLocation)
            {
                this.Name = name;
                this.Lifepoints = lifepoints;
                this.Hitpoints = hitpoints;
                this.Information = information;
                this.CurrentLocation = currentLocation;
            }

            public static void Fight(Character enemy, string[] input)
            {
                Character godess = Characters["Godess of the forest"];
                input = MethodStore.Words;
                enemy = MethodStore.Enemy;
                switch (input[0])
                {
                    case "f":
                    case "fight":
                    enemy.Lifepoints = (float)(Math.Round((enemy.Lifepoints - godess.Hitpoints), 2));
                    if (enemy.Lifepoints > 0F)
                    {
                        Console.WriteLine("Woooo!!!" + Environment.NewLine +"Damn! The " + enemy.Name + "'s still alive...He still has got " + enemy.Lifepoints + " lifepoints.");
                        godess.Lifepoints = (float)(Math.Round((godess.Lifepoints - MethodStore.Enemy.Hitpoints), 2));

                        if (godess.Lifepoints > 0F)
                        {
                            Console.WriteLine("You're getting hit!"+ Environment.NewLine + "Oouuuch! Augh!!! Oh, you dirty creature! I'm gonna finish you on the spot!" + Environment.NewLine + "You've got " + godess.Lifepoints + " lifepoints left. Fight him 'till the end!");
                        }
                        else
                        {
                            Console.WriteLine("NOOOOOOOO! How could you! Now you're dead! Stupid! Try this game again...");
                            MethodStore.QuitGame();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wahhh! Nooo!!!" + Environment.NewLine +"Congratulations, great adventurer! You slayed the " + enemy.Name + "! Awesome!");
                        if (enemy.CharacterInventory.Count != 0)
                        {
                            godess.CharacterInventory.Add(enemy.CharacterInventory[0]);
                            enemy.CharacterInventory.Remove(enemy.CharacterInventory[0]);
                            Console.WriteLine("Awesome! You snatched the enemy's inventory!");
                        }
                        MethodStore.IsFighting = false;
                        enemy.Lifepoints = 1F;
                    }
                    MethodStore.CheckCases();
                    break;

                    default:
                    Console.WriteLine("Ohhh little one! You're far too slow for this. It's kind of impossible...");
                    godess.Lifepoints = (float)(Math.Round((godess.Lifepoints - MethodStore.Enemy.Hitpoints), 2));
                    if (godess.Lifepoints > 0F && MethodStore.Enemy.Lifepoints > 0F)
                    {
                        Console.WriteLine("You're getting hit!"+ Environment.NewLine +"Oouuuch! Augh!!! Oh, you dirty creature! I'm gonna finish you on the spot!" + Environment.NewLine + "You've got " + godess.Lifepoints + " lifepoints left. Fight him 'till the end!");
                        Console.WriteLine("You can't fight like this! Try another input. Valid inputs are: [fight/f] [arm/a <item>] [use/u <item>] [inventory/i] and [quit/q]");
                        MethodStore.CheckCases();
                    }
                    else
                    {
                        Console.WriteLine("NOOOOOOOO! How could you! Now you're dead! Stupid! Try this game again...");
                       MethodStore.QuitGame();
                    }
                    break;
                }
            }
        }

        public class Enemy : Character
        {
            public Enemy(string name, float lifepoints, float hitpoints, string information, Room currentLocation)
            {
                this.Name = name;
                this.Lifepoints = lifepoints;
                this.Hitpoints = hitpoints;
                this.Information = information;
                this.CurrentLocation = currentLocation;
            }

            public static void EnemyChangeRoom()
            {
                MethodStore.InteractionCounter = 0;
                List<Room> _allRooms = new List<Room>(Rooms.Values);
                try
                {
                    Random rand = new Random();
                    int randomIndex = rand.Next(_allRooms.Count);
                    Characters["Golem"].CurrentLocation = _allRooms[randomIndex];
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

                foreach (var _character in Characters)
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
                if (_s == Characters["Golem"].CurrentLocation.Name)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class Helper : Character
        {
            public Helper(string name, float lifepoints, float hitpoints, string information, Room currentLocation)
            {
                this.Name = name;
                this.Lifepoints = lifepoints;
                this.Hitpoints = hitpoints;
                this.Information = information;
                this.CurrentLocation = currentLocation;
            }

            public static void Talk()
            {
                Console.WriteLine(Characters["Dragon of the sea"].Information + " I have some good advice for you..." + Environment.NewLine + "In the north you will find the strongest person in this world! At least the strongest enemy." + Environment.NewLine +"Allow me to ask you a question: 'Did you take the chance to slay a Golem yet?'");
                
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

                    case "q":
                    case "quit":
                    MethodStore.QuitGame();
                    break;

                    default:
                    Console.WriteLine("I'm sorry little one... I could not understand you. Please try again and answer with [yes/y] or [no/n].");
                    TalkCases();
                    break;
                }
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

                    case "q":
                    case "quit":
                    MethodStore.QuitGame();
                    break;

                    default:
                    Console.WriteLine("I'm sorry little one... I could not understand you. Please try again and answer with [yes/y] or [no/n].");
                    TalkCases();
                    break;
                }
            }
        }

        public static void CreateCharaters()
        {
            Avatar ForestGodess = new Avatar
            (
            "Godess of the forest",
            1F, 
            0.2F, 
            "I'm the Godess of the forest! I'm your Avatar."+Environment.NewLine+"Our Mission is to free the forest spirits from the tyrannic King of death!",
            Rooms["Silent Wood Glade"]
            );

            Enemy Golem = new Enemy
            (
            "Golem", 
            0.6F, 
            0.1F, 
            "GRRRRRR! Golem... GRRRRRR!", 
            Rooms["Dark Rabbit Hole"]
            );
             Gear Bow = new Gear
            (
                "Bow", "gear", "You can use me to strike an enemy or shoot an arrow!", 0.3F, false
            );
            Golem.CharacterInventory.Add(Bow);

            Enemy DeathKing = new Enemy
            (
            "King of death", 
            1F, 
            0.3F, 
            "GRRRR! I'm the King of death! You Peasant! Weak as ever, you might as well just die!", 
            Rooms["Haunted Valley of Death"]
            );

            Helper Dragon = new Helper
            (
            "Dragon of the sea", 
            1F, 
            1F, 
            "Hiss, huff and puff... Greetings, brave adventurer. I'm the Dragon of the sea! Hiss, huff and puff...",  
            Rooms["Sacred Sea"]
            );

            Items["Bow"] = Bow;

            Characters = new Dictionary<string, Character>();
            Characters["Godess of the forest"] = ForestGodess;
            Characters["Golem"] = Golem;
            Characters["King of death"] = DeathKing;
            Characters["Dragon of the sea"] = Dragon;
        }

        public class Item
        {
            public string Name;
            public string Type;
            public string Information;
            public float Points;
            public bool IsArmed;

            public static void Use(string input)
            {
                Character godess = Characters["Godess of the forest"];
                input = MethodStore.Words[1];
                Item foundItem = godess.CharacterInventory.Find(x => x.Name.ToLower().Contains(input));
                if (foundItem != null)
                {
                    switch (foundItem.Type)
                    {
                        case "Gear":
                        if(foundItem.IsArmed == false)
                        {
                            if (MethodStore.IsFighting == true && MethodStore.Enemy.Lifepoints > 0 && godess.Lifepoints > 0)
                            {
                                godess.Hitpoints =  (float)(Math.Round((godess.Hitpoints + foundItem.Points), 2));
                                Console.WriteLine("You got temporarily stronger with the help of the " + foundItem.Name + ".");
                                Characters["Golem"].Lifepoints = (float)(Math.Round((Characters["Golem"].Lifepoints - godess.Hitpoints), 2));
                                Console.WriteLine("Ouch!!!  Golem's lifepoints: " + Characters["Golem"].Lifepoints);
                                godess.Hitpoints = (float)(Math.Round((godess.Hitpoints - foundItem.Points), 2));
                                godess.Lifepoints = (float)(Math.Round((godess.Lifepoints - MethodStore.Enemy.Hitpoints), 2));
                                Console.WriteLine("You're getting hit!"+ Environment.NewLine + "Oouuuch! Augh!!! Oh, you dirty creature! I'm gonna finish you on the spot!" + Environment.NewLine + "You've got " + godess.Lifepoints + " lifepoints left. Fight him 'till the end!");
                            }
                            else
                                Console.WriteLine("There's no enemy to fight! Try another time.");
                        }
                        else
                            Console.WriteLine("You're already equipped with " + foundItem.Name);
                        break;

                        case "Health":
                            godess.Lifepoints =  (float)(Math.Round((godess.Lifepoints + foundItem.Points), 2));
                            Console.WriteLine("You used the healing item, new lifepoints: " + godess.Lifepoints);
                            godess.CharacterInventory.Remove(foundItem);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid item!");
                }
            }
        }

        public class Health : Item
        {
            public Health(string name, string type, string information, float lifepoints, bool isArmed)
            {
                this.Name = name;
                this.Type = type;
                this.Information = information;
                this.Points = lifepoints;
                this.IsArmed = isArmed;
            }
        }
        public class Gear : Item
        {
            public Gear(string name, string type, string information, float hitpoints, bool isArmed)
            {
                this.Name = name;
                this.Type = type;
                this.Information = information;
                this.Points = hitpoints;
                this.IsArmed = isArmed;
            }

            public static void Arm(string input)
            {
                Character godess = Characters["Godess of the forest"];
                input = MethodStore.Words[1];
                Item foundItem = godess.CharacterInventory.Find(x => x.Name.ToLower().Contains(input));
                if (foundItem != null)
                {
                    switch (foundItem.Type)
                    {
                        case "gear":
                        if(foundItem.IsArmed == false)
                        {
                            godess.Hitpoints =  (float)(Math.Round((godess.Hitpoints + foundItem.Points), 2));
                            foundItem.IsArmed = true;
                            Console.WriteLine("You successfully equipped the " + foundItem.Name + ", new hitpoints: " + godess.Hitpoints);
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
        }
    }
}