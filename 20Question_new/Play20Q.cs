using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20Question_new
{
    public class Play20Q
    {
        public static void PlayOneRound(BinTree t)
        {
            //while loop
            var curr = t.Root;
            var currParentNode = curr;
            bool isRight = false;
            while (curr != null)
            {
                currParentNode = curr;
                string quest = curr.DisplayQuestin();
                Console.Write(quest);
                string answer;
                answer = Console.ReadLine();
                if (answer == "y")
                {
                    isRight = true;
                    curr = curr.YesPtr;
                }
                else
                {
                    isRight = false;
                    curr = curr.NoPtr;
                }
            }
            //Now thet currParentNode points to a leaf node, Ask a name If name was correct
            if (isRight)
            {
                Console.WriteLine("Hurray! I win!");
            }
            else 
            {
                Console.Write("I give up. Who is it?");
                string answerToNew;
                answerToNew = Console.ReadLine();
                Node whoIsIt = new Node(answerToNew, "L");

                Console.Write("What is "+whoIsIt.Quest+" that "+currParentNode.Quest+" isn't?");
                string answerToDesc;
                answerToDesc = Console.ReadLine();
                Node moreDesc = new Node(answerToDesc, "I");

                LearnNew(currParentNode, whoIsIt, moreDesc);
                
            }

        }

        static void LearnNew(Node answerToLeaf,Node whoIsIt,Node moreDesc) 
        {
            Node tmp = new Node("","L");
            tmp.Quest = answerToLeaf.Quest;

            answerToLeaf.NodeType = "I";
            answerToLeaf.Quest = moreDesc.Quest;
            answerToLeaf.YesPtr = whoIsIt;
            answerToLeaf.NoPtr = tmp;

            Console.WriteLine("I love to learn new people!");
        }
    }
}
