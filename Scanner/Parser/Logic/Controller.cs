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

        }
        public static Controller getInstance()
        {
            if (instance == null)
                instance = new Controller();
            return instance;
        }
        #endregion

        #region Private Attributes 
        List<GrammarRule> GRList = new List<GrammarRule>();
        #endregion

        //list<Node>
        /// <summary>
        /// calls appropriate Grammar Rule for a certain token
        /// Advance input 
        /// </summary>
        /// <param name="token"></param>
        void MatchGrammarRule(Token token)
        {
           
        }
        void MatchGrammarRule(TreeNode node , GrammarRule GR)
        {

        }
    }
}
