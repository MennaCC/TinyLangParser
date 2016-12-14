﻿using Scanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.CustomTree;

namespace Parser.Logic
{
    public class GrAddOp : GrammarRule
    {
        public override void execute(Node node)
        {
          
            // + or -

            // prepare the expected tokens
            Token plusToken = new Token();
            plusToken.TokenType = Scanner.Scanner.SPECIAL_SYMBOLS.PLUS.ToString();
            Token minusToken = new Token();
            minusToken.TokenType = Scanner.Scanner.SPECIAL_SYMBOLS.MINUS.ToString();

            // try to match + and -
            Boolean plusMatched = MatchInput(plusToken);
            Boolean minusMatched = MatchInput(minusToken);

            //if any matched
            if (plusMatched || minusMatched)
            {
                //create a child for the matched addop
                Node child = new Node();
                child.Text = Parser.getInstance().GetNextToken().tokenValue;
                node.AddChild(child);
                // advance the operation 
                Parser.getInstance().AdvanceInput();

            }
        }
    }
}
