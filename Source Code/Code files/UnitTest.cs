using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CollectiveInfluenceAlgorithm;

namespace Test
{
    [TestClass]
    public class UnitTest
    {
        // Source: https://msdn.microsoft.com/en-us/library/ms182532.aspx
        // Make sure you run your tests on the same CPU architecture

        [TestInitialize]
        public void Initialize()
        {
            Network.testClear();
            string testFilePath = @"C:\Users\Jeroen\Documents\Huge_data\TestFile.txt";
            Network.testReadTextFile(testFilePath);
        }

        [TestMethod]
        public void readTextFileTest()
        {
            Node node = Network.getNode(3);

            Assert.AreEqual(14, Network.testGetSize());
            Assert.AreEqual(3, node.getNodeID());
            Assert.AreEqual(2, node.getDegree());
        }

        [TestMethod]
        public void BFSDBallTest()
        {
            Node node3 = Network.getNode(3);
            Queue<int> testQueue3Depth1 = Network.breadthFirstSearchDerivateBall(node3, 1);
            Queue<int> testQueue3Depth2 = Network.breadthFirstSearchDerivateBall(node3, 2);
            Queue<int> testQueue3Depth3 = Network.breadthFirstSearchDerivateBall(node3, 3);

            Node node9 = Network.getNode(9);
            Queue<int> testQueue9Depth1 = Network.breadthFirstSearchDerivateBall(node9, 1);
            Queue<int> testQueue9Depth2 = Network.breadthFirstSearchDerivateBall(node9, 2);
            Queue<int> testQueue9Depth3 = Network.breadthFirstSearchDerivateBall(node9, 3);

            // Node with nodeID = 3

            Assert.AreEqual(2, testQueue3Depth1.Count);
            Assert.IsTrue(testQueue3Depth1.Contains(2));
            Assert.IsTrue(testQueue3Depth1.Contains(13));

            Assert.AreEqual(6, testQueue3Depth2.Count);
            Assert.IsTrue(testQueue3Depth2.Contains(0));
            Assert.IsTrue(testQueue3Depth2.Contains(1));
            Assert.IsTrue(testQueue3Depth2.Contains(7));
            Assert.IsTrue(testQueue3Depth2.Contains(9));
            Assert.IsTrue(testQueue3Depth2.Contains(10));
            Assert.IsTrue(testQueue3Depth2.Contains(12));

            Assert.AreEqual(4, testQueue3Depth3.Count);
            Assert.IsTrue(testQueue3Depth3.Contains(4));
            Assert.IsTrue(testQueue3Depth3.Contains(5));
            Assert.IsTrue(testQueue3Depth3.Contains(8));
            Assert.IsTrue(testQueue3Depth3.Contains(11));


            // Node with nodeID = 9

            Assert.AreEqual(5, testQueue9Depth1.Count);
            Assert.IsTrue(testQueue9Depth1.Contains(0));
            Assert.IsTrue(testQueue9Depth1.Contains(10));
            Assert.IsTrue(testQueue9Depth1.Contains(11));
            Assert.IsTrue(testQueue9Depth1.Contains(12));
            Assert.IsTrue(testQueue9Depth1.Contains(13));

            Assert.AreEqual(6, testQueue9Depth2.Count);
            Assert.IsTrue(testQueue9Depth2.Contains(1));
            Assert.IsTrue(testQueue9Depth2.Contains(2));
            Assert.IsTrue(testQueue9Depth2.Contains(3));
            Assert.IsTrue(testQueue9Depth2.Contains(4));
            Assert.IsTrue(testQueue9Depth2.Contains(7));
            Assert.IsTrue(testQueue9Depth2.Contains(8));

            Assert.AreEqual(2, testQueue9Depth3.Count);
            Assert.IsTrue(testQueue9Depth3.Contains(5));
            Assert.IsTrue(testQueue9Depth3.Contains(6));
        }


