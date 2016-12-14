using Scanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.CustomTree;

namespace Parser.Logic
{
    public class GrWriteStmt : GrammarRule
    {
        public override void execute(Node node)
        {
            // match the write exp
            GrExp exp = new GrExp();
            Controller.getInstance().MatchExpression(node, Parser.getInstance().GetNextToken(), new GrExp());
            
        }
    }
}
