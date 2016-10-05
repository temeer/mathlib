using mathlib;
using NUnit.Framework;

namespace Tests
{
    public class CommonTests
    {
        [Test]
        public void FactorialTest()
        {
            Assert.That(Common.Factorial(5), Is.EqualTo(120));
        }
    }
}