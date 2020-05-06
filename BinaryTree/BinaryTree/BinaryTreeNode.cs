using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTreeNode<T> : Node<T>
    {
        public BinaryTreeNode() { }
        public BinaryTreeNode(T data) : base(data, null) { }
        public BinaryTreeNode(T data, Node<T> rightNeighbor, Node<T> leftNeighbor)
        {
            Value = data;
            Neighbors = new List<Node<T>>(2);
            Neighbors.Add(leftNeighbor);
            Neighbors.Add(rightNeighbor);
        }

        public BinaryTreeNode<T> Left
        {
            get
            {
                if (Neighbors.ElementAt(0) != null)
                {
                    return (BinaryTreeNode<T>)Neighbors.ElementAt(1);
                }
                else
                {
                    //here is the epic change
                    return new BinaryTreeNode<T>();
                    //return null;
                }
            }
            set
            {
                if (this.Neighbors == null)
                {
                    Neighbors = new List<Node<T>>(2);
                    Neighbors.Add(value);
                }
                else
                {
                    Neighbors.Insert(0, value);
                }
            }
        }

        public BinaryTreeNode<T> Right
        {
            get
            {
                if (this.Neighbors.ElementAt(1) != null)
                {
                    return (BinaryTreeNode<T>)Neighbors.ElementAt(1);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (this.Neighbors == null)
                {
                    Neighbors = new List<Node<T>>(2);
                    Neighbors.Add(null); //so the null element would be "the left one" and the 1st - "the right one"
                    Neighbors.Add(value);
                }
                else
                {
                    Neighbors.Insert(1, value);
                }
            }
        }
    }
}
