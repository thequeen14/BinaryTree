using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BinaryTree;

namespace BinaryTreeTest
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void NodeConstructorsTest()
        {
            Node<int> testNode = new Node<int>(0);
            string checkResult = testNode.ToString();
            string expectedResult = "Node value: 0, Values of neighbors (from left to right): no neighbors";

            Assert.AreEqual(expectedResult, checkResult);

            List<Node<int>> testNeighbors = new List<Node<int>>
            {
                new Node<int>(2),
                new Node<int>(3),
                new Node<int>(4)
            };

            Node<int> testNode2 = new Node<int>(5, testNeighbors);
            string checkResult2 = testNode2.ToString();
            string expectedResult2 = "Node value: 5, Values of neighbors (from left to right): 2 3 4 ";

            Assert.AreEqual(expectedResult2, checkResult2);
        }

        [TestMethod]
        public void NodeGetSetValueTest()
        {
            Node<int> testNode = new Node<int>();
            testNode.Value = 123;

            Assert.AreEqual(123, testNode.Value);
        }

        [TestMethod]
        public void NodeNeighborsGetSetTest()
        {
            Node<int> testNode = new Node<int>(1);
            List<Node<int>> testNeighbors = new List<Node<int>>
            {
                new Node<int>(2),
                new Node<int>(3),
                new Node<int>(4)
            };
            testNode.Neighbors = testNeighbors;
            string expectedResult = "Node value: 1, Values of neighbors (from left to right): 2 3 4 ";

            Assert.AreEqual(expectedResult, testNode.ToString());
        }

        [TestMethod]
        public void BinaryTreeCreateTest()
        {
            var testBinaryRootNode = new BinaryTreeNode<int>(1);
            var testBinaryTree = new BinaryTree<int>(testBinaryRootNode);
            string expectedResult = "Node value: 1, Values of neighbors (from left to right): no neighbors";
            string checkResult = testBinaryTree.RootNode.ToString();

            Assert.AreEqual(expectedResult, checkResult);
        }
    }
}
