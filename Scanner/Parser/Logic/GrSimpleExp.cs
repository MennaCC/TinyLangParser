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
    class GrSimpleExp:GrammarRule
    {

       
            //SimpleExp->term{addop term}
            Token nxt = new Token();
            GrAddOp addop = new GrAddOp();
            GrTerm Term = new GrTerm();


            public override void execute(Node node)
            {
               
                Controller.getInstance().MatchExpression(node,Parser.getInstance().GetNextToken(),Term);// mesh moktn3a ????
                Token op = Parser.getInstance().GetNextToken();
                string opplus = Scanner.Scanner.SPECIAL_SYMBOLS.PLUS.ToString();
                string oppminus = Scanner.Scanner.SPECIAL_SYMBOLS.MINUS.ToString();
                while (op.TokenType == opplus || op.TokenType == oppminus)// mesh mot2keed
                {
                    
                    Controller.getInstance().MatchExpression(node,op,addop);
                    Controller.getInstance().MatchExpression(node,op,Term);
                    op = Parser.getInstance().GetNextToken();

            }

        }
        }
    }



