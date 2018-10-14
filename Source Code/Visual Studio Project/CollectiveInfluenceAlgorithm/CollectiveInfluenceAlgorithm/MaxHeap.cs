using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectiveInfluenceAlgorithm
{
    public class MaxHeap
    {
        // PROPERTIES
        private List<int> maxHeap;



        // CONSTRUCTOR
        public MaxHeap()
        {
            maxHeap = new List<int>();
        }



        // METHODS

        public int getSize()
        {
            return maxHeap.Count;
        }


        public int getLeft(int index)
        {
            return 2 * index + 1;
        }


        public int getRight(int index)
        {
            return 2 * index + 2;
        }


        public Node getNode(int index)
        {
            return Network.getNode(maxHeap[index]);
        }


        private void swap(int i, int j)
        {
            int temp = maxHeap[i];
            maxHeap[i] = maxHeap[j];
            maxHeap[j] = temp;
            Network.getNode(maxHeap[i]).setMaxHeapIndex(i);
            Network.getNode(maxHeap[j]).setMaxHeapIndex(j);
        }


        internal void addNodeID(int nodeID) // Only used for initialization: adding the nodes to the maxheap list
        {
            maxHeap.Add(nodeID);
            Network.getNode(nodeID).setMaxHeapIndex(getSize());
        }


        internal Node removeRoot()
        {
            Node removedRoot = getNode(0);
            maxHeap[0] = maxHeap[getSize() - 1];
            maxHeap.RemoveAt(getSize() - 1);
            Network.getNode(maxHeap[0]).setMaxHeapIndex(0);
            maxHeapify(0);
            return removedRoot;
        }


        public void maxHeapify(int index)
        {
            int left = getLeft(index);
            int right = getRight(index);
            int largest;
            if (left < getSize() && getNode(left).getCIvalue() > getNode(index).getCIvalue())
            {
                largest = left;
            }
            else
            {
                largest = index;
            }
            if (right < getSize() && getNode(right).getCIvalue() > getNode(largest).getCIvalue())
            {
                largest = right;
            }
            if (largest != index)
            {
                swap(index, largest);
                maxHeapify(largest);
            }
        }

        public void buildMaxHeap()
        {
            int size = getSize() / 2;
            for (int i = size; i >= 0; i--)
            {
                maxHeapify(i);
            }
        }
    }
}