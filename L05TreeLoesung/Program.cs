using System;
using System.Collections.Generic;

class Tree<PLATZHALTER>{  //es gibt den Platzhalter
    public TreeNode<PLATZHALTER> CreateNode(PLATZHALTER wert){  //Platzhalter wird verwendet
        TreeNode<PLATZHALTER> retWert = new TreeNode<PLATZHALTER>();  // erzeugt neuen Knoten
        retWert.Nutzdaten = wert;                                      // weist nutzdaten zu?
        return retWert;
    }
}

class TreeNode<PLATZHALTER>{            
    public PLATZHALTER Nutzdaten; //TreeNode<PLATZHALTER> hat Nutzdaten
    public List<TreeNode<PLATZHALTER>> KinderListe = new List<TreeNode<PLATZHALTER>>();  //Klasse wird erzeugt beim Verwenden, neue leere Liste wird initialisiert
    public void AppendChild(TreeNode<PLATZHALTER> child){
        KinderListe.Add(child);                    // übergebenes child wird in die KinderListe eingetragen
    }
}

namespace L05TreeLoesung
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<String>();
            var root = tree.CreateNode("root");
            var child1 = tree.CreateNode("child1");
            var child2 = tree.CreateNode("child1");
            root.AppendChild(child1);
            root.AppendChild(child2);
            var grand11 = tree.CreateNode("grand11");
            var grand12 = tree.CreateNode("grand12");
            var grand13 = tree.CreateNode("grand13");
            child1.AppendChild(grand11);
            child1.AppendChild(grand12);
            child1.AppendChild(grand13);
            var grand21 = tree.CreateNode("grand21");
            child2.AppendChild(grand21);
            //child1.RemoveChild(grand12);
       
        }
    }
}
