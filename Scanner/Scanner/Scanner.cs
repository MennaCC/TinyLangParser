using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner
{
    public class Scanner
    {
        public enum RESERVED_WORDS { IF, THEN, ELSE, END, REPEAT, UNTIL, READ, WRITE };
        public enum SPECIAL_SYMBOLS { PLUS, MINUS, MULTIPLY, DIVIDE, EQUALTO, LESSTHAN, LEFTBRACKET, RIGHTBRACKET, SEMICOLON };
        public enum STATES { START, NUMBER, IDENTIFIER, ASSIGN, INCOMMENT, DONE, SPECIALSYMBOLS };


        List<Token> tokensList = new List<Token>();

        public List<Token> getListOfTokens(string file)
        {
            string state = STATES.START.ToString();
            string lastState = STATES.START.ToString();
            string currentTokenValue = "";
            int i = 0;
            while (true)
            {
                if (i > file.Length - 1) break;
                char character = file[i];
                switch (state)
                {
                    case "START":
                        if (Char.IsWhiteSpace(character))
                        {
                            state = STATES.START.ToString();
                        }
                        else if (char.IsDigit(character))
                        {
                            state = STATES.NUMBER.ToString();
                            currentTokenValue += character;
                        }
                        else if (char.IsLetter(character))
                        {
                            state = STATES.IDENTIFIER.ToString();
                            currentTokenValue += character;
                        }
                        else if (character == ':')
                        {
                            state = STATES.ASSIGN.ToString();
                            currentTokenValue += character;
                        }
                        else if (character == '{')
                        {
                            state = STATES.INCOMMENT.ToString();
                        }
                        else if (character == '+' || character == '-' || character == '*' || character == '/' || character == '=' || character == '<' || character == ')' || character == '(' || character == ';')
                        {
                            currentTokenValue += character;
                            state = STATES.SPECIALSYMBOLS.ToString();
                        }
                        else
                        {
                            state = STATES.DONE.ToString();
                        }
                        lastState = state;
                        break;

                    case "NUMBER":
                        if (char.IsDigit(character))
                        {
                            currentTokenValue += character;
                            state = STATES.NUMBER.ToString();
                        }
                        else
                        {
                            state = STATES.DONE.ToString();
                        }
                        break;

                    case "IDENTIFIER":
                        if (char.IsLetter(character))
                        {
                            currentTokenValue += character;
                            state = STATES.IDENTIFIER.ToString();
                        }
                        else
                        {
                            state = STATES.DONE.ToString();
                        }
                        break;

                    case "ASSIGN":
                        if (character == '=')
                        {
                            currentTokenValue += character;
                            state = STATES.DONE.ToString();

                        }
                        else
                        {
                            state = STATES.DONE.ToString();
                        }
                        break;

                    case "SPECIALSYMBOLS":

                        state = STATES.DONE.ToString();
                        break;

                    case "INCOMMENT":

                        if (character == '}')
                        {
                            state = STATES.START.ToString();
                        }
                        else
                        {
                            state = STATES.INCOMMENT.ToString();
                        }
                        break;

                    case "DONE":

                        Token token = new Token();
                        if (lastState == "SPECIALSYMBOLS")
                        {
                            token.tokenValue = currentTokenValue;
                            token.TokenType = getSpecialSymbolsTokenType(currentTokenValue);
                            //Console.WriteLine(currentTokenValue + "    " + token.TokenType);
                        }
                        else if (lastState == "IDENTIFIER")
                        {
                            token.tokenValue = currentTokenValue;
                            token.TokenType = getReservedWordsTokenType(currentTokenValue);
                            //Console.WriteLine(currentTokenValue + "    " + token.TokenType);
                        }
                        else
                        {
                            token.tokenValue = currentTokenValue;
                            token.TokenType = lastState;
                            //Console.WriteLine(currentTokenValue + "    " + lastState);
                        }
                        tokensList.Add(token);
                        currentTokenValue = "";
                        state = STATES.START.ToString();
                        lastState = STATES.DONE.ToString();
                        break;
                }
                if (state != "DONE" || lastState != "DONE") { i++; }
            }
            return tokensList;
        }

        public string getSpecialSymbolsTokenType(string value)
        {

            if (value[0] == '+') { return SPECIAL_SYMBOLS.PLUS.ToString(); }
            else if (value[0] == '-') { return SPECIAL_SYMBOLS.MINUS.ToString(); }
            else if (value[0] == '*') { return SPECIAL_SYMBOLS.MULTIPLY.ToString(); }
            else if (value[0] == '/') { return SPECIAL_SYMBOLS.DIVIDE.ToString(); }
            else if (value[0] == '=') { return SPECIAL_SYMBOLS.EQUALTO.ToString(); }
            else if (value[0] == '<') { return SPECIAL_SYMBOLS.LESSTHAN.ToString(); }
            else if (value[0] == ')') { return SPECIAL_SYMBOLS.RIGHTBRACKET.ToString(); }
            else if (value[0] == '(') { return SPECIAL_SYMBOLS.LEFTBRACKET.ToString(); }
            else if (value[0] == ';') { return SPECIAL_SYMBOLS.SEMICOLON.ToString(); }
            else return null;
        }

        public string getReservedWordsTokenType(string value)
        {

            if (value == "if") { return RESERVED_WORDS.IF.ToString(); }
            else if (value == "then") { return RESERVED_WORDS.THEN.ToString(); }
            else if (value == "else") { return RESERVED_WORDS.ELSE.ToString(); }
            else if (value == "end") { return RESERVED_WORDS.END.ToString(); }
            else if (value == "repeat") { return RESERVED_WORDS.REPEAT.ToString(); }
            else if (value == "until") { return RESERVED_WORDS.UNTIL.ToString(); }
            else if (value == "read") { return RESERVED_WORDS.READ.ToString(); }
            else if (value == "write") { return RESERVED_WORDS.WRITE.ToString(); }
            else return STATES.IDENTIFIER.ToString();
        }
    }
}
