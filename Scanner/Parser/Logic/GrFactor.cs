using Scanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.Tree;

namespace Parser.Logic
{
    public class GrFactor : GrammarRule
    {
        public override void execute(Node node)
        {
            // (exp)  or  number or identifier 

            // get the next token 
            Token nextToken = new Token();
            nextToken = Parser.getInstance().GetNextToken();
            Token expToken = new Token();

            switch (nextToken.TokenType) {

                case "LEFTBRACKET":
                    // advance the left barcket
                    Parser.getInstance().AdvanceInput();
                    // match the exp
                    Controller.getInstance().MatchExpression(node, nextToken);
                    //match the right bracket
                    expToken.TokenType = "RIGHTBRACKET";
                    Boolean matched = MatchInput(expToken);
                    if (matched) {
                        //advance the right bracket
                        Parser.getInstance().AdvanceInput();
                    }
                    break;

                case "NUMBER":
                    // create a child node for the number
                    Node numChild = new Node();
                    numChild.Text = nextToken.tokenValue;
                    node.AddChild(numChild);
                    //advance the number
                    Parser.getInstance().AdvanceInput();
                    break;

                case "IDENTIFIER":
                    // create a child node for the identifier
                    Node idChild = new Node();
                    idChild.Text = nextToken.tokenValue;
                    node.AddChild(idChild);
                    // advance the identifier
                    Parser.getInstance().AdvanceInput();
                    break;
            }

        }
    }
}
