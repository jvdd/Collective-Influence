using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Runtime.InteropServices;


namespace CollectiveInfluenceAlgorithm

{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"Write here your file path";
            int depth = 1;

            for (int i = 0; i <= depth; i++)
            {
                Network.executeAlgorithm(filepath, i);
                Network.clear();
            }




            // THE CODE UNDERNEATH IS HOW I RAN THE ALGORITHM ON THE GIVEN TEXT FILE


            // CA-GRQC

            // Original eigenvalue is smaller than 1 for distance bigger than 12
            /*
            filepath = @"C:\Users\Jeroen\Documents\CI_data\CA-GrQc.txt";
            for (int i = 0; i <= 13; i++)
            {
                Network.executeAlgorithm(filepath, i);
                Network.clear();
            }
            */


            //P2P-GNUTELLA08

            // Original eigenvalue is smaller than 1 for distance bigger than 6
            /*
            filepath = @"C:\Users\Jeroen\Documents\CI_data\p2p-Gnutella08.txt";
            for (int i = 1; i <= 7; i++)
            {
                Network.executeAlgorithm(filepath, i);
                Network.clear();
            }
            */


            // P2P-GNUTELLA30
            /*
            filepath = @"C:\Users\Jeroen\Documents\CI_data\p2p-Gnutella30.txt";
            for (int i = 1; i <= 4; i++)
            {
                Network.executeAlgorithm(filepath, i);
                Network.clear();
            }
            */


            // EMAIL-ENRON
            /*
            filepath = @"C:\Users\Jeroen\Documents\CI_data\Email-Enron.txt";
            for (int i = 1; i <= 4; i++)
            {
                Network.executeAlgorithm(filepath, i);
                Network.clear();
            }
            */


            // HIGGS-REPLY_NETWORK
            /*
            // Original eigenvalue is smaller than 1 for distance bigger than 18
            filepath = @"C:\Users\Jeroen\Documents\CI_data\higgs-reply_network.txt";
            for (int i = 1; i <= 19; i++)
            {
                Network.executeAlgorithm(filepath, i);
                Network.clear();
            }
            */


            // HIGGS-MENTION_NETWORK
            /*
            filepath = @"C:\Users\Jeroen\Documents\CI_data\higgs-mention_network.txt";
            for (int i = 1; i <= 5; i++)
            {
                Network.executeAlgorithm(filepath, i);
                Network.clear();
            }
            */


            // HIGGS-RETWEET_NETWORK
            /*
            filepath = @"C:\Users\Jeroen\Documents\CI_data\higgs-retweet_network.txt";
            for (int i = 1; i <= 3; i++)
            {
                Network.executeAlgorithm(filepath, i);
                Network.clear();
            }
            */


            // HIGGS-SOCIAL_NETWORK
            /*
            filepath = @"C:\Users\Jeroen\Documents\CI_data\higgs-social_network.txt";
            Network.executeAlgorithm(filepath, 1);
            Network.clear();
            */


            // ROADNET-CA
            /*
            filepath = @"C:\Users\Jeroen\Documents\CI_data\roadNet-CA.txt";
            for (int i = 1; i <= 17; i++)
            {
                Network.executeAlgorithm(filepath, i);
                Network.clear();
            }
            */


            //SOC-POKEC-RELATIONSHIPS
            /*
            filepath = @"C:\Users\Jeroen\Documents\CI_data\soc-pokec-relationships.txt";
            Network.executeAlgorithm(filepath, 1);
            Network.clear();
            */


            // CIT-PATENTS
            /*
            filepath = @"C:\Users\Jeroen\Documents\CI_data\cit-Patents.txt";
            for (int i = 1; i <= 2; i++)
            {
                Network.executeAlgorithm(filepath, i);
                Network.clear();
            }
            */


            //SOC-LIVEJOURNAL1
            /*
            filepath = @"C:\Users\Jeroen\Documents\CI_data\soc-LiveJournal1.txt";
            Network.executeAlgorithm(filepath, 1);
            Network.clear();
            Console.WriteLine();
            Console.WriteLine();
            */

            //COM-FRIENDSTER.UNGRAPH
            //Can't read in the whole file into the ram... 32 GB > 12 GB RAM.
            /*
            filepath = @"C:\Users\Jeroen\Documents\CI_data\com-friendster.ungraph.txt";
            Network.executeAlgorithm(filepath, 1);
            Network.clear();
            Console.WriteLine();
            Console.WriteLine();
            */

            //

            Console.ReadLine();
        }
    }
}
