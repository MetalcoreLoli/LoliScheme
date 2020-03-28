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
    }
}
