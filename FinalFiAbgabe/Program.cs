﻿using System;
using System.Collections.Generic;

namespace FinalFiAbgabe
{
    class Program
    {
        static void Main(string[] args)
        {
            /*foreach(var item in ItemSetup.gear){
                Console.WriteLine(item.name + "   " + item.type + "   "+ item.armed + "   " + item.hitpoints + "   " + item.information);
            }
            foreach(var item in ItemSetup.health){
                Console.WriteLine(item.name + "   " + item.type + "   "+ item.placeholder + "   " + item.lifepoints + "   " + item.information);
            }*/
            
            GameData.CreateRooms();
            GameData.CreateCharacters();
            //MethodStore.gameIntroduction();
           // MethodStore.CheckCases();
            
            //MethodStore.CheckNonFightCases(MethodStore._words);
        }
    }
}
