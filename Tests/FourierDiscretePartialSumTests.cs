using System;
using mathlib;
using NUnit.Framework;
using NUnit.Framework.Internal;
using static System.Math;
using static System.Linq.Enumerable;

namespace Tests
{
    public class FourierDiscretePartialSumTests
    {
        [Test]
        public void GetValuesTest()
        {
            var basis = new Func<double, double>[]
            {
                x => 1,
                x => x,
                Cos,
            };

            var nodes = new[] {0, PI / 6, PI / 4, PI / 3, PI / 2};
            var partSum = new FourierDiscretePartialSum(nodes, basis);
            var df = partSum.GetValues(0, 0, 0);
            Assert.AreEqual(nodes, df.X);
            Assert.AreEqual(new[]{0d, 0, 0, 0, 0}, df.Y);

            df = partSum.GetValues(1, 2, 0);
            Assert.AreEqual(nodes, df.X);
            Assert.AreEqual(nodes.Select(t => 1 + 2 * t).ToArray(), df.Y);

            df = partSum.GetValues(1, 2, 3);
            Assert.AreEqual(nodes, df.X);
            Assert.AreEqual(nodes.Select(t => 1 + 2 * t + 3 * Cos(t)).ToArray(), df.Y);
        }
    }
}