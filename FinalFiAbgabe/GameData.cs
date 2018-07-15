using System;
using System.Collections.Generic;

namespace FinalFiAbgabe
{
    public class GameData
    {
        public static Dictionary<string, Room> Rooms;
        public static Dictionary<string, Character> Characters;
        public static Dictionary<string, Item> Items = new Dictionary<string, Item>();

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
                "Silent Glade",
                "You just arrived at the Silent Glade..."
            );
            Gear Arrow = new Gear
            (
            "Arrow","gear","info",0.1F,false
            );
            Health Herb = new Health
            (
            "Herb","health","info",0.1F,false
            );
            Glade.RoomInventory.AddRange(new List<Item>(){Arrow, Herb});

            Room StoneQuarry = new Room
            (
                "Brachial Stone Quarry",
                "You just arrived at the Brachial Stone Quarry..."
            );
            Gear Stone = new Gear
            (
            "Rock","gear","info",0.05F,false
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
            "Potion","health","info",0.3F, false
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
        }

        public static void CreateCharaters()
        {
            Avatar ForestGodess = new Avatar
            (
            "Godess of the forest",
            1F, 
            0.2F, 
            "I'm the " +  Characters["Godess of the forest"].Name + " I'm your Avatar."+Environment.NewLine+"Our Mission is to free the forest spirits from the tyrannic Deathking!",
            Rooms["Silent Wood Glade"]
            );

            Enemy Golem = new Enemy
            (
            "Golem", 
            0.6F, 
            0.1F, 
            "GRRRRRR! "+ Characters["Golem"].Name + " GRRRRRR!", 
            Rooms["Dark Rabbit Hole"]
            );
             Gear Bow = new Gear
            (
                "Bow", "Gear", "info", 0.3F, false
            );
            Golem.CharacterInventory.Add(Bow);

            Enemy DeathKing = new Enemy
            (
            "King of death", 
            1F, 
            0.3F, 
            "GRRRR! I'm the " + Characters["King of death"].Name + "! You Peasant! Weak as ever, you might as well just die!", 
            Rooms["Haunted Valley of Death"]
            );

            Helper Dragon = new Helper
            (
            "Dragon of the sea", 
            1F, 
            1F, 
            "Hiss, huff and puff!!! Greetings, brave adventurer. I'm the " +Characters["Dragon of the sea"].Name +". Hiss, huff and puff!!!",  
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
        }
    }
}