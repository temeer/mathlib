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

        [Test]
        public void MulTest()
        {
            var a = new double[,]
            {
                {1, 2, 3},
                {1, -1, 0}
            };
            var b = new double[,]
            {
                {1, -1},
                {0, 2},
                {1, 0}
            };

            var ab = Matrix.Mul(a, b);

            Assert.AreEqual(2, ab.GetLength(0));
            Assert.AreEqual(2, ab.GetLength(1));

            Assert.AreEqual(new double[,]
            {
               {4,3},
               {1,-3}
            }, ab);
        }
    }
}