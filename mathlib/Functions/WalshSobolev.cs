using System;
using System.Linq;

namespace mathlib.Functions
{
    public class WalshSobolev
    {
        public static Func<double, double> Get(int n)
        {
            double One(double x) => 1;
            if (n == 0)
                return One;

            var nodesCount = (int)Math.Pow(2, (int)Math.Ceiling(Math.Log(n, 2))+6);
            var nodes = Enumerable.Range(0, nodesCount).Select(j => j*1.0 / nodesCount);
            double Sobolev(double x)
            {
                return Integrals.Rectangular(Walsh.Get(n - 1), nodes.Where(node => node <= x).ToArray(), 
                    Integrals.RectType.Center);
            }

            return Sobolev;
        }
    }
}