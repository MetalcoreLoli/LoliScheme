using LoliScheme.Core;
using LoliScheme.Lexer.Exceptions;
using LoliScheme.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoliScheme.Lexer
{
    public class LexcalAnalizator
    {
        public void AnalizBracket(string expression)
        {
            int countOfOpeningBracket = expression.CountOf('(');
            int countOfClosingBracket = expression.CountOf(')');

            if (countOfOpeningBracket > countOfClosingBracket)
                throw new SyntaxErrorException("Missed (");
            else if (countOfOpeningBracket < countOfClosingBracket)
                throw new SyntaxErrorException("Missed )");
            else if(countOfClosingBracket == 0 && countOfOpeningBracket == 0)
                    throw new SyntaxErrorException("Missed ( und )");
        }

        public Type TypeOfExpression(string expression)
        {
            List<object> values = new List<object>();
            for (int i = 1; i < expression.Length - 1; i++)
            {
                switch (expression[i - 1])
                {
                    case '(': continue;
                    case ')': continue;
                    case '+': continue;
                    case '-': continue;
                    case '*': continue;
                    case '/': continue;
                    case ' ': continue;

                    default:
                        int num = 0;
                        if (int.TryParse(
                            expression[i - 1].ToString(),
                            out num))
                        {
                            if (expression[i] != '.')
                                values.Add(new LoliInt(num));
                            else
                                continue;

                        }
                        break;
                }
            }

            if (values.TrueForAll(obj => obj is LoliInt))
                return typeof(LoliInt);
            else
                return null;

        }
    }
}