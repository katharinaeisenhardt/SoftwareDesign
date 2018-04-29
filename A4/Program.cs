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

            Console.WriteLine(root.PrintTree());
        }

        class TreeNode<T>
        {
            private T _item;  //Person
            private TreeNode<T> _parentNode;
            private List <TreeNode<T>> _children = new List<TreeNode<T>>();

            public TreeNode(){
                
            }

            public TreeNode<T> CreateNode(T item){
                TreeNode<T> node = new TreeNode<T>();
                node._item = item;
                return node;
            }
            public TreeNode(T item)
            { 
                _item = item;          // Wenn Person root, keine Eltern werden mitgegeben
            } 

            public TreeNode(T item, TreeNode<T> _parentNode)
            { 
                _item = item;          
                _parentNode.AppendChild(this);  //Person wird als child an AppenChild übergeben
            } 

            public void AppendChild(TreeNode<T> child)
            {
                _children.Add(child);           //erstellt Child in Array
                child._parentNode = this;       // hängt Child an _parentNode
            } 

            public void RemoveChild(TreeNode<T> child)
            {
               _children.Remove(child);
               //child._parentNode = this;
            }

            public String PrintTree(){
                return _item.ToString();
            }
        }
    }
}
