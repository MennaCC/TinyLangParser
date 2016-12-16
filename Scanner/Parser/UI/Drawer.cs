using Parser.CustomTree;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Parser.UI
{
    public class Drawer
    {

        #region Drawing Properties
        private Pen drawingPen = Pens.HotPink;
        #endregion


        #region Private Attributes
        private Parser parserInstance = Parser.getInstance();
        private Dictionary<int, List<Node>> nodesLevelsMap = new Dictionary<int, List<Node>>();
        #endregion

        #region Public Attributes
        public List<Graphics> nodesList = new List<Graphics>();
        public List<KeyValuePair<Point, Point>> edgesList = new List<KeyValuePair<Point, Point>>();

        public int NumberOfLevel;
        public int HeightForm;
        public int WidthForm;
        public List<Node> value = new List<Node>();
        public int key3;
        public  int CountN =0;
        Node n;

        #endregion

        #region Singleton
        private Drawer() {
        }
        private static Drawer instance;

        public static Drawer getInstance()
        {
            if (instance == null)
                instance = new Drawer();
            return instance;
        }
        #endregion

        #region JOJO
        #region Drawing
        /// <summary>
        /// this should called by onPaint event in the drawing form 
        /// itt actually draws
        /// Assignee: Menna & JOJO
        /// </summary>
        /// 
        public void DrawGraphicalObjects(object sender, PaintEventArgs e)
        {
            DrawEdges(e);
            CreateGraphicObject();
        }

        private void DrawEdges(PaintEventArgs e)
        {
            foreach (KeyValuePair<Point, Point> pointsPair in edgesList)
            {
                e.Graphics.DrawLine(drawingPen, pointsPair.Key, pointsPair.Value);
            }
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
            NumberOfLevel = nodesLevelsMap.Count;

            HeightForm = TreeForm.getInstance().ClientRectangle.Height;
            WidthForm = TreeForm.getInstance().ClientRectangle.Width;

            foreach (var kvp in nodesLevelsMap)
            {
                value = kvp.Value;
                key3 = kvp.Key;
                foreach(Node v in value)
                {
                    CountN++; 
                    v.position.Y =((key3 *(HeightForm/NumberOfLevel))+((HeightForm/NumberOfLevel)/2));
                    v.position.X = (((WidthForm/value.Count)*CountN)/2)+CountN;
                    CreateGraphicObject();
                }
                CountN = 0;
            }

        }
        public void CreateGraphicObject()
        {
          
            Graphics g = TreeForm.getInstance().CreateGraphics();
            g.DrawEllipse(Pens.Red, n.position.X, n.position.Y, 60, 60);
            nodesList.Add(g);

        }
        #endregion
        #endregion

        #region Menna

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
            foreach (Node node in parserInstance.parserTree.getNodesList())
            {
                nodesLevelsMap[node.Level].Add(node);
            }
        }

        #region Edges Creation
        /// <summary>
        /// makes use of Recursive function and list of nodes to create linkage between them 
        /// adds calculated edges to (edgesList)
        /// 
        /// Assignee: Menna
        /// </summary>
        private void CreateGEdges()
        {
            Node HeadNode = parserInstance.parserTree.HeadNode;
            ConnectChildrenNodesRecursive(HeadNode);
            ConnectSiblingNodesRecursive(HeadNode);
        }

        private void ConnectChildrenNodesRecursive(Node parentNode)
        {
            if (parentNode.isLeaf)
                return;
            {
                //create edges between the node and each of its children
                foreach(Node childNode in parentNode.Children)
                {
                    Connect(parentNode, childNode);
                    ConnectChildrenNodesRecursive(childNode);
                }
            }

        }

        private void ConnectSiblingNodesRecursive(Node parentNode)
        {
            if (parentNode.isLonely)
                return;

            {
                //create edges between node and its first sibling 
                Connect(parentNode, parentNode.Siblings[0]);
                //create edges between sibling and the next silbling
                List<Node> sibs = parentNode.Siblings;
                for (int i=0; i<sibs.Count; i++)
                {
                    Connect(sibs[i], sibs[i+1]);
                    //call this same function foreach of the siblings and children nodes
                    ConnectSiblingNodesRecursive(sibs[i]);
                }
               
            }
        }

        private void Connect(Node start, Node end)
        {
            KeyValuePair<Point, Point> pair = new KeyValuePair<Point, Point>(start.position, end.position);
            edgesList.Add(pair);
        }

        #endregion
        #endregion



    }
}
