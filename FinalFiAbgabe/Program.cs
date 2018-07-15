using System;
using System.Collections.Generic;

namespace FinalFiAbgabe
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodStore.LoadGameData();
            for (;;)
            {
                MethodStore.CheckCharactersInRoom(); 
                MethodStore.InputPrompt();
            } 
        }
    }
}