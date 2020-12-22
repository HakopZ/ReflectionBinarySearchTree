using System;

namespace ReflectionBinarySearchTree
{
    class CompareBy : Attribute
    {
    }
    class Animal
    {
        [CompareBy]
        public string Name { get; set; }

        public bool IsExtinct { get; set; }
    }

    class Giraffe : Animal
    {
        [CompareBy]
        public int NeckLength { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Binary Tree with Add
            //Figure out if the type has an IComparable or function for Comparable
            //***Use Reflection***
            Console.WriteLine("Hello World!");

            var bst = new BinaryTree<Giraffe>();
        }
    }
}
