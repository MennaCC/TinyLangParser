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
    class GrExp : GrammarRule
    {
        //exp->sexp[compop sexp]
        string compop1 = Scanner.Scanner.SPECIAL_SYMBOLS.LESSTHAN.ToString();
        string compop2 = Scanner.Scanner.SPECIAL_SYMBOLS.EQUALTO.ToString();
        
        Boolean match;
        Token nxt = new Token();
        GrSimpleExp sexp = new GrSimpleExp();

        public override void execute(Node node)
        {
           

            Controller.getInstance().MatchExpression(node,Parser.getInstance().GetNextToken(),sexp);
           
            if (Parser.getInstance().GetNextToken().TokenType == compop1 || Parser.getInstance().GetNextToken().TokenType == compop2)
            {
                Controller.getInstance().MatchExpression(node,Parser.getInstance().GetNextToken(),sexp);
               // Parser.getInstance().AdvanceInput();
            }
           
        }
    }
}
