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
    class GrAssignStmt:GrammarRule
    {
        public override void execute(Node node)
        {
            //assign->id := exp
            Token next = Parser.getInstance().GetNextToken();
            Token ex = new Token();
            Token nxt = new Token();
            GrExp exp = new GrExp();
            ex.TokenType = Scanner.Scanner.STATES.IDENTIFIER.ToString();


            Boolean match = MatchInput(ex);
            if (match == true)
            {
                node.Text = node.Text + "  ( " + next + " )";
                Parser.getInstance().AdvanceInput();//get current next token 
            }
           
            ex.TokenType = Scanner.Scanner.STATES.ASSIGN.ToString();
            match = MatchInput(ex);
            if (match == true)
            {
                Parser.getInstance().AdvanceInput();
            }
          
            Controller.getInstance().MatchExpression(node,Parser.getInstance().GetNextToken(),exp);
            

        }
    }
}