        [TestMethod]
        public void BFSDallTest()
        {
            Node node3 = Network.getNode(3);
            HashSet<int> testSet3Depth1 = Network.breadthFirstSearchBall(node3, 1);
            HashSet<int> testSet3Depth2 = Network.breadthFirstSearchBall(node3, 2);
            HashSet<int> testSet3Depth3 = Network.breadthFirstSearchBall(node3, 3);

            Node node9 = Network.getNode(9);
            HashSet<int> testSet9Depth1 = Network.breadthFirstSearchBall(node9, 1);
            HashSet<int> testSet9Depth2 = Network.breadthFirstSearchBall(node9, 2);
            HashSet<int> testSet9Depth3 = Network.breadthFirstSearchBall(node9, 3);

            // Node with nodeID = 3

            Assert.AreEqual(2, testSet3Depth1.Count);
            Assert.IsTrue(testSet3Depth1.Contains(2));
            Assert.IsTrue(testSet3Depth1.Contains(13));

            Assert.AreEqual(8, testSet3Depth2.Count);
            Assert.IsTrue(testSet3Depth2.Contains(0));
            Assert.IsTrue(testSet3Depth2.Contains(1));
            Assert.IsTrue(testSet3Depth2.Contains(2));
            Assert.IsTrue(testSet3Depth2.Contains(7));
            Assert.IsTrue(testSet3Depth2.Contains(9));
            Assert.IsTrue(testSet3Depth2.Contains(10));
            Assert.IsTrue(testSet3Depth2.Contains(12));
            Assert.IsTrue(testSet3Depth2.Contains(13));

            Assert.AreEqual(12, testSet3Depth3.Count);
            Assert.IsTrue(testSet3Depth3.Contains(0));
            Assert.IsTrue(testSet3Depth3.Contains(1));
            Assert.IsTrue(testSet3Depth3.Contains(2));
            Assert.IsTrue(testSet3Depth3.Contains(4));
            Assert.IsTrue(testSet3Depth3.Contains(5));
            Assert.IsTrue(testSet3Depth3.Contains(7));
            Assert.IsTrue(testSet3Depth3.Contains(8));
            Assert.IsTrue(testSet3Depth3.Contains(9));
            Assert.IsTrue(testSet3Depth3.Contains(10));
            Assert.IsTrue(testSet3Depth3.Contains(11));
            Assert.IsTrue(testSet3Depth3.Contains(12));
            Assert.IsTrue(testSet3Depth3.Contains(13));


            // Node with nodeID = 9

            Assert.AreEqual(5, testSet9Depth1.Count);
            Assert.IsTrue(testSet9Depth1.Contains(0));
            Assert.IsTrue(testSet9Depth1.Contains(10));
            Assert.IsTrue(testSet9Depth1.Contains(11));
            Assert.IsTrue(testSet9Depth1.Contains(12));
            Assert.IsTrue(testSet9Depth1.Contains(13));

            Assert.AreEqual(11, testSet9Depth2.Count);
            Assert.IsTrue(testSet9Depth2.Contains(0));
            Assert.IsTrue(testSet9Depth2.Contains(1));
            Assert.IsTrue(testSet9Depth2.Contains(2));
            Assert.IsTrue(testSet9Depth2.Contains(3));
            Assert.IsTrue(testSet9Depth2.Contains(4));
            Assert.IsTrue(testSet9Depth2.Contains(7));
            Assert.IsTrue(testSet9Depth2.Contains(8));
            Assert.IsTrue(testSet9Depth2.Contains(10));
            Assert.IsTrue(testSet9Depth2.Contains(11));
            Assert.IsTrue(testSet9Depth2.Contains(12));
            Assert.IsTrue(testSet9Depth2.Contains(13));

            Assert.AreEqual(13, testSet9Depth3.Count);
            Assert.IsTrue(testSet9Depth3.Contains(0));
            Assert.IsTrue(testSet9Depth3.Contains(1));
            Assert.IsTrue(testSet9Depth3.Contains(2));
            Assert.IsTrue(testSet9Depth3.Contains(3));
            Assert.IsTrue(testSet9Depth3.Contains(4));
            Assert.IsTrue(testSet9Depth3.Contains(5));
            Assert.IsTrue(testSet9Depth3.Contains(6));
            Assert.IsTrue(testSet9Depth3.Contains(7));
            Assert.IsTrue(testSet9Depth3.Contains(8));
            Assert.IsTrue(testSet9Depth3.Contains(10));
            Assert.IsTrue(testSet9Depth3.Contains(11));
            Assert.IsTrue(testSet9Depth3.Contains(12));
            Assert.IsTrue(testSet9Depth3.Contains(13));
        }

