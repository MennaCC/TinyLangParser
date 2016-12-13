using Scanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.Tree;

namespace Parser.Logic
{
    public class GrComparisonOp : GrammarRule
    {
        public override void execute(Node node)
        {
            Token expectedToken = new Token();
            expectedToken.TokenType = Scanner.Scanner.SPECIAL_SYMBOLS.LESSTHAN.ToString();
            Token secondExpectedToken = new Token();
            secondExpectedToken.TokenType = Scanner.Scanner.SPECIAL_SYMBOLS.EQUALTO.ToString();
            Boolean matched = MatchInput(expectedToken);
            Boolean secondMatched = MatchInput(secondExpectedToken);

            if (matched || secondMatched) {

                Node child = new Node();
                child.Text = Parser.getInstance().GetNextToken().tokenValue;
                node.AddChild(child);

                Parser.getInstance().AdvanceInput();
                if (node.Parent != null)
                {
                    Controller.getInstance().MatchGrammarRule(Parser.getInstance().GetNextToken());
                }
            }
        }
    }
}
