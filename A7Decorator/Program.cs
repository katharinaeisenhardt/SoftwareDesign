using System;
using System.Collections.Generic;

namespace A7Decorator
{
    public class Spielfigur
    {
        public virtual void Drohe(){

        }  
    }

    public class Monster : Spielfigur
    {
        public override void Drohe()
        {
            Console.Write("Grrrrr!");
        }
    } 

    class Held : Spielfigur 
    {
        public override void Drohe()
        {
            Console.Write("Weiche zurück!");
        }        
    }

    public class Decorator : Spielfigur
    {
        private Spielfigur _original;

         public Decorator(Spielfigur original)
        {
            _original = original; 
        }
        
        public override void Drohe(){
            _original.Drohe();
        }  
    }

    // Decorator
    class ErkaelteteFigur : Decorator
    {
        public ErkaelteteFigur(Spielfigur original)
        : base (original){}

        public override void Drohe()
        {
            base.Drohe();
            Console.Write(" Hust!");
        }
    }

    class HeisereFigur : Decorator
    {
        public HeisereFigur(Spielfigur original)
        : base (original){}
        
        public override void Drohe()
        {
            Console.Write("Räusper...");
            base.Drohe();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Spielfigur> figuren = new List<Spielfigur>();

            figuren.Add(new Monster());
            figuren.Add(new Held());
            figuren.Add(new ErkaelteteFigur(new Held()));
            figuren.Add(new ErkaelteteFigur(new ErkaelteteFigur(new Monster())));
            figuren.Add(new HeisereFigur(new Monster()));
            figuren.Add(new ErkaelteteFigur(new HeisereFigur(new Held())));

            foreach(var spielfigur in figuren)
            {
                spielfigur.Drohe();
                Console.WriteLine();
            }
        }
    }
}