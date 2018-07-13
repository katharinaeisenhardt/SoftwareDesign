using System;
using System.Collections.Generic;

namespace FinalFiAbgabe
{
    class MethodStore
    {
        public static string [] _words;
        public static bool _fightCase;

        public static void gameIntroduction()
        {
            string intro = "Welcome adventurer! You just entered the sacred forest of Dzed..." /*+ GameData.characters["Godess of the forest"].information*/;
            Console.WriteLine(intro);
        }

        public static void TalkCases()
        {
            string uinput = Console.ReadLine().ToLower();
            switch(uinput)
            {
                case "y":
                case "yes":
                Console.WriteLine("Excellent, my mighty warrior. Go now and fulfill your fate on the darkest path in the north!");
                break;

                case "n":
                case "no":
                Console.WriteLine("Ohhh little one! You might want to go back and equip yourself to be the strongest Golemslayer ever...");
                break;

                default:
                Console.WriteLine("I'm sorry little one... I could not understand you. Please try again and answer with [yes/y] or [no/n].");
                TalkCases();
                break;
            }
        }

        public static void CheckCases()
        {
            var readline = Console.ReadLine().ToLower();
            SplitInput(readline);
            CheckNonFightCases(_words);
        }

        public static Array SplitInput(string input)
        {
            _words = input.Split(' ');
            /*for (int i = 0; i < words.Length; i ++) 
            Console.WriteLine(words[i]);*/
            return _words;
        }

        public static void CheckFightCases(string [] words)
        {
            _words = words;
            _fightCase = true;

            switch(words[0])
            {
                case "u":
                case "use":
                //Use();
                break;

                case "a":
                case "arm":
                //Arm();
                break;

                case "i":
                case "inventory":
                //DisplayInventory();
                break;

                case "q":
                case "quit":
                //QuitGame();
                break;

                //if enemy in raum 
                /*default:
                if()
                {
                    
                }
                _fightCase = false;
                Console.WriteLine("You can't fight like this! Try another input. Valid inputs are: [arm/a <item>] [use/u <item>] [inventory/i] [quit/q]");
                break;

                /*else*/
                default:
                _fightCase = false; //-> wenn if else works, kein bool benötigt
                CheckNonFightCases(words);
                break;
            } 
        }

        public static void CheckNonFightCases(string [] words)
        {
            _words = words;

            switch(words[0])
            {
                case "h":
                case "help":
                Help();
                break;

                /*case "l":
                case "look":
                //Look();
                break;

                case "t":
                case "take":
                //Take(words[1]);
                break;

                case "d":
                case "drop":
                //Drop(words[1]);
                break;
                 */
                case "n":
                case "north":
                /*if(GameData.characters["Godess of the forest"]._currentLocation.north != null)
                {
                    Roomchange();
                    GameData.Character.RoomChangeCounter ++;
                    GameData.characters["Godess of the forest"]._currentLocation =GameData.characters["Godess of the forest"]._currentLocation.north;
                    GameData.Room.RoomDescription(GameData.characters["Godess of the forest"]._currentLocation);
                }
                else
                {
                    Console.WriteLine("What to do?! There's a dead end");
                }*/
                break;

                case "e":
                case "east":
                case "s":
                case "south":
                case "w":
                case "west":
                
               
 
                default:
                Console.WriteLine("Oh Lord... You used some invalid input. Take another shot!");
                //CheckCases();
                break;
            } 
        }

        public static void Help()
        {
            Console.WriteLine("You can use the following commands:"+ Environment.NewLine);
            foreach(var command in GameData.commands){
                Console.WriteLine(command);
            }
        }
    }
}