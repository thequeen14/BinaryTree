using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Node<T>
    {
        private T _contents;
        private List<Node<T>> _neighbors = null;

        public Node() { }
        public Node(T data) : this(data, null) { }
        public Node(T data, List<Node<T>> neighborsList)
        {
            _contents = data;
            _neighbors = neighborsList;
        }

        public T Value
        {
            get
            {
                return _contents;
            }
            set
            {
                _contents = value;
            }
        }

        public List<Node<T>> Neighbors
        {
            get
            {
                return _neighbors;
            }
            set
            {
                _neighbors = value;
            }
        }

        public override string ToString()
        {
            string allNeghborsValues = String.Empty;
            if (Neighbors != null)
            {
                var neighborsValue = (from vals in Neighbors select vals.Value).ToList();

                if (neighborsValue != null)
                {
                    foreach (object obj in neighborsValue)
                    {
                        allNeghborsValues += obj.ToString() + " ";
                    }
                }
            }
            else
            {
                allNeghborsValues = "no neighbors";
            }

            string valueOfTheNode = String.Empty;
            if (this != null && Value != null)
            {
                valueOfTheNode = Value.ToString();
            }
            else
            {
                valueOfTheNode = "null";
            }

            string result = String.Format("Node value: {0}, Values of neighbors (from left to right): {1}", valueOfTheNode, allNeghborsValues);
            return result;
        }
    }
}
