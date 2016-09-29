using mathlib;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class BinomialTests
    {
        [Test]
        public void BinomTest()
        {
            Assert.AreEqual(1, Binomial.Calc(2, 0));
            Assert.AreEqual(2, Binomial.Calc(2, 1));
            Assert.AreEqual(3, Binomial.Calc(3, 2));
        }
    }
}