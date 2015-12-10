using mathlib;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class MatrixTests
    {
        [Test]
        public void AdjointTest()
        {
            var m = new double[,]
            {
                {1, 2, 3},
                {4, 5, 6},
            };
            var adj = Matrix.Adjoint(m);

            Assert.AreEqual(new double[,]
            {
                {1, 4},
                {2, 5},
                {3, 6}
            }, adj);
        }
    }
}