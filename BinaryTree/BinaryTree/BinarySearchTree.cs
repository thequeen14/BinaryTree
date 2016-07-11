using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinarySearchTree<T> : BinaryTree<T> where T : IComparable
    {
        public void Add(T containsToAdd)
        {
            BinaryTreeNode<T> nodeToAdd = new BinaryTreeNode<T>(containsToAdd);
            BinaryTreeNode<T> currentNode = RootNode;
            BinaryTreeNode<T> parentOfNodeToAdd = null;
            int comparisonResult;

            while (currentNode != null)
            {
                comparisonResult = currentNode.Value.CompareTo(containsToAdd);

                if (comparisonResult == 0)
                {
                    return;
                }
                else if (comparisonResult < 0)
                {
                    parentOfNodeToAdd = currentNode;
                    currentNode = currentNode.Right;
                }
                else if (comparisonResult > 0)
                {
                    parentOfNodeToAdd = currentNode;
                    currentNode = currentNode.Left;
                }
            }

            if (parentOfNodeToAdd == null)
            {
                RootNode = nodeToAdd;
            }
            else
            {
                comparisonResult = parentOfNodeToAdd.Value.CompareTo(containsToAdd);

                if (comparisonResult > 0)
                {
                    parentOfNodeToAdd.Left = nodeToAdd;
                }
                else
                {
                    parentOfNodeToAdd.Right = nodeToAdd;
                }
            }
        }

        public bool Remove(T containsToRemove)
        {
            if (RootNode != null)
            {
                BinaryTreeNode<T> currentNode = RootNode;
                BinaryTreeNode<T> parentOfNodeToRemove = null;
                int comparisonResult = currentNode.Value.CompareTo(containsToRemove);

                while (comparisonResult != 0)
                {
                    if (comparisonResult > 0)
                    {
                        parentOfNodeToRemove = currentNode;
                        currentNode = currentNode.Left;
                    }
                    else if (comparisonResult < 0)
                    {
                        parentOfNodeToRemove = currentNode;
                        currentNode = currentNode.Right;
                    }

                    if (currentNode == null)
                    {
                        return false;
                    }
                    else
                    {
                        comparisonResult = currentNode.Value.CompareTo(containsToRemove);
                    }
                }

                //If the current node has no right child, current's left replaces current
                if (currentNode.Right == null)
                {
                    if (parentOfNodeToRemove == null)
                    {
                        RootNode = currentNode.Left;
                    }
                    else
                    {
                        comparisonResult = parentOfNodeToRemove.Value.CompareTo(currentNode.Value);
                        if (comparisonResult > 0)
                        {
                            parentOfNodeToRemove.Left = currentNode.Left;
                        }
                        else if (comparisonResult < 0)
                        {
                            parentOfNodeToRemove.Right = currentNode.Left;
                        }
                    }
                }
                //If the current's right has no left child, current's right replaces current
                else if (currentNode.Right.Left == null)
                {
                    currentNode.Right.Left = currentNode.Left;

                    if (parentOfNodeToRemove == null)
                    {
                        RootNode = currentNode.Right;
                    }
                    else
                    {
                        comparisonResult = parentOfNodeToRemove.Value.CompareTo(currentNode.Value);
                        if (comparisonResult > 0)
                        {
                            parentOfNodeToRemove.Left = currentNode.Right;
                        }
                        else if (comparisonResult < 0)
                        {
                            parentOfNodeToRemove.Right = currentNode.Right;
                        }
                    }
                }
                //If the current's right has a left child, current's right's leftmost replaces current
                else
                {
                    BinaryTreeNode<T> leftmostChild = currentNode.Right.Left;
                    BinaryTreeNode<T> parentOfTheLeftmost = currentNode.Right;

                    while (leftmostChild.Left != null)
                    {
                        parentOfTheLeftmost = leftmostChild;
                        leftmostChild = leftmostChild.Left;
                    }

                    parentOfTheLeftmost.Left = leftmostChild.Right;

                    leftmostChild.Left = currentNode.Left;
                    leftmostChild.Right = currentNode.Right;

                    if (parentOfTheLeftmost == null)
                    {
                        RootNode = leftmostChild;
                    }
                    else
                    {
                        comparisonResult = parentOfTheLeftmost.Value.CompareTo(currentNode.Value);
                        if (comparisonResult > 0)
                        {
                            parentOfTheLeftmost.Left = leftmostChild;
                        }
                        else if (comparisonResult < 0)
                        {
                            parentOfTheLeftmost.Right = leftmostChild;
                        }
                    }
                }

                return true;
            }
            else
            {
                return false; //nothing to delete, the tree is empty
            }
        }
    }
}
