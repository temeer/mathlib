using System;
using System.Linq;
using MoreLinq;

namespace mathlib.Functions
{
    public class Walsh
    {
        public static Func<double, double> Get(int n)
        {
            var binary = Common.ToBinary(n);

            double Func(double x)
            {
                var xBin = Common.ToBinary(x, binary.Length);
                var s = binary.EquiZip(xBin, (ei, ni) => ei * ni).Sum();
                return s % 2 == 0 ? 1 : -1;
            }

            return Func;
        }
    }
}