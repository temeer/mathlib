using mathlib;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class LinearSystemTests
    {
        [Test]
        public void SolveTest()
        {
            var a = new double[,]
            {
                {1, 1},
                {1, -1}
            };
            var b = new double[] {1, 3};

            var x = LinearSystem.Solve(a, b);

            Assert.AreEqual(new[] {2.0,-1},x);
        }
    }
}