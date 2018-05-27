using System;
using System.Collections.Generic;

/*public class Auto<PLATZHALTER_FUER_FARBE, PLATZHALTER_FUER_TUEREN>//_Verkauf{   //<> weil Datentyp, nicht Wert mit ()
    public PLATZHALTER_FUER_TUEREN Tueren;
    public double PS;        
    public int Zylinder;
    public double Hubraum;
    public PLATZHALTER_FUER_FARBE Farbe;
}*/

/*public class Auto_Produktion{             // statt copy paste, typ noch nicht klar definieren -> generics
    public double PS;        
    public int Zylinder;
    public double Hubraum;
    public int Farbe;
}*/

/* 
public class List<T>{
    public void Add(T item);   // nimmt 1 Objekt der Klasse T entgegen
}*/

namespace L05Generics
{
    class Program
    {
        static void Main(string[] args)
        { /* 
            //Bestellwesen
            Auto<string, int> meinAUto = new Auto<string>();  //Typ hier definieren, Farbe mit string gekennzeichnet
    
            meinAUto.Farbe = "grau";
            meinAUto.PS = 100;
            meinAUto.Zylinder = 4;
            meinAUto.Hubraum = 2.8;

            //Produktion
            Auto<int, double> einAnderesAuto = new Auto<int>();   //Farbe mit int gekennzeichnet, Schablone mit PLATZHALTER wurde kopiert und durch int ersetzt.
            einAnderesAuto.Farbe = 4711;
            einAnderesAuto.PS = 200;
            einAnderesAuto.Zylinder = 12;
            einAnderesAuto.Hubraum = 4.6;*/

            //int[] meinIntegerArray = new int[10];       //mehrere Instanzen in Array speichern, feste Länge gesetzt
            List<int> meinIntegerContainer = new List<int>();   //für erweiterbare Arrays gibt es Container- bzw Collections-Klassen -> siehe using System.Collections.Generic
            meinIntegerContainer.Add(1231);
            meinIntegerContainer.Add(1345);                 
            meinIntegerContainer.Add(4561);
            meinIntegerContainer.Add(1567);
            meinIntegerContainer.Add(1234);
            meinIntegerContainer.Add(65431);
            meinIntegerContainer.Add(45671);
            meinIntegerContainer.Add(1543);
            meinIntegerContainer.Add(1234);
            //meinIntegerContainer[9] = 2341;                   //nachträglich können nicht mehr als 10 Einträge hinzugefügt werden
        
            meinIntegerContainer.Add(345213);
        }
    }
}
