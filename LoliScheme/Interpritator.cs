using LoliScheme.Types;
using System;

namespace LoliScheme 
{
    public static class Interpritator
    {
        public static string Eval(this string expression) 
        {
            var lexer = new Lexer.LexcalAnalizator();
            lexer.AnalizBracket(expression);
            Type type = lexer.TypeOfExpression(expression);

            switch (type.Name)
            {
                case nameof(LoliInt): 
                    return Parser.FromString<LoliInt>(expression).Calculate().ToString();
                default:
                    return "";
            }
        }
    }
}
