using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scanner;
using Parser.Tree;

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
        private Node HeadNode = new Node();
        #endregion

        /// <summary>
        /// calls appropriate Grammar Rule for a certain token
        /// Advance input 
        /// </summary>
        /// <param name="token"></param>
        
        //MatchExpression
        public void MatchExpression(Node node, Token token,GrammarRule Gr)
        {
            throw new NotImplementedException();
            //Don't Advance 
            //Created node is always a child
        }


        /// <summary>
        /// ana hna haftared en elly gayly mn west el function da lazem hyb2a child
        /// </summary>
        /// <param name="node"></param>
        /// <param name="GR"></param>
        /// 
        //MatchStatement
        public void MatchStatement(Node node , bool isSibling)
        {

            Node newNode = new Node();
            if (isSibling)
            {
                throw new NotImplementedException();
            }
            else
            {
                node.AddChild(newNode);
            }
            //GR.execute(newNode);
        }

        public void MatchStatmentSequence(Node node) {
            GrStmtSequence stmtSeq = new GrStmtSequence();
            stmtSeq.execute(node);
        }
        // da elly ana 3mlah
       
        public void Done() {
        }
    }
}
