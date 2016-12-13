using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scanner;

namespace Parser
{
    class Parser
    {
        #region Singleton 
        private static Parser instance;
        private Parser() { }
        public static Parser getInstance()
        {
            if (instance == null)
                instance = new Parser();
            return instance;
        }
        #endregion
        //list<token>
        //instance of controller
        //ip string
        Token currentToken;
        
        /// <summary>
        /// main entry point
        /// calls get tokensList 
        /// calls controller
        /// </summary>
        void init()
        {
            
        }

        /// <summary>
        /// get list of tokens from scanner
        /// </summary>
        void GetTokensList()
        {
            
        }
        /// <summary>
        /// return current token
        /// </summary>
        /// <returns></returns>
        public Token GetNextToken()
        {
            return null;
        }
        /// <summary>
        /// currentToken ++ 
        /// </summary>
        public void AdvanceInput()
        {

        }

    }
}
