using Scanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parser.Logic
{
    public class GrammarRule
    {

        /// <summary>
        /// handles the logic of matching the expected token to the input(next token)
        /// </summary>
        /// <param name="t"></param>
        public virtual void execute(TreeNode node) { }
        protected void MatchInput(Token t) { }
      
    }
}
