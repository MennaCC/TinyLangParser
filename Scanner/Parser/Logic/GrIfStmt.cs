using Scanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.Tree;

namespace Parser.Logic
{
    public class GrIfStmt : GrammarRule
    {
        public override void execute(Node node)
        {
            // if exp then stmtseq [else stmtseq] end

            // match exp
            Controller.getInstance().MatchExpression(node, Parser.getInstance().GetNextToken());

            // match the then token  
            Token thenToken = new Token();
            thenToken.TokenType = Scanner.Scanner.RESERVED_WORDS.THEN.ToString();
            Boolean thenMatched = MatchInput(thenToken);
            if (thenMatched) {
                // advance the then token 
                Parser.getInstance().AdvanceInput();
                // match stmt_seq
                Controller.getInstance().MatchStatmentSequence(node);
                
                // get the next token 
                Token nextToken = Parser.getInstance().GetNextToken();
                // if there is else part advance the else token then match stmt_seq
                if (nextToken.tokenValue == Scanner.Scanner.RESERVED_WORDS.ELSE.ToString())
                {
                    // advance the else token
                    Parser.getInstance().AdvanceInput();
                    // match the else stmt_seq
                    Controller.getInstance().MatchStatmentSequence(node);
                }
                
                //get the next token which must be end 
                nextToken = Parser.getInstance().GetNextToken();
                if (nextToken.tokenValue == Scanner.Scanner.RESERVED_WORDS.END.ToString())
                {
                    //advance the end token 
                    Parser.getInstance().AdvanceInput();
                }
            }

        }
    }
}
