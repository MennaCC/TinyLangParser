using Scanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Logic
{
    interface IGrammarRule
    {
        /// <summary>
        /// handles the logic of matching the expected token to the input(next token)
        /// </summary>
        /// <param name="t"></param>

        void execute();
        void MatchInput(Token t);
      
    }
}
