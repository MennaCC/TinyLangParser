using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.Tree;

namespace Parser.Logic
{
    public class GrStmtSequence : GrammarRule
    {
        public override void execute(Node node)
        {
            // match first statement
            Controller.getInstance().MatchStatement(node, false);
            // match semicolon 

            // loop till there is no more tokens  
            while (true)
            {
                Controller.getInstance().MatchStatement(node, false);
            }

            // notify done 
            Controller.getInstance().Done();
            
        }
    }
}
