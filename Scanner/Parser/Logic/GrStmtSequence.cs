using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.CustomTree;
using Scanner;

namespace Parser.Logic
{
    public class GrStmtSequence : GrammarRule
    {
        public override void execute(Node node)
        {
            // match first statement
            Controller.getInstance().MatchStatement(node, false);
            // match semicolon 
            MatchSemiColon();
            // loop till there is no more tokens  
            while (Parser.getInstance().GetNextToken().tokenValue != "$")
            {
                if (node.GetLastChild() != null) {

                    Controller.getInstance().MatchStatement(node.GetLastChild(), true);
                    MatchSemiColon();

                }
                
            }

            // notify done 
            Controller.getInstance().Done();
            
        }

        private void MatchSemiColon() {
            Token expToken = new Token();
            expToken.TokenType = Scanner.Scanner.SPECIAL_SYMBOLS.SEMICOLON.ToString();

            Boolean Matched = MatchInput(expToken);
            if (Matched) {
                Parser.getInstance().AdvanceInput();
            }
        }
    }
}
