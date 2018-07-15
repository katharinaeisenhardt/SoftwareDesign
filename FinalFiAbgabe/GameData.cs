using System;
using System.Collections.Generic;

namespace FinalFiAbgabe
{
    public class GameData
    {
        public static List<string> Commands = new List<string>
        {
            "[help/h]   [look/l]   [inventory/i]",
            "[take/t <item>]   [drop/d <item>]   [arm/a <item>]   [use/u <item>]",
            "[move/m <direction>]",
            "[quit/q]"
        };

        public static Dictionary<string, Room> Rooms;
        public static Dictionary<string, Character> Characters;
        //public static Dictionary<string, Item> items;

        public class Room
        {
            public string _name;
            public string _information;
            public Room north;
            public Room east;
            public Room south;
            public Room west;
            public List<Item> _roomInventory = new List<Item>();

            public Room(string name, string information)
            {
                this._name = name;
                this._information = information;
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
            Glade._roomInventory.AddRange(new List<Item>(){Arrow, Herb});

            Room StoneQuarry = new Room
            (
                "Brachial Stone Quarry",
                "You just arrived at the Brachial Stone Quarry..."
            );
            Gear Stone = new Gear
            (
            "Rock","gear","info",0.05F,false
            );
            StoneQuarry._roomInventory.Add(Stone);

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
            Sea._roomInventory.Add(Potion);

            Room DeathValley = new Room
            (
                "Haunted Valley of Death",
                "You just entered the Haunted Valley of Death..."
            );
 
            Glade.north = StoneQuarry;

            StoneQuarry.east = Sea;
            StoneQuarry.south = Glade;
            StoneQuarry.west = RabbitHole;

            RabbitHole.east = StoneQuarry;
            RabbitHole.south = Glade;

            Sea.north = DeathValley;
            Sea.west = StoneQuarry;

            DeathValley.south = Sea;

            Rooms = new Dictionary<string, Room>();
            Rooms["Silent Wood Glade"] = Glade;
            Rooms["Brachial Stone Quarry"] = StoneQuarry;
            Rooms["Dark Rabbit Hole"] = RabbitHole;
            Rooms["Sacred Sea"] = Sea;
            Rooms["Haunted Valley of Death"] = DeathValley;
        }

        public class Character
        {
            public string _name;
            public float _lifepoints;
            public float _hitpoints;
            public string _information;
            public Room _currentLocation;
            public List<Item> _characterInventory = new List <Item>();
        }

        public class Enemy : Character
        {
            public Enemy(string name, float lifepoints, float hitpoints, string information, Room currentLocation)
            {
                this._name = name;
                this._lifepoints = lifepoints;
                this._hitpoints = hitpoints;
                this._information = information;
                this._currentLocation = currentLocation;
            }
        }

        public class Avatar : Character
        {
            public Avatar(string name, float lifepoints, float hitpoints, string information, Room currentLocation)
            {
                this._name = name;
                this._lifepoints = lifepoints;
                this._hitpoints = hitpoints;
                this._information = information;
                this._currentLocation = currentLocation;
            }
        }

        public class Helper : Character
        {
            public Helper(string name, float lifepoints, float hitpoints, string information, Room currentLocation)
            {
                this._name = name;
                this._lifepoints = lifepoints;
                this._hitpoints = hitpoints;
                this._information = information;
                this._currentLocation = currentLocation;
            }
        }

        public static void CreateCharaters()
        {
            Avatar ForestGodess = new Avatar
            (
            "Godess of the forest",
            1F, 
            0.2F, 
            "I'm the " +  Characters["Godess of the forest"]._name + " I'm your Avatar."+Environment.NewLine+"Our Mission is to free the forest spirits from the tyrannic Deathking!",
            Rooms["Silent Wood Glade"]
            );

            Enemy Golem = new Enemy
            (
            "Golem", 
            0.6F, 
            0.1F, 
            "GRRRRRR! "+ Characters["Golem"]._name + " GRRRRRR!", 
            Rooms["Dark Rabbit Hole"]
            );
             Gear Bow = new Gear
            (
                "Bow", "Gear", "info", 0.3F, false
            );
            Golem._characterInventory.Add(Bow);

            Enemy DeathKing = new Enemy
            (
            "King of death", 
            1F, 
            0.3F, 
            "GRRRR! I'm the " + Characters["King of death"]._name + "! You Peasant! Weak as ever, you might as well just die!", 
            Rooms["Haunted Valley of Death"]
            );

            Helper Dragon = new Helper
            (
            "Dragon of the sea", 
            1F, 
            1F, 
            "Hiss, huff and puff!!! Greetings, brave adventurer. I'm the " +Characters["Dragon of the sea"]._name +". Hiss, huff and puff!!!",  
            Rooms["Sacred Sea"]
            );

            Characters = new Dictionary<string, Character>();
            Characters["Godess of the forest"] = ForestGodess;
            Characters["Golem"] = Golem;
            Characters["King of death"] = DeathKing;
            Characters["Dragon of the sea"] = Dragon;
        }

        public class Item
        {
            public string _name;
            public string _type;
            public string _information;
            public float _points;
            public bool _isArmed;
        }

        public class Health : Item
        {
            public Health(string name, string type, string information, float lifepoints, bool isArmed)
            {
                this._name = name;
                this._type = type;
                this._information = information;
                this._points = lifepoints;
                this._isArmed =isArmed;
            }
        }
        public class Gear : Item
        {
            public Gear(string name, string type, string information, float hitpoints, bool isArmed)
            {
                this._name = name;
                this._type = type;
                this._information = information;
                this._points = hitpoints;
                this._isArmed = isArmed;
            }
        }
    }
}