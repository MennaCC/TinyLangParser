using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.UI
{
    class Diagram
    {
        #region public functions
        /// <summary>
        /// called to add a Node to the diagram
        /// </summary>
        /// <param name="newNode"></param>
        public void addNode(Node newNode)
        {

        }

        #endregion

        #region private functions
        /// <summary>
        /// gets the location of the node w.r.t current node
        /// </summary>
        private void getNodeLocation()
        {

        }

        #endregion
        #region private attributes

        private List<Node> nodesList = new List<Node>();
        private Node currentNode = new Node();
        #endregion


        #region Thinking 
        /// <summary>
        /// when terminal is reached a node is made,
        /// it is added to childenList of its parentNode, 
        /// if parentNode is Null, then the node is the head node of the program
        /// 
        /// </summary>
        #endregion

    }
}
