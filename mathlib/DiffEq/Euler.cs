using System;

namespace mathlib.DiffEq
{
    public static class Euler
    {
        /// <summary>
        /// Solves Cauchy problem y'(x)=f(x,y), y(x0)=y0 on segment [x0,b]. 
        /// </summary>
        /// <param name="f"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="b"></param>
        /// <param name="n">Grid points count</param>
        /// <returns></returns>
        public static Tuple<double[], double[]> Solve(Func<double, double, double> f, double x0, double y0, double b, int n)
        {
            var y = new double[n];
            var x = new double[n];
            y[0] = y0;
            x[0] = x0;
            var h = (b - x0) / (n - 1);
            var xk = x0;
            for (int k = 0; k < n-1; k++)
            {
                y[k + 1] = y[k] + h * f(x[k], y[k]);
                x[k + 1] = x[k] + h;
            }
            return Tuple.Create(x, y);
        }
    }
}