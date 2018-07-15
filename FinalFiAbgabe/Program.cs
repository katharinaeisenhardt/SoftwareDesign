using System;
using System.Collections.Generic;

namespace FinalFiAbgabe
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodStore.GameIntro();
            for (;;)
            {
                MethodStore.CheckCharacters(); 
                MethodStore.CheckCases();
            } 
        }
    }
}