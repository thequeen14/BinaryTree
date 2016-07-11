using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTree<T>
    {
        private BinaryTreeNode<T> _rootNode;

        public BinaryTreeNode<T> RootNode
        {
            get
            {
                return _rootNode;
            }

            set
            {
                _rootNode = value;
            }
        }

        public BinaryTree()
        {
            RootNode = null;
        }

        public BinaryTree(BinaryTreeNode<T> setAsRootNode)
        {
            RootNode = setAsRootNode;
        }

        public void Clear()
        {
           RootNode = null;
        }
    }
}
