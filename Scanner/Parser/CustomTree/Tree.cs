using Parser.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.CustomTree
{
    public class Tree
    {
        public Node HeadNode = new Node();
        List<Node> nodesList = new List<Node>();

        public Tree()
        {
            HeadNode.ownerTree = this;
        }

        public void KeepTrackOfNode(Node n)
        {
            if(n.Level != 0)
            {
                nodesList.Add(n);
            }
        }

        public List<Node> getNodesList()
        {
            return nodesList;
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
