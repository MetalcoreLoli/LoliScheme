using LoliScheme.Core;
using LoliScheme.Operations;
using LoliScheme.Types;
using NUnit.Framework;

namespace LoliScheme.Test
{
    public class ParserTest
    {
        Parser parser;

        [SetUp]
        public void SetUp()
        {
            parser = new Parser();
        }

        [Test]
        public void FromStringTest()
        {
            string expression = "(+ 1 (+ 2 3) (+ (+ 2 2) 5) (+ 6 7))";
            Expression<LoliInt> resultOfParser = Parser.FromString<LoliInt>(expression);
            
            string result = "(+ 1 (+ 5 (+ 9 13)))";
            LoliInt resultOfCalculation = new LoliInt(28);
            
            Assert.AreEqual(result, resultOfParser.ToString());
            Assert.AreEqual(resultOfCalculation, resultOfParser.Calculate());
        }

        [Test]
        public void CreateExpressionTest()
        {

            string result = "(+ 1 (+ 2 3))";
            Expression<LoliInt> resultOfParser = Parser.CreateExpression<LoliInt>(Operation.Add, 1, 2, 3);
            LoliInt resultOfCalculation = new LoliInt(6);
            
            Assert.AreEqual(result, resultOfParser.ToString());
            Assert.AreEqual(resultOfCalculation, resultOfParser.Calculate());
        }
    }
}
