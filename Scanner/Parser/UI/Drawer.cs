using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parser.UI
{
    public class Drawer
    {

        #region Public Attributes
        public List<RectangleF> nodesList = new List<Rectangle>();
        public List<RectangleF> edgesList = new List<Rectangle>();
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

        #region Public Functions
        /// <summary>
        /// this should called by onPaint event in the drawing form 
        /// itt actually draws
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DrawGraphicalObjects(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangles(Pens.HotPink, edgesList);
        }
        #endregion


    }
}
