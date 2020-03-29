using NUnit.Framework;
using LoliScheme.Core;
using System.Linq;

namespace LoliScheme.Test
{
    public class StringHelperTest
    {

        [Test]
        public void TakeFromLastWhileTest()
        {
            string str = "+ 2 (+ 2 2) 2";
            
            string exceptedResult = " 2";
            string resultOfMethodsWork = str.TakeFromLastWhile(c => c != ')').Aggregate("", (acc, sym) => acc + sym);

            Assert.AreEqual(exceptedResult, resultOfMethodsWork);
        }


        [Test]
        public void CountOfTest()
        {
            string str = "(+ 2 (+ 2 2) 2)";

            int exceptedResult = 2;
            int resultOfMethodsWork = str.CountOf('(');

            Assert.AreEqual(exceptedResult, resultOfMethodsWork);
        }

        [Test]
        public void RemoveAllSymbolsTest()
        {
            string str = "(+ 2 (+ 2 2) 2)";

            string exceptedResult = " 2  2 2 2";
            string resultOfMethodsWork = str.RemoveAllSymbols('(');

            resultOfMethodsWork = resultOfMethodsWork.RemoveAllSymbols(')');
            resultOfMethodsWork = resultOfMethodsWork.RemoveAllSymbols('+');

            Assert.AreEqual(exceptedResult, resultOfMethodsWork);
        }
    }
}
