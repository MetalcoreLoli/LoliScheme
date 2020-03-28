using LoliScheme.Types;
using NUnit.Framework;
namespace LoliScheme.Test
{
    public class LoliIntTest
    {
       
        [Test]
        public void AddTest()
        {
            LoliInt four = new LoliInt(2).Add(new LoliInt(2));
            LoliInt result = new LoliInt(4);

            Assert.AreEqual(result, four);
        }

        [Test]
        public void SubTest()
        {
            LoliInt zero = new LoliInt(2).Subtraction(new LoliInt(2));
            LoliInt result = new LoliInt(0);

            Assert.AreEqual(result, zero);
        }

        [Test]
        public void MulTest()
        {
            LoliInt four = new LoliInt(2).Multiplication(new LoliInt(2));
            LoliInt result = new LoliInt(4);

            Assert.AreEqual(result, four);
        }

        [Test]
        public void DivTest()
        {
            LoliInt one = new LoliInt(2).Division(new LoliInt(2));
            LoliInt result = new LoliInt(1);

            Assert.AreEqual(result, one);
        }
    }
}