        [TestMethod]
        public void initializeCIValuesTest()
        {
            // Initialized at depth 1

            Network.testInitializeCIValues(1);

            Assert.AreEqual(6, Network.getNode(3).getCIvalue()); // ((3 - 1) + (5 - 1)) * (2 - 1) = 6
            Assert.AreEqual(60, Network.getNode(9).getCIvalue()); // ((4 - 1) + (4 - 1) + (4 - 1) + (3 - 1) + (5 - 1)) * (5 - 1) = 60
            Assert.AreEqual(22, Network.getNode(12).getCIvalue()); // ((5 - 1) + (5 - 1) + (4 - 1)) * (3 - 1) = 22


            // Initialized at depth 2

            Network.testInitializeCIValues(2);

            Assert.AreEqual(17, Network.getNode(3).getCIvalue()); // ((2 - 1) + (4 - 1) + (5 - 1) + (4 - 1) + (3 - 1) + (5 - 1)) * (2 - 1) = 17
            Assert.AreEqual(52, Network.getNode(9).getCIvalue()); // ((2 - 1) + (3 - 1) + (2 - 1) + (3 - 1) + (5 - 1) + (4 - 1)) * (5 - 1) = 52
            Assert.AreEqual(22, Network.getNode(12).getCIvalue()); // ((2 - 1) + (5 - 1) + (4 - 1) + (4 - 1)) * (3 - 1) = 22


            // Initialized at depth 3

            Network.testInitializeCIValues(3);

            Assert.AreEqual(11, Network.getNode(3).getCIvalue()); // ((3 - 1) + (4 - 1) + (4 - 1) + (4 - 1)) * (2 - 1) = 17
            Assert.AreEqual(16, Network.getNode(9).getCIvalue()); // ((4 - 1) + (2 - 1)) * (5 - 1) = 16
            Assert.AreEqual(22, Network.getNode(12).getCIvalue()); // ((2 - 1) + (3 - 1) + (3 - 1) + (4 - 1) + (4 -1)) * (3 - 1) = 22
        }

        [TestMethod]
        public void initializeMaxHeapTest()
        {
            MaxHeap maxHeap = Network.testGetaMaxheap();

            // Initialized at depth 1

            Network.testInitializeCIValues(1);
            Network.testInitilaizeMaxHeap();

            for (int i = 1; i <= 13; i++)
            {
                Assert.IsTrue(maxHeap.getNode(0).getCIvalue() >= maxHeap.getNode(i).getCIvalue());
            }


            // Initialized at depth 2

            Network.testInitializeCIValues(2);
            Network.testInitilaizeMaxHeap();

            for (int i = 1; i <= 13; i++)
            {
                Assert.IsTrue(maxHeap.getNode(0).getCIvalue() >= maxHeap.getNode(i).getCIvalue());
            }


            // Initialized at depth 3

            Network.testInitializeCIValues(3);
            Network.testInitilaizeMaxHeap();

            for (int i = 1; i <= 13; i++)
            {
                Assert.IsTrue(maxHeap.getNode(0).getCIvalue() >= maxHeap.getNode(i).getCIvalue());
            }
        }


        [TestMethod]
        public void removeRootTestDepth1()
        {
            MaxHeap maxHeap = Network.testGetaMaxheap();

            // Initialized at depth 1

            Network.testInitializeCIValues(1);
            Network.testInitilaizeMaxHeap();

            Node rootNode = maxHeap.getNode(0);
            Node removedNode = Network.testRemoveRoot();

            Assert.AreEqual(rootNode.getNodeID(), removedNode.getNodeID());
            Assert.AreEqual(13, Network.testGetSize()); // Same as maxHeap.getSize()

        }


        [TestMethod]
        public void removeRootTestDepth2()
        {
            MaxHeap maxHeap = Network.testGetaMaxheap();

            // Initialized at depth 2

            Network.testInitializeCIValues(2);
            Network.testInitilaizeMaxHeap();

            Node rootNode = maxHeap.getNode(0);
            Node removedNode = Network.testRemoveRoot();

            Assert.AreEqual(rootNode.getNodeID(), removedNode.getNodeID());
            Assert.AreEqual(13, Network.testGetSize()); // Same as maxHeap.getSize()
        }


