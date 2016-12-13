using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scanner;
using System.Windows.Forms;

namespace Parser.Logic
{
    class Controller
    {

        #region Singleton
        private static Controller instance;
        private Controller()
        {
            initGRDict();
        }
        public static Controller getInstance()
        {
            if (instance == null)
                instance = new Controller();
            return instance;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// fill the GRList with onstances of all Grammar Rules
        /// </summary>
        private void initGRDict()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Private Attributes 
        List<GrammarRule> GRDict = new List<GrammarRule>();
        private TreeNode HeadNode = new TreeNode();
        #endregion

        /// <summary>
        /// calls appropriate Grammar Rule for a certain token
        /// Advance input 
        /// </summary>
        /// <param name="token"></param>
        void MatchGrammarRule(Token token)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// ana hna haftared en elly gayly mn west el function da lazem hyb2a child
        /// </summary>
        /// <param name="node"></param>
        /// <param name="GR"></param>
        void MatchGrammarRule(TreeNode node , GrammarRule GR, bool isSibling)
        {

            TreeNode newNode = new TreeNode();
            if (isSibling)
            {
                throw new NotImplementedException();
            }
            else
            {
                node.Nodes.Add(newNode);
            }
            GR.execute(newNode);
        }
    }
}
