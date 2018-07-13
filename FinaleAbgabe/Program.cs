using System;
using System.Collections.Generic;

namespace FinaleAbgabe
{
    class Program
    {
        static void Main(string[] args)
        {

            /*    ItemSetup.createItem();
               foreach(var item in ItemSetup.gear)
               {
                   Console.WriteLine(Item.name + Item.type + Item.infomation + Item.hitpoints)
               }
               foreach(var item in ItemSetup.health){
                   Console.WriteLine(Item.name + Item.type + Item.infomation + Item.lifepoints)
               } */

            /* MethodStore.SplitInput("hallo Maria!"); */ 
          
            MethodStore.GameIntroduction();
            for (;;)
            {
                MethodStore.CheckEnemy();
            }
        }
    }
}
