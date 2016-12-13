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
            Token nextToken = new Token();
            nextToken = Parser.getInstance().GetNextToken();
            Token expToken = new Token();

            switch (nextToken.TokenType) {

                case "LEFTBRACKET":
                  
                    Parser.getInstance().AdvanceInput();
                    Controller.getInstance().MatchGrammarRule(node, new GrExp());
                    expToken.TokenType = "RIGHTBRACKET";
                    Boolean matched = MatchInput(expToken);
                    if (matched) {
                        Parser.getInstance().AdvanceInput();
                    }
                    break;

                case "NUMBER":
                    Node numChild = new Node();
                    numChild.Text = nextToken.tokenValue;
                    node.AddChild(numChild);
                    Parser.getInstance().AdvanceInput();
                    break;

                case "IDENTIFIER":
                    Node idChild = new Node();
                    idChild.Text = nextToken.tokenValue;
                    node.AddChild(idChild);
                    Parser.getInstance().AdvanceInput();
                    break;
            }

        }
    }
}
