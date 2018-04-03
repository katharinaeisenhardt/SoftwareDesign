using System;

namespace A1
{
    class Program
    {
        static string[] subjects = { "Harry", "Hermine", "Ron", "Hagrid", "Snape", "Dumbledore" };/*Worte als literale Initialisierung in drei Arrays */
        static string[] verbs = { "braut", "liebt", "studiert", "hasst", "zaubert", "zerstört" };
        static string[] objects = { "Zaubertränke", "den Grimm", "Lupin", "Hogwards", "die Karte des Rumtreibers", "Dementoren" };
        static string subj;/*Zeilen bestehen aus subj+verb+obj */
        static string verb;
        static string obj;

        static void Main(string[] args)
        {
            string[] verse = new string [6];    /*einzelnen Verse in neuem Array zwischenspeichern, mind. 5 Zeilen */
            for (int i=0; i < verse.Length; i++){   /*Array durchlaufen, damit alle Zeilen erstellt werden */
                GetVerse();                             /*Methodenaufruf in der Main */
                verse[i] = subj + " " + verb + " " + obj;   /*Zeilen bestehen aus subj+verb+obj */
            }
            foreach(string zeile in verse){  /*foreach durchläuft die Elemente des arrays string[]verse  */
                Console.WriteLine(zeile);    /*Zeilen in der Konsole ausgeben lassen */
            }
        }

        public static void GetVerse(){  /*Bei jedem Programmlauf sollen die Worte zufällig kombiniert werden */
            Random rndm = new Random();   /*Create Random instance */
            int s = rndm.Next(0, subjects.Length); /*fetch random string int s = (arraylist)random instance.Next(from 0, to arraylist.length) */
            int v = rndm.Next(0, verbs.Length);
            int o = rndm.Next(0, objects.Length);

            while(subjects[s]== "verwendet"){   /*Bedingung: random string s aus array subjects wurde schon mal verwendet == true */
                s = rndm.Next(0, subjects.Length);  /*dann suche den nächsten random string s aus dem array subjects */
            }                                       /*falls Bedingung == false (noch nicht verwendet), weiter mit dem Programmfluss */
            while(verbs[v]== "verwendet"){
                v = rndm.Next(0, verbs.Length);
            }
            while(objects[o]== "verwendet"){
                o = rndm.Next(0, objects.Length);
            }

            subj = subjects[s];     /*subj = random string s aus dem array subjects, */
            verb = verbs[v];        /*erst am Ende definieren, sonst wird random string direkt als "verwendet" ausgegeben(?!) */
            obj = objects[o];

            subjects[s] = "verwendet";  /*nach dem Erzeugen des endgültigen random string s, ihn = verwendet setzen, */
            verbs[v] = "verwendet";     /*für Prüfung der while-Bedingung der nächsten Zeile (keine Wiederholungen), */
            objects[o] = "verwendet";   /*erst am Ende definieren, sonst wird random string direkt = verwendet gesetzt */
        }
    }
}
