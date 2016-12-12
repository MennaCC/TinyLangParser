using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.UI
{
    class Node
    {

        #region Private Attributes 

        private Node Parent;
        private List<Node> ChildrenList = new List<Node>();
        private List<Node> SiblingsList = new List<Node>();

        #endregion

        #region Public Functions
        /// <summary>
        /// gets a child node and assigns it to the childrenlist
        /// </summary>
        /// <param name="child"></param>
        public void AddChild(Node child)
        {

        }

        #endregion
    }
}
