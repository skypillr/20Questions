using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20Question_new
{
    class Program
    {
        static void Main(string[] args)
        {
            BinTree tqTree = new BinTree();
            // tqTree.HardWire();			// Used before ReadTree() worked
           // tqTree.ReadTree();
            // tqTree.Traverse();			// Uncomment for debug
            tqTree.HardWire();
            string answer;
            Console.WriteLine("Welcome to 20 questions!  I'll try to guess your person.");

            do
            {
                Console.WriteLine();
                Play20Q.PlayOneRound(tqTree);

                Console.Write("\nHow about another game? ");
                answer = Console.ReadLine();

            } while (answer.Equals("y"));

            tqTree.SaveTheTree();
            // tqTree.Traverse();			// Uncomment for debug
            Console.WriteLine("Bye Bye!");
            Console.Read();
        }
    }
}
