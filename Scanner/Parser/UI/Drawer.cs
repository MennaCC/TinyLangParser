﻿using Parser.CustomTree;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parser.UI
{
    public class Drawer
    {

        #region Private Attributes
        private Dictionary<int, List<Node>> nodesLevelsMap = new Dictionary<int, List<Node>>();
        #endregion

        #region Public Attributes
        public List<RectangleF> nodesList = new List<RectangleF>();
        public List<RectangleF> edgesList = new List<RectangleF>();
        #endregion

        #region Singleton
        private Drawer() { }
        private static Drawer instance;

        public static Drawer getInstance()
        {
            if (instance == null)
                instance = new Drawer();
            return instance;
        }
        #endregion

        #region JOJO
        #region Public Functions
        /// <summary>
        /// this should called by onPaint event in the drawing form 
        /// itt actually draws
        /// Assignee: Menna & JOJO
        /// </summary>
        /// 
        public void DrawGraphicalObjects(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangles(Pens.HotPink, edgesList.ToArray());
            e.Graphics.DrawRectangles(Pens.HotPink, nodesList.ToArray());
        }

        /// <summary>
        /// * calculates position of each node based on its level and the no.of nodes that are in its same level
        /// * adds the calculated position point to the (Position) attribute in (Node) class
        /// * creates a graphic object (rectangle or ellipse) for the node and add it to (nodesList) in this classs
        /// 
        /// input: nodesLevelsMap (in this class) 
        /// output: calculated position & created GObjects
        /// 
        /// Note: hab2a an2elha fl private ba3d ma n5allas 34an a3rf a7ottelek btoo3k f region 3 b3daha :D 
        /// 
        /// Assignee: JOJO
        /// </summary>
        private void CreateGNodes()
        {

        }
        #endregion
        #endregion

        #region Menna
        #region Private Functions
        /// <summary>
        /// fill Dict 
        /// groups nodes by levels in a dictionary to be able to draw nodes by levels
        /// 
        /// input: Tree
        /// output: nodes grouped by level in the nodesLevelsDict
        /// 
        /// Assignee: Menna
        /// </summary>
        private void GroupNodesByLevel()
        {

        }

        /// <summary>
        /// makes use of Recursive function and list of nodes to create linkage between them 
        /// adds calculated edges to (edgesList)
        /// 
        /// Assignee: Menna
        /// </summary>
        private void CreateGEdges()
        {

        }
        #endregion
        #endregion



    }
}
