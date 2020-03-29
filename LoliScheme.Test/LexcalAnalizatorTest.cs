using NUnit.Framework;
using LoliScheme.Core;
using LoliScheme.Types;
using LoliScheme.Operations;
using LoliScheme.Lexer;
using LoliScheme.Lexer.Exceptions;

namespace LoliScheme.Test
{
    public class LexcalAnalizatorTest
    {
        LexcalAnalizator lexer;

        [SetUp]
        public void SetUp()
        {
            lexer = new LexcalAnalizator();
        }

        [Test]
        public void AnalizBracketTest()
        {
            string expression = "+ 2 2)";
            string expressionOne = "(+ 2 2";
            string expressionTwo = "+ 2 2";

            Assert.Throws<SyntaxErrorException>(() => lexer.AnalizBracket(expression));
            Assert.Throws<SyntaxErrorException>(() => lexer.AnalizBracket(expressionOne));
            Assert.Throws<SyntaxErrorException>(() => lexer.AnalizBracket(expressionTwo));
        }

        [Test]
        public void TypeOfExpressionTest()
        {
            string expression = "(+ 2 (* 2 2) 2 (+ 1 1))";

            Assert.That(lexer.TypeOfExpression(expression) == typeof(LoliInt), Is.True);
        }
    }
}
