using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20Question_new
{
    public class BinTree
    {
        Node root;
        string filenameWriter = "myWrittenFile.txt";


        //Constructor 
        public BinTree()
        {
            root = null;
        }

        public Node Root
        {
            get { return root; }
            set { root = value; }
        }

        //set up a tree
        //hard wire data
        public void HardWire()
        {
            if (File.Exists(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, filenameWriter)))
            {
                InitRootFromList(ReadFromFile());
            }
            else
            {
                root = new Node("living", "I");
                root.YesPtr = new Node("BIll", "L");
                root.NoPtr = new Node("Chet", "L");
            }
        }

        List<Node> ReadFromFile()
        {
            List<Node> nodes = new List<Node>();
            FileStream fs = new FileStream(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, filenameWriter), FileMode.Open, FileAccess.Read);
            StreamReader read = new StreamReader(fs, Encoding.Default);
            string strReadline;
            while ((strReadline = read.ReadLine()) != null)
            {
                if (strReadline.Length > 1)
                {
                    string sHead = strReadline.Substring(0, 1);
                    string quest = strReadline.Substring(1, strReadline.Length - 1);
                    Node node = new Node(quest, sHead);
                    nodes.Add(node);
                }


            }
            fs.Close();

            read.Close();
            return nodes;
        }
        void InitRootFromList(List<Node> nodes)
        {
            if (nodes != null && nodes.Count > 0)
            {
                foreach (var node in nodes)
                {
                    AddNodeToRoot(root, node);
                }
            }
        }

        bool AddNodeToRoot( Node root, Node node)
        {
            if (root == null)
            {
                this.root = new Node(node.Quest,node.NodeType);
       
                return true;
            }
            else
            {
                if (root.NodeType == "I")
                {
                    if (root.YesPtr == null)
                    {
                        root.YesPtr = node;
               
                        return true;
                    }
                    else
                    {
                        bool isOk = AddNodeToRoot(root.YesPtr, node);
                        if (isOk)
                        {
                            return true;
                        }
                        else
                        {
                            if (root.NoPtr == null)
                            {
                                root.NoPtr = node;

                                return true;
                            }
                            else
                            {
                                return AddNodeToRoot(root.NoPtr, node);
                            }
                            
                        }
                    }
                }
                else
                {
                    return false;
                }

            }
        }

        StringBuilder textToSave = new StringBuilder();
        public void PreOrderRec(Node theRoot)
        {
            if (theRoot != null)
            {
                textToSave.Append(theRoot.NodeType + theRoot.Quest + Environment.NewLine);
                PreOrderRec(theRoot.YesPtr);
                PreOrderRec(theRoot.NoPtr);
            }
        }

        public void SaveTheTree()
        {
            PreOrderRec(root);
            File.WriteAllText(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, filenameWriter), textToSave.ToString());
        }
    }
}
