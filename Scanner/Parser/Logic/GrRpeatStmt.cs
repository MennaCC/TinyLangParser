using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scanner;
using Parser.Tree;

namespace Parser.Logic
{
    class GrRepeatStmt:GrammarRule
    {
        
  
        //repeat->repeat stmtseq until exp

        Token ex = new Token();
        GrExp exp = new GrExp();
        Boolean match;
        public override void execute(Node node)
        {
            
            Controller.getInstance().MatchStatmentSequence(node);
            ex.TokenType = Scanner.Scanner.RESERVED_WORDS.UNTIL.ToString();
            match = MatchInput(ex);
            if (match == true)
            {
                Parser.getInstance().AdvanceInput();
            }
             // el mafrod error 
           
            Controller.getInstance().MatchExpression(node, Parser.getInstance().GetNextToken(),exp);
            
        }

    }
}
