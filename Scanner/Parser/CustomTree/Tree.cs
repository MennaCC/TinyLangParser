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

        public void Draw(/*sth to draw on from the UI*/)
        {
            HeadNode.DrawNode();
            if(!(HeadNode.isLeaf && HeadNode.isLonely))
            {
                HeadNode.DrawRecursive();
            }
        }
    }
}
