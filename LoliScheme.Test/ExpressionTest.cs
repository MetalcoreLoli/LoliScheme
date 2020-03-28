using LoliScheme.Core;
using LoliScheme.Operations;
using LoliScheme.Types;
using NUnit.Framework;

namespace LoliScheme.Test
{
    public class ExpressionTest
    {
        Expression<LoliInt> one;
        Expression<LoliInt> two;

        [SetUp]
        public void SetUp()
        {
            one = new Expression<LoliInt>(1);
            two = new Expression<LoliInt>(2);
        }


        [Test]
        public void EqualsTest()
        {
            Expression<LoliInt> anotherOne = new Expression<LoliInt>(1);

            Assert.That(one.Equals(two), Is.False);
            Assert.That(one.Equals(anotherOne), Is.True);
        }

        [Test]
        public void ToStringTest()
        {
            Expression<LoliInt> anotherOne = new Expression<LoliInt>(1);
            Expression<LoliInt> add 
                = new Expression<LoliInt>(
                    Operation.Add, 
                    new Expression<LoliInt>(Operation.Mul, anotherOne, one), 
                    two);

            Assert.AreEqual("(+ (* 1 1) 2)", add.ToString());
            Assert.AreEqual("1", anotherOne.ToString());
        }

        [Test]
        public void AddBranchTest()
        {
            Expression<LoliInt> add = new Expression<LoliInt>(Operation.Add, one, two);

            LoliInt resulOfCalculation = add.Calculate();
            LoliInt result = new LoliInt(3);

            Assert.AreEqual(result, resulOfCalculation);
        }

        [Test]
        public void SubBranchTest()
        {
            Expression<LoliInt> sub = new Expression<LoliInt>(Operation.Sub, one, two);

            LoliInt resulOfCalculation = sub.Calculate();
            LoliInt result = new LoliInt(-1);

            Assert.AreEqual(result, resulOfCalculation);
        }

        [Test]
        public void MulBranchTest()
        {
            Expression<LoliInt> mul = new Expression<LoliInt>(Operation.Mul, one, two);

            LoliInt resulOfCalculation = mul.Calculate();
            LoliInt result = new LoliInt(2);

            Assert.AreEqual(result, resulOfCalculation);
        }

        [Test]
        public void DivBranchTest()
        {
            Expression<LoliInt> div = new Expression<LoliInt>(Operation.Div, one, two);

            LoliInt resulOfCalculation = div.Calculate();
            LoliInt result = new LoliInt(0);

            Assert.AreEqual(result, resulOfCalculation);
        }
    }
}
