using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20Question_new
{

    public class Node
    {
        private string nodeType = null;
        private string quest = null;
        private Node yesPtr = null;
        private Node noPtr = null;
        private int data;
        public Node(string quest,string nodeType) 
        {
            this.quest = quest;
            this.nodeType = nodeType;
        }

        public string NodeType
        {
            get { return nodeType; }
            set { nodeType = value; }
        }

        public string Quest
        {
            get { return quest; }
            set { quest = value; }
        }
        public Node YesPtr
        {
            get { return yesPtr; }
            set { yesPtr = value; }
        }
        public Node NoPtr
        {
            get { return noPtr; }
            set { noPtr = value; }
        }
        public int Data
        {
            get { return data; }
            set { data = value; }
        }

        public string DisplayQuestin() 
        {
            if (nodeType == null) 
            {
                return "";
            }
            if (nodeType == "I") 
            {
                return "Is this person "+quest+"?";
            }
            if (nodeType == "L") 
            {
                return "Is it "+quest+"?";
            }
            return "";
        }

    }
}
