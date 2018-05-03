using System;
using System.Collections.Generic;

namespace A4
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new TreeNode<String>();
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
            child1.RemoveChild(grand12);

            root.PrintTree("");                 //String muss mitgegeben werden, am Anfang leer, siehe PrintTree()
            List<TreeNode<String>> lastList = root.FindNode("child1", new List<TreeNode<String>>());
        }

        class TreeNode<T>
        {
            private T _item;  //Person
            private TreeNode<T> _parentNode;
            private List <TreeNode<T>> _children;

            public TreeNode(){
                
            }

            public TreeNode<T> CreateNode(T item){
                TreeNode<T> node = new TreeNode<T>();
                node._item = item;
                return node;
            }
            public TreeNode(T item)
            { 
                _item = item;                                        // Wenn Person root, keine Eltern werden mitgegeben
            } 

            public TreeNode(T item, TreeNode<T> _parentNode)
            { 
                _item = item;          
                _parentNode.AppendChild(this);                      //Person wird als child an AppenChild übergeben
            } 

            public void AppendChild(TreeNode<T> child)
            {
                if(_children == null){                              //Exception wegen null, checken ob null,
                    _children = new List<TreeNode<T>>{child};       //dann neue Liste mit übergebenem child
                }else{
                    _children.Add(child);                           //erstellt Child in Array
                }
                child._parentNode = this;                           //hängt Child an _parentNode, 
            }                                                       //außerhalb if-else da immer parent eingetragen werden muss

            public void RemoveChild(TreeNode<T> child)
            {
               _children.Remove(child);
               //child._parentNode = this;
            }

            public List<TreeNode<T>> FindNode(T search, List<TreeNode<T>> returnList){
               if(_item.Equals(search)){
                   returnList.Add(this);
               }
               if (_children != null){
                   foreach(var child in _children){
                       child.FindNode(search, returnList);
                   }
               }
                return returnList;
            }

            public void PrintTree(String sternchen){                    //public void, damit Code Müller eingehalten wird, String sternchen mitgeben für children
                Console.WriteLine(sternchen + _item.ToString());        //kein return, Console.WriteLine
                if(_children != null ){                                 //null Reference Exception (etwas wurde auf null referenziert), Bedingung !=null
                    foreach(var child in _children){                   
                        child.PrintTree(sternchen+"*");                 // für jedes child nochmal ausführen, rekursiver Aufruf
                    }
                }
            }
        }
    }
}

