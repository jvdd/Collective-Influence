# Collective-Influence
Project over the Collective Influence Algorithm for the course data structures and algorithms (KULAK 2016-2017)

The goal is to find the minimal set (= 'optimal influencers') in a graph that garantees a global connection.
The whole network decomposes when you remove this set of nodes.

---

### COMPILING THE ALGORITHM:
The easiest way to compile the code is to open the Visual Studio project folder and open the CollectiveInfluenceAlgorithm.sln file.
This is the project file which will open a Visual Studio project with all the necessary classes, namespaces, settings, ...


### EXECUTING THE ALGORITHM:

**Step 1**:
Go to the PROGRAM class

**Step 2**:
Change the string @"Write here your file path" to a string containing the location of the text-file of thenetwork.
An example is: string filepath = @"C:\Users\Name\Directory\subdirectory\filename.txt"
!!! Don't forget to write @ before your string (as you can see in the example above)
IMPORTANT NOTE: The filename should be one of the 13 given networks!

**Step 2**:
Change the integer depth to the distance you prefer to search nodes for.
IMPORTANT NOTE: The depth should be >= 0 !


###WHAT WILL HAPPEN?
Now the algorithm will execute:
Starting at a distance 0 it will search all the influencers.
This will be repeated until the given depth is reached and the algorithm is executed for the last time.
When all the influencers are found for a specific depth, these are written to a file located in the folder of your text-file.


When the program is finished you can close the console application by just pressing any button.