using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scanner;
using Parser.CustomTree;
using Parser.UI;

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
            GRDict.Add(START_TOKEN.IDENTIFIER.ToString(), new GrAssignStmt());
            GRDict.Add(START_TOKEN.IF.ToString(), new GrIfStmt());
            GRDict.Add(START_TOKEN.READ.ToString(), new GrReadStmt());
            GRDict.Add(START_TOKEN.REPEAT.ToString(), new GrRepeatStmt());
            GRDict.Add(START_TOKEN.WRITE.ToString(), new GrWriteStmt());
        }
        #endregion

        #region Private Attributes 
        private Node HeadNode = new Node();
        private enum START_TOKEN { IF, REPEAT, READ, WRITE, IDENTIFIER }
        Dictionary<string, GrammarRule> GRDict = new Dictionary<string, GrammarRule>();

        #endregion

        #region Public Methods
        /// <summary>
        /// calls appropriate Grammar Rule for a certain token
        /// Advance input 
        /// </summary>
        /// <param name="token"></param>
        public void MatchExpression(Node node, Token token, GrammarRule GR)
        {
            string grType = GR.GetType().ToString();
            if (GR.GetType() == typeof(GrExp))
            {
                Node nodeNew = new Node(grType);
                node.AddChild(nodeNew);
                //Match Grammar Rule
                GR.execute(nodeNew);
            }
            else {
                node.Text = grType;
                GR.execute(node);
            }
            
            
        }

        /// <summary>
        /// Matches Statement to next token 
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
                node.AddSibling(newNode);
            }

            else
            {
                node.AddChild(newNode);
            }
            //match the current token to the next Grammar Rule
            Token nextToken = Parser.getInstance().GetNextToken();
            GrammarRule gr = GRDict[nextToken.TokenType];
            Parser.getInstance().AdvanceInput();
            newNode.Text = gr.GetType().ToString();
            gr.execute(newNode);
            //advance the input 
            //Parser.getInstance().AdvanceInput();

        }

        public void MatchStatmentSequence(Node node) {
            GrStmtSequence stmtSeq = new GrStmtSequence();
            stmtSeq.execute(node);
        }
               
        public void Done() {
            Drawer.getInstance().initAndDraw();
            TreeForm.getInstance().Show();
        }
        #endregion
    }
}
