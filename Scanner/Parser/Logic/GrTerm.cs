using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scanner;
using Parser.CustomTree;
namespace Parser.Logic
{
    class GrTerm:GrammarRule
    { 

        //term-> factor{mulopfactor}
        GrFactor factor = new GrFactor();
       GrMulOp malop = new GrMulOp();
        Token nxt = new Token();
        public override void execute(Node node)
        {
            Controller.getInstance().MatchExpression(node,Parser.getInstance().GetNextToken(),factor);
            Token op = Parser.getInstance().GetNextToken();
            string mul = Scanner.Scanner.SPECIAL_SYMBOLS.MULTIPLY.ToString();
            string div = Scanner.Scanner.SPECIAL_SYMBOLS.DIVIDE.ToString();
            while (op.TokenType == mul || op.TokenType == div)// mesh mot2keed
            {
                Controller.getInstance().MatchExpression(node,op,malop);
                Controller.getInstance().MatchExpression(node,op,factor);
                op = Parser.getInstance().GetNextToken();

            }



        }
    }
}
