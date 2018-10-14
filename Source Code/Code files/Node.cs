using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectiveInfluenceAlgorithm

{
    public class Node
    {
        // PROPERTIES
        private int nodeID;
        private List<int> neighbors = new List<int>();
        private long CIvalue;
        private long updatedCIvalue;
        private int degree;
        private int maxhHeapIndex;



        // CONSTRUCTOR
        public Node(int nodeID, int toNodeId)
        {
            this.nodeID = nodeID;
            degree = 0;
            addNeighbor(toNodeId);
        }



        // METHODS

        /******************************
        nodeID
        *******************************/

        public int getNodeID()
        {
            return nodeID;
        }



        /******************************
        neighbors
        *******************************/

        public List<int> getNeighbors()
        {
            return neighbors;
        }


        public int getDegree()
        {
            return degree;
        }


        internal void addNeighbor(int nodeID)
        {
            if (!neighbors.Contains(nodeID) && nodeID != this.nodeID) // Avoid double links to neighbors and loops to the node itself
            {
                neighbors.Add(nodeID);
                degree++;
            }
        }


        internal void removeNeighbor(int nodeID)
        {
            neighbors.Remove(nodeID);
            degree--;
        }



        /******************************
        maxHeapIndex
        *******************************/

        public int getMaxHeapIndex()
        {
            return maxhHeapIndex;
        }


        internal void setMaxHeapIndex(int index)
        {
            maxhHeapIndex = index;
        }



        /******************************
        CIvalue
        *******************************/

        public long getCIvalue()
        {
            return CIvalue;
        }


        internal void computeCIvalue(int distance)
        {
            long sumOfDegreesOnBoundry = 0;
            Queue<int> boundryNodes = Network.breadthFirstSearchDerivateBall(this, distance);
            while (boundryNodes.Count > 0) // .Count is more efficient than .Any()
            {
                sumOfDegreesOnBoundry += (Network.getNode(boundryNodes.Dequeue()).getDegree() - 1);
            }
            CIvalue = (getDegree() - 1) * sumOfDegreesOnBoundry;
        }


        internal void setCIvalue(long CIvalue)
        {
            this.CIvalue = CIvalue;
        }



        /******************************
        updatedCIvalue
        *******************************/

        internal void calculateUpdatedCIvalue(int distance)
        {
            long sumOfDegreesOnBoundry = 0;
            Queue<int> boundryNodes = Network.breadthFirstSearchDerivateBall(this, distance);
            while (boundryNodes.Count > 0)
            {
                sumOfDegreesOnBoundry += (Network.getNode(boundryNodes.Dequeue()).getDegree() - 1);
            }
            updatedCIvalue = (getDegree() - 1) * sumOfDegreesOnBoundry;
        }


        internal void setUpdatedCIvalue(long updatedCIvalue)
        {
            this.updatedCIvalue = updatedCIvalue;
        }


        internal void updateCIvalue()
        {
            Network.decreaseTotalSumCIvalues(CIvalue - updatedCIvalue);
            CIvalue = updatedCIvalue;
        }

    }
}
