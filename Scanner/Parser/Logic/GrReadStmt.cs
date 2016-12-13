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
            // match the read identifier
            Token expectedToken = new Token();
            expectedToken.TokenType = Scanner.Scanner.STATES.IDENTIFIER.ToString();
            Boolean matched = MatchInput(expectedToken);

            if (matched)
            {
                // modify the read node text to add the identifier name
                node.Text = node.Text + " " + Parser.getInstance().GetNextToken().tokenValue;
                // advance the identifier
                Parser.getInstance().AdvanceInput();
            }
        }
    }
}
