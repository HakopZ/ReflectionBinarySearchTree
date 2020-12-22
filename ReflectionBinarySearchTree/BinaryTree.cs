using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
namespace ReflectionBinarySearchTree
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node()
        {}
        public Node(T value)
        {
            Value = value;
        }
    }

    public class BinaryTree<T>
    {
        public Node<T> Head;
        public int Count;

        public Func<T, T, int> comparer;

        public BinaryTree()
        {
            Head = new Node<T>();
            Count = 0;
            var type = typeof(T);
            if(!GetComparer(type))
            {
                if(!GetComparer(type.BaseType))
                {
                    throw new Exception("No Comparable variables");
                }
            }
            throw new NotImplementedException("Not done");
            

        }
        public void Add(T value)
        {
            if(Count == 0)
            {
                Head = new Node<T>(value);
            }
            else
            {
                
            }
        }
        private Node<T> add(T value)
        {
            return default; 
        }
        bool GetComparer(Type type)
        {
            var fields = type.GetFields().Where(x => x.CustomAttributes.Count() > 0);
            var comp = fields.Where(x => Attribute.IsDefined(x, typeof(CompareBy)));
            if (comp.Count() > 1)
            {
                throw new Exception("Too many Compare By Attributes in One Class");
            }
            if (comp.Count() == 0)
            {
                return false;
            }
            var variableToCompare = comp.First();
            if (variableToCompare.FieldType is IComparable<T>)
            {
                return true;
            }
            else
            {
                throw new NotSupportedException("Does not support other than IComparable");
            }
        }
    }
}
