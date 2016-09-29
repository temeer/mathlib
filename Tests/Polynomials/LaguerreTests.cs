using System.Linq;
using NUnit.Framework;

namespace Tests.Polynomials
{
    [TestFixture]
    public class LaguerreTests
    {
        [Test]
        public void LaguerreTest()
        {
            var lag1 = mathlib.Polynomials.Laguerre.Get(1);

        }

        [Test]
        public void CoeffsTest()
        {
            var coeffs = mathlib.Polynomials.Laguerre.Coeffs(0);
            Assert.AreEqual(new[] { 1d }, coeffs);

            coeffs = mathlib.Polynomials.Laguerre.Coeffs(1);
            Assert.AreEqual(new[] { 1d, -1 }, coeffs);

            coeffs = mathlib.Polynomials.Laguerre.Coeffs(2);
            Assert.AreEqual(new[] { 1d, -2, 0.5 }, coeffs);


            coeffs = mathlib.Polynomials.Laguerre.Coeffs(5);
            Assert.That(coeffs, Is.EqualTo(new[] { 120d, -600, 600, -200, 25, -1 }.Select(x => x / 120).ToArray()).Within(1e-10));
        }
    }
}