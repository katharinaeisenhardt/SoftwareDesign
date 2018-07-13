using System;
using System.Collections.Generic;

namespace FinaleAbgabe
{

    public class Item
    {
        public string name;
        public string type;
        public string information;
    }


    public class Health : Item
    {
        public float lifepoints;
        public static void use()
        {
            //adds lifepoints
        }
    }
    public class Gear : Item
    {
        public float hitpoints;
        public bool isArmed;
    }

    public class Potion : Health
    {
    }

    public class Herb : Health
    {
    }

    public class Arrow : Gear
    {
    }

    public class Bow : Gear
    {
    }

    public class Stones : Gear
    {
    }

    public class ItemSetup
    {
        public static List<Gear> gear = new List<Gear>();
        public static List<Health> health = new List<Health>();
        public static void createItem()
        {
            Gear Arrow = new Gear
            {
            name = "Arrow",
            type = "gear",
            information = "info",
            hitpoints = 0.1F,
            isArmed = false,
            };
            gear.Add(Arrow);
           
            Health Potion = new Health
            {
            name = "Potion",
            type = "health",
            information = "info",
            lifepoints = 0.1F,
            };
            health.Add(Potion);
            
        }
    }
}