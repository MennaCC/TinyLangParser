using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.Tree;
using Scanner;

namespace Parser.Logic
{
    public class GrReadStmt : GrammarRule
    {
        public override void execute(Node node)
        {
            Token expectedToken = new Token();
            expectedToken.TokenType = Scanner.Scanner.STATES.IDENTIFIER.ToString();
            Boolean matched = MatchInput(expectedToken);

            if (matched)
            {
                Parser.getInstance().AdvanceInput();
                if (node.Parent != null)
                {
                    Controller.getInstance().MatchGrammarRule(Parser.getInstance().GetNextToken());
                }
            }
        }
    }
}
