using System;

namespace mathlib
{
    public static class LinearSystem
    {
        /// <summary>
        /// Finds X vector in linear system AX=B. Rows count in matrix A must be equal to that in vector B.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static double[] Solve(double[,] A, double[] B)
        {
            int info;
            alglib.matinvreport rep;
            alglib.rmatrixinverse(ref A, out info, out rep);
            //alglib.ma
            throw new NotImplementedException();
        }
    }
}