        [TestMethod]
        public void removeRootTestDepth3()
        {
            MaxHeap maxHeap = Network.testGetaMaxheap();

            // Initialized at depth 1

            Network.testInitializeCIValues(3);
            Network.testInitilaizeMaxHeap();

            Node rootNode = maxHeap.getNode(0);
            Node removedNode = Network.testRemoveRoot();

            Assert.AreEqual(rootNode.getNodeID(), removedNode.getNodeID());
            Assert.AreEqual(13, Network.testGetSize()); // Same as maxHeap.getSize()
        }


        [TestMethod]
        public void updateCIValuesTestDepth1()
        {

            MaxHeap maxHeap = Network.testGetaMaxheap();

            // Initialized at depth 1

            Network.testInitializeCIValues(1);
            Network.testInitilaizeMaxHeap();

            Node removedNode = Network.testRemoveRoot();

            Network.testUpdateCIvalues(removedNode, 1);

            foreach (int nodeID in removedNode.getNeighbors())
            {
                Assert.IsFalse(Network.getNode(nodeID).getNeighbors().Contains(removedNode.getNodeID()));
            }

            for (int i = 1; i <= 12; i++)
            {
                Assert.IsTrue(maxHeap.getNode(0).getCIvalue() >= maxHeap.getNode(i).getCIvalue());
            }

            removedNode = Network.testRemoveRoot();

            Network.testUpdateCIvalues(removedNode, 1);

            foreach (int nodeID in removedNode.getNeighbors())
            {
                Assert.IsFalse(Network.getNode(nodeID).getNeighbors().Contains(removedNode.getNodeID()));
            }

            for (int i = 1; i <= 11; i++)
            {
                Assert.IsTrue(maxHeap.getNode(0).getCIvalue() >= maxHeap.getNode(i).getCIvalue());
            }
        }


        [TestMethod]
        public void updateCIValuesTestDepth2()
        {

            MaxHeap maxHeap = Network.testGetaMaxheap();

            // Initialized at depth 1

            Network.testInitializeCIValues(2);
            Network.testInitilaizeMaxHeap();

            Node removedNode = Network.testRemoveRoot();

            Network.testUpdateCIvalues(removedNode, 2);

            foreach (int nodeID in removedNode.getNeighbors())
            {
                Assert.IsFalse(Network.getNode(nodeID).getNeighbors().Contains(removedNode.getNodeID()));
            }

            for (int i = 1; i <= 12; i++)
            {
                Assert.IsTrue(maxHeap.getNode(0).getCIvalue() >= maxHeap.getNode(i).getCIvalue());
            }

            removedNode = Network.testRemoveRoot();

            Network.testUpdateCIvalues(removedNode, 2);

            foreach (int nodeID in removedNode.getNeighbors())
            {
                Assert.IsFalse(Network.getNode(nodeID).getNeighbors().Contains(removedNode.getNodeID()));
            }

            for (int i = 1; i <= 11; i++)
            {
                Assert.IsTrue(maxHeap.getNode(0).getCIvalue() >= maxHeap.getNode(i).getCIvalue());
            }
        }


        [TestMethod]
        public void updateCIValuesTestDepth3()
        {
            MaxHeap maxHeap = Network.testGetaMaxheap();

            // Initialized at depth 1

            Network.testInitializeCIValues(3);
            Network.testInitilaizeMaxHeap();

            Node removedNode = Network.testRemoveRoot();

            Network.testUpdateCIvalues(removedNode, 3);

            foreach (int nodeID in removedNode.getNeighbors())
            {
                Assert.IsFalse(Network.getNode(nodeID).getNeighbors().Contains(removedNode.getNodeID()));
            }

            for (int i = 1; i <= 12; i++)
            {
                Assert.IsTrue(maxHeap.getNode(0).getCIvalue() >= maxHeap.getNode(i).getCIvalue());
            }

            removedNode = Network.testRemoveRoot();

            Network.testUpdateCIvalues(removedNode, 3);

            foreach (int nodeID in removedNode.getNeighbors())
            {
                Assert.IsFalse(Network.getNode(nodeID).getNeighbors().Contains(removedNode.getNodeID()));
            }

            for (int i = 1; i <= 11; i++)
            {
                Assert.IsTrue(maxHeap.getNode(0).getCIvalue() >= maxHeap.getNode(i).getCIvalue());
            }
        }

    }
}
