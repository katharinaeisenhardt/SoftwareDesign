using System;
using System.Collections.Generic;

namespace FinaleAbgabe
{
    public class GameData
    {
        public static List<string> commands = new List<string>
        {
            "[help/h]   [look/l]   [inventory/i]",
            "[take/t <item>]   [drop/d <item>]   [arm/a <item>]   [use/u <item>]",
            "[move/m <direction>]",
            "[quit/q]"
        };

        public static Dictionary<string, Room> rooms;

        public class Room
        {
            public string _name;
            public string _information;
            public Room north;
            public Room east;
            public Room south;
            public Room west;

            public Room(string name, string information)
            {
                this._name = name;
                this._information = information;
            }

            public static void RoomDescription(Room room)
            {
                room = GameData.characters["Godess of the forest"]._currentLocation;
                Console.Write(room._information);
            }
        }

        public static void CreateRooms()
        {
            Room Glade = new Room
            (
                "Silent Glade",
                "You just arrived at the Silent Glade..."
            );

            Room StoneQuarry = new Room
            (
                "Brachial Stone Quarry",
                "You just arrived at the Brachial Stone Quarry..."
            );

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

            Room DeathValley = new Room
            (
                "Haunted Valley of Death",
                "You just entered the Haunted Valley of Death..."
            );
 
            Glade.north = StoneQuarry;

            StoneQuarry.west = RabbitHole;
            StoneQuarry.east = Sea;

            RabbitHole.east = StoneQuarry;
            RabbitHole.south = Glade;

            Sea.north = DeathValley;
            Sea.west = StoneQuarry;

            DeathValley.south = Sea;

            rooms = new Dictionary<string, Room>();
            rooms["Silent Glade"] = Glade;
            rooms["Brachial Stone Quarry"] = StoneQuarry;
            rooms["Dark Rabbit Hole"] = RabbitHole;
            rooms["Sacred Sea"] = Sea;
            rooms["Haunted Valley of Death"]= DeathValley;
        }

        public class Character
        {
            public string _name;
            public float _lifepoints;
            public float _hitpoints;
            public string _information;
            public Room _currentLocation;
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
        public static Dictionary<string, Character> characters;
        public static void CreateCharaters()
        {

            Avatar ForestGodess = new Avatar
            (
            "Godess of the forest",
            1F,
            0.2F, 
            "I'm the Godess of the forest. I'm your Avatar. Our Mission is to free the forest spirits from the tyrannic Deathking!", 
            rooms["Silent Glade"]
            );

            Enemy Golem = new Enemy
            (
            "Golem", 
            0.6F, 
            0.15F, 
            "GRRRRRR!", 
            rooms["Dark Rabbit Hole"]
            );

            Enemy DeathKing = new Enemy
            (
                "King of death",
                1F,
                0.3F,
                "GRRRR! I'm the King of death! You Peasant! Weak as ever, you might as well just die!",
                rooms["Haunted Valley of Death"]
            );

            Helper Dragon = new Helper
            (
            "Dragon of the sea", 
            1F, 
            1F, 
            "I'm the Dragon of the sea", 
            rooms["Sacred Sea"]
            );

            
            characters = new Dictionary<string, Character>();
            characters["Godess of the forest"] = ForestGodess;
            characters["Golem"] = Golem;
            characters["King of death"] = DeathKing;
            characters["Dragon of the sea"] = Dragon;
        }
    }
}