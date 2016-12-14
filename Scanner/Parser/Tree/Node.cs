using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Parser.Tree
{
    public class Node
    {
        #region Constructors
        public Node(string txt)
        {
            this.Text = txt;
        }
        public Node() { }
        #endregion

        #region Attributes
        /// <summary>
        /// Children Nodes
        /// </summary>
        private List<Node> Children = new List<Node>();
        /// <summary>
        /// Sibling Nodes
        /// </summary>
        public List<Node> Siblings = new List<Node>();
        public Node Parent;
        public string Text;
        public int Level = 0;

        public bool isLeaf = true;
        public bool isLonely = true;
        #endregion

        #region Public Functions
        #region Adding Child
        public void AddChild(Node n)
        {
            Children.Add(n);
            this.isLeaf = false;
            n.Level = this.Level + 1;
            n.Parent = this;
        }

        public void AddChild(string text)
        {
            Node temp = new Node(text);
            AddChild(temp);
        }
        #endregion
        #region Add Sibling 
        public void AddSibling(Node n)
        {
            Siblings.Add(n);
            this.isLonely = false;
            n.Level = this.Level;
        }
        public void AddSibling(string txt)
        {
            Node tmp = new Node(txt);
            Siblings.Add(tmp);
        }
        #endregion
        #region Drawing
        public void DrawNode()
        {
            //System.Drawing.Graphics graphics = this.CreateGraphics();
            //System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(
            //   50, 50, 60, 60);
            //graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
            //throw new NotImplementedException();
            
        }
        /// <summary>
        /// m4 h3melo byrsem el node nafsaha 34an mttresem4 mrteen 
        /// w ha5ally el headnode bas hya elly bttresem fl awel
        /// </summary>
        public void DrawRecursive(/*sth to draw on brdo :v*/)
        {
            if (!isLeaf)
            {
                this.DrawChildren();
            }
            else
            {
                this.DrawNode();
            }

            if(Siblings.Count != 0)
            {
                this.DrawSiblings();
            }
            
        }
        #endregion
        #endregion

        #region Private Functions
        private void DrawSiblings()
        {
            foreach(Node sib in Siblings)
            {
                sib.DrawRecursive();
            }
        }
        private void DrawChildren()
        {
            foreach(Node child in Children)
            {
                child.DrawRecursive();
            }
        }
        #endregion
    }
}
