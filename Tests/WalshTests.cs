using System.Linq;
using mathlib.Functions;
using NUnit.Framework;

namespace Tests
{
    public class WalshTests
    {
        [Test]
        public void GetTest()
        {
            var w0 = Walsh.Get(0);
            Assert.That(Enumerable.Range(0, 100).Select(i => w0(i / 100.0)).All(x => x == 1));

            var w1 = Walsh.Get(1);
            for (int i = 0; i < 100; i++)
            {
                var x = i / 100.0;
                if (x < 0.5)
                    Assert.AreEqual(1.0, w1(x));
                if (x > 0.5)
                    Assert.AreEqual(-1.0, w1(x));
            }

            var w3 = Walsh.Get(3);
            for (int i = 0; i < 100; i++)
            {
                var x = i / 100.0;
                if (x < 0.25)
                    Assert.AreEqual(1.0, w3(x));
                if (x > 0.75)
                    Assert.AreEqual(1.0, w3(x));
                if (x > 0.25 && x < 0.75)
                    Assert.AreEqual(-1.0, w3(x));

            }
        }
    }
}