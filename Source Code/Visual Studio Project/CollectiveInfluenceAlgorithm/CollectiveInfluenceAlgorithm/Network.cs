using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace CollectiveInfluenceAlgorithm

{
    public static class Network
    {
        // PROPERTIES
        private static Stopwatch sw = new Stopwatch();
        private static Node[] nodeNetwork;
        private static MaxHeap maxHeap = new MaxHeap();
        private static long totalDegreeAtBegin = 0;
        private static long totalSumCIvalues = 0;



        // METHODS

        /******************************
        network
        *******************************/

        public static Node getNode(int nodeID)
        {
            return nodeNetwork[nodeID];
        }


        public static bool containsNode(int nodeID)
        {
            return nodeNetwork[nodeID] != null;
        }


        internal static void clear()
        {
            maxHeap = new MaxHeap();
            nodeNetwork = null;
            totalDegreeAtBegin = 0;
            totalSumCIvalues = 0;
        }



        /******************************
        totalDegreeAtBegin
        *******************************/

        private static void initializeTotalDegree()
        {
            for (int i = 0; i < maxHeap.getSize(); i++)
            {
                totalDegreeAtBegin += maxHeap.getNode(i).getDegree();
            }
        }


        // The total degree = N<k> (<k> = average degree, N = # nodes in network)
        public static long getTotalDegreeAtBegin()
        {
            return totalDegreeAtBegin;
        }



        /******************************
        totalSumCIvalues
        *******************************/

        private static void initalizeTotalSumCIvalues()
        {
            for (int i = 0; i < maxHeap.getSize(); i++)
            {
                totalSumCIvalues += maxHeap.getNode(i).getCIvalue();
            }
        }


        public static long getTotalSumCIvalues()
        {
            return totalSumCIvalues;
        }


        internal static void decreaseTotalSumCIvalues(long difference)
        {
            totalSumCIvalues -= difference;
        }



        /******************************
        read text file
        *******************************/

        private static void readTextFile(string filePath)
        {
            string line;
            char[] whitespace = new char[] { ' ', '\t' };

            int largestNodeID = 0;

            string[] splittedFilePath = filePath.Split('\\');
            switch (splittedFilePath.Last())
            {
                case "TestFile.txt":
                    largestNodeID = 50; // Testcase
                    break;
                case "CA-GrQc.txt":
                    largestNodeID = 36691;
                    break;
                case "p2p-Gnutella08.txt":
                    largestNodeID = 6300;
                    break;
                case "p2p-Gnutella30.txt":
                    largestNodeID = 36681;
                    break;
                case "Email-Enron.txt":
                    largestNodeID = 36691;
                    break;
                case "higgs-reply_network.txt":
                    largestNodeID = 456611;
                    break;
                case "higgs-mention_network.txt":
                    largestNodeID = 456619;
                    break;
                case "higgs-retweet_network.txt":
                    largestNodeID = 456623;
                    break;
                case "higgs-social_network.txt":
                    largestNodeID = 456626;
                    break;
                case "roadNet-CA.txt":
                    largestNodeID = 19652999;
                    break;
                case "soc-pokec-relationships.txt":
                    largestNodeID = 1632803;
                    break;
                case "cit-Patents.txt":
                    largestNodeID = 6009554;
                    break;
                case "soc-LiveJournal1.txt":
                    largestNodeID = 4847570;
                    break;
                case "com-friendster.ungraph.txt":
                    largestNodeID = 124836179;
                    break;
                default:
                    {
                        System.Console.WriteLine("No such file is in the system: {0}", splittedFilePath.Last());
                        break;
                    }
            }

            nodeNetwork = new Node[largestNodeID + 1];

            // Read the file line by line and save the data in node objects.
            // Sources: http://cc.davelozinski.com/c-sharp/fastest-way-to-read-text-files
            //          https://msdn.microsoft.com/en-us/library/aa287535(v=vs.71).aspx
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            while ((line = file.ReadLine()).Contains("#")) { }; // Skipping the first lines that start with "#" (works way faster than checking it every iteration in the while loop underneath)

            while (line != null)
            {
                string[] splittedLine = line.Split(whitespace);
                int fromNodeID = Convert.ToInt32(splittedLine[0]);
                int toNodeID = Convert.ToInt32(splittedLine[1]);


                if (containsNode(fromNodeID))
                 {
                     nodeNetwork[fromNodeID].addNeighbor(toNodeID);
                 }
                 else
                 {
                     Node node = new Node(fromNodeID, toNodeID);
                     nodeNetwork[fromNodeID] = node;
                     maxHeap.addNodeID(fromNodeID);
                 }

                 if (containsNode(toNodeID))
                 {
                     nodeNetwork[toNodeID].addNeighbor(fromNodeID);
                 }
                 else
                 {
                     Node node = new Node(toNodeID, fromNodeID);
                     nodeNetwork[toNodeID] = node;
                     maxHeap.addNodeID(toNodeID);
                 }
                
                line = file.ReadLine();
            }

            file.Close();
        }



        /******************************
        Ball(i,j)
        *******************************/

        public static Queue<int> breadthFirstSearchDerivateBall(Node node, int distance)
        {
            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();

            int newDegree = 0;
            int depth = 0;
            int temp = -1;

            queue.Enqueue(node.getNodeID());
            visited.Add(node.getNodeID());

            int degree = 1;

            while (depth < distance)
            {
                if (degree > 0)
                {
                    temp = queue.Dequeue();

                    foreach (int neighborID in getNode(temp).getNeighbors())
                    {
                        if (visited.Add(neighborID)) // Add(): return true if the element is added to the HashSet<T> object; false if the element is already present
                        {
                            queue.Enqueue(neighborID);
                            newDegree++;
                        }
                    }
                    degree--;
                }

                if (degree == 0)
                {
                    depth++;
                    degree = newDegree;
                    newDegree = 0;
                }
            }

            return queue;
        }


        // Is not used due to too much memory being used by this function
        // But its useful to be used in the test class
        public static HashSet<int> breadthFirstSearchBall(Node node, int distance)
        {
            HashSet<int> ball = new HashSet<int>();
            Queue<int> queue = new Queue<int>();

            int newDegree = 0;
            int depth = 0;
            int temp = -1;

            queue.Enqueue(node.getNodeID());

            int degree = 1;

            while (depth < distance)
            {
                if (degree > 0)
                {
                    temp = queue.Dequeue();

                    foreach (int neighborID in Network.getNode(temp).getNeighbors())
                    {
                        if (neighborID != node.getNodeID()) // Avoid to add the node itself to the ball hashset
                        {
                            queue.Enqueue(neighborID);
                            newDegree++;
                            ball.Add(neighborID);
                        }
                    }
                    degree--;
                }

                if (degree == 0)
                {
                    depth++;
                    degree = newDegree;
                    newDegree = 0;
                }
            }

            HashSet<int> boundryBall = new HashSet<int>(queue);
            ball.UnionWith(boundryBall);

            return ball;
        }
        


        /******************************
        STEP 1: COMPUTING CI
        *******************************/

        private static void initializeCIvalues(int distance)
        {
            Parallel.For(0, maxHeap.getSize(), i => maxHeap.getNode(i).computeCIvalue(distance));
        }



        /******************************
        STEP 2: BUILDING THE MAXHEAP
        *******************************/

        private static void initializeMaxHeap()
        {
            maxHeap.buildMaxHeap();
        }



        /******************************
        STEP 4: UPDATING CI VALUES
        *******************************/

        private static void updateCIvalue(Node node, int distance)
        {
            node.updateCIvalue();
            maxHeap.maxHeapify(node.getMaxHeapIndex());
        }


        private static void updateCIvalues(Node node, int distance)
        {
            foreach (int nodeID in node.getNeighbors())
            {
                getNode(nodeID).removeNeighbor(node.getNodeID());
            }

            Network.decreaseTotalSumCIvalues(node.getCIvalue());

            // Requires less memory than the code in comment underneath
            for (int i = 1; i <= distance; i++)
            {
                Queue<int> ballNodes = breadthFirstSearchDerivateBall(node, i);
                Parallel.ForEach<int>(ballNodes, nodeID => getNode(nodeID).calculateUpdatedCIvalue(distance));
                while (ballNodes.Count > 0)
                {
                    updateCIvalue(getNode(ballNodes.Dequeue()), distance);
                }
            }

            // THIS REQUIRES TOO MUCH MEMORY, CERTAINLY FOR BIGGER DEPTHS
            /*
            HashSet<int> ballNodes = breadthFirstSearchBall(node, distance);
            Parallel.ForEach<int>(ballNodes, nodeID => getNode(nodeID).calculateUpdatedCIvalue(distance));
            foreach (int nodeID in ballNodes)
            {
                updateCIvalue(getNode(nodeID), distance);
            }
            */


            // THIS IS ONLY CORRECT FOR TREELIKE STRUCTURES, WE NEED TO RECALCULATE THE CI VALUE FOR ALL NODES IN
            // THE BALL(1, l + 1).
            // © Alexander Braekevelt (He noticed this)
            // So the code you can find below this comment is not optimal. But since the whole algorithm is actually
            // an approximation for finding the optimal set of influencers (NP-hard) and the difference in removed nodes
            // between the more correct version and this one is not that big, I didn't change it.
            // In my oppinion the small improvement in precision does not pay off to the big loss in speed.

            Queue<int> boundryBall = breadthFirstSearchDerivateBall(node, distance + 1);
            Parallel.ForEach<int>(boundryBall, nodeID => getNode(nodeID).setUpdatedCIvalue(getNode(nodeID).getCIvalue() - (getNode(nodeID).getDegree() - 1)));
            while (boundryBall.Count > 0)
            {
                updateCIvalue(getNode(boundryBall.Dequeue()), distance);
            }
        }



        /******************************
        STEP 5: STOPPING THE ALGORITHM
        *******************************/

        public static decimal computeEigenvalue(int distance)
        {
            double eigenvalueNoPower = (double)getTotalSumCIvalues() / getTotalDegreeAtBegin();
            double power = (double)1 / (distance + 1);
            decimal eigenvalue = (decimal)Math.Pow(eigenvalueNoPower, power);
            return eigenvalue;
        }


        private static bool validEigenvalue()
        {
            return totalSumCIvalues > totalDegreeAtBegin;
        }



        /******************************
        WRITING INFLUENCERS TO TEXT FILE
        *******************************/

        private static void writeToFile(string filePath, int distance, long totalNumberOfNodes, decimal originalEigenvalue, List<Node> influencers, string readTime, string initializeCITime, string initializeMaxHeapTime, string searchingInfluencersTime)
        {
            string[] splittedFilePath = filePath.Split('\\');
            // TO MAKE THE CODE MORE USER FRIENDLY
            string folder = filePath;
            folder = folder.Replace(".txt", "");
            System.IO.StreamWriter file = new System.IO.StreamWriter(String.Format(@"{0} INFLUENCERS, depth {1}.txt", folder, distance));
            // THE CODE UNDERNEATH IS HOW I DID IT ON MY PC
            // I CREATED THE CORRECT FOLDERS BEFORE EXECUTING THE PROGRAM
            //string folderName = splittedFilePath.Last().Replace(".txt", "");
            //System.IO.StreamWriter file = new System.IO.StreamWriter(String.Format(@"C:\Users\Jeroen\Documents\Results_CI\{0}\data, depth {1}, {2} ", folderName, distance, splittedFilePath.Last()));
            file.WriteLine(splittedFilePath.Last());
            file.WriteLine("Depth: {0}", distance);
            file.WriteLine();
            file.WriteLine("Number of nodes: {0}", totalNumberOfNodes);
            file.WriteLine("Number of edges: {0}", totalDegreeAtBegin / 2);
            file.WriteLine();
            file.WriteLine("Reading data: time elapsed = {0}", readTime);
            file.WriteLine("Initializing CI values: time elapsed = {0}", initializeCITime);
            file.WriteLine("Initializing MaxHeap: time elapsed = {0}", initializeMaxHeapTime);
            file.WriteLine("Searching influencers: time elapsed = {0}", searchingInfluencersTime);
            file.WriteLine();
            file.WriteLine("Original eigenvalue: {0}", originalEigenvalue);
            file.WriteLine("Number of influencers: {0}", influencers.Count);
            file.WriteLine();

            for (int i = 0; i < influencers.Count; i++)
            {
                Node node = influencers[i];
                file.WriteLine();
                file.WriteLine("ID: {0}", node.getNodeID());
                file.WriteLine("Degree: {0}", node.getDegree());
                file.WriteLine("CIvalue: {0}", node.getCIvalue());
            }

            file.Close();
        }



        /******************************
        EXECUTION OF CI ALGORITHM
        *******************************/

        public static void executeAlgorithm(string filePath, int distance)
        {
            string[] splittedFilePath = filePath.Split('\\');
            Console.WriteLine(splittedFilePath.Last());
            Console.WriteLine("Depth: {0}", distance);
            Console.WriteLine();


            // READ TEXT FILE
            Console.WriteLine("Initializing text file Started");
            sw.Start();
            readTextFile(filePath);
            initializeTotalDegree(); // Initializing the total degree after the text file is read into the memory
            sw.Stop();
            Console.WriteLine("Initializing Completed");
            Console.WriteLine("Time elapsed = {0} h {1} min {2} sec {3} milisec", sw.Elapsed.Hours, sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            string readTime = String.Format("{0} h {1} min {2} sec {3} milisec", sw.Elapsed.Hours, sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            sw.Reset();
            Console.WriteLine();
            Console.WriteLine("Total degree: {0}", totalDegreeAtBegin);
            Console.WriteLine("Total nb of Nodes: {0}", maxHeap.getSize());
            Console.WriteLine();

            long totalNumberOfNodes = maxHeap.getSize();


            // STEP 1
            Console.WriteLine("Initializing CI values Started");
            sw.Start();
            initializeCIvalues(distance);
            initalizeTotalSumCIvalues();
            sw.Stop();
            Console.WriteLine("Initializing Completed");
            Console.WriteLine("Time elapsed = {0} h {1} min {2} sec {3} milisec", sw.Elapsed.Hours, sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            string initializeCITime = String.Format("{0} h {1} min {2} sec {3} milisec", sw.Elapsed.Hours, sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            sw.Reset();
            Console.WriteLine();


            // STEP 2
            Console.WriteLine("Initializing max-heap Started");
            sw.Start();
            initializeMaxHeap();
            sw.Stop();
            Console.WriteLine("Initializing Completed");
            Console.WriteLine("Time elapsed = {0} h {1} min {2} sec {3} milisec", sw.Elapsed.Hours, sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            string initializeMaxHeapTime = String.Format("{0} h {1} min {2} sec {3} milisec", sw.Elapsed.Hours, sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            sw.Reset();
            Console.WriteLine();

            Console.WriteLine("Root node nodeID: {0}", maxHeap.getNode(0).getNodeID());
            Console.WriteLine("CI value root node: {0}", maxHeap.getNode(0).getCIvalue());
            Console.WriteLine();

            List<Node> influencers = new List<Node>();


            // LOOP: REMOVING ROOT + UPDATING CI (WITH HEAPIFY IN EVERY STEP)
            Console.WriteLine("Searching influencers Started");
            sw.Start();
            decimal eigenvalue = computeEigenvalue(distance);
            decimal originalEigenvalue = eigenvalue;
            float originalCIonDegree = (float)getTotalSumCIvalues() / getTotalDegreeAtBegin();
            double percentage = 0.0000;
            Console.WriteLine("eigenvalue: {0}", originalEigenvalue);
            Console.Write("\rProgress: {0}%", percentage * 100);
            while (validEigenvalue())
            {
                Node removedNode = maxHeap.removeRoot();
                updateCIvalues(removedNode, distance);
                float currentCIonDegree = (float)getTotalSumCIvalues() / getTotalDegreeAtBegin();
                // Note: the progress is just an approximation
                Console.Write("\rProgress: {0}%", Math.Round((1 - currentCIonDegree / (originalCIonDegree - 1)) * 100, 2));
                influencers.Add(removedNode);
            }
            // Set the progress to 100% when finished
            Console.Write("\rProgress: 100.00%");
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine("Searching influencers Completed");
            Console.WriteLine("Time elapsed = {0} h {1} min {2} sec {3} milisec", sw.Elapsed.Hours, sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            string searchingInfluencersTime = String.Format("{0} h {1} min {2} sec {3} milisec", sw.Elapsed.Hours, sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            sw.Reset();

            Console.WriteLine();
            Console.WriteLine("Eigenvalue: {0}", computeEigenvalue(distance));
            Console.WriteLine("Total number of removed influencers: {0}", influencers.Count);
            

            // WRIING TO TEXT FILE
            Console.WriteLine();
            Console.WriteLine("Writing to file started");
            sw.Start();
            writeToFile(filePath, distance, totalNumberOfNodes, originalEigenvalue, influencers, readTime, initializeCITime, initializeMaxHeapTime, searchingInfluencersTime);
            sw.Stop();
            Console.WriteLine("Writing to file Completed");
            Console.WriteLine("Time elapsed = {0} h {1} min {2} sec {3} milisec", sw.Elapsed.Hours, sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            Console.WriteLine();
            sw.Reset();

        }



        /******************************
        TESTING
        *******************************/
        // Meant to be only used for testing
        // We can keep the encapsulation for the normal program by enabling these functions only for testing
        
        public static void testClear() // Make the heap empty for each initialization in UnitTest
        {
            maxHeap = new MaxHeap();
        }

        public static void testReadTextFile(string filePath)
        {
            readTextFile(filePath);
        }

        public static int testGetSize()
        {
            return maxHeap.getSize();
        }

        public static void testInitializeCIValues(int distance)
        {
            initializeCIvalues(distance);
        }

        public static void testInitilaizeMaxHeap()
        {
            initializeMaxHeap();
        }

        public static MaxHeap testGetaMaxheap()
        {
            return maxHeap;
        }

        public static Node testRemoveRoot()
        {
            return maxHeap.removeRoot();
        }

        public static void testUpdateCIvalues(Node node, int distance)
        {
            updateCIvalues(node, distance);
        }
    }
}
