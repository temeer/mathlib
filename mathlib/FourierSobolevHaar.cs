using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mathlib
{
    public static class FourierSobolevHaar
    {
        public static double Calc(double[] p, double x)
        {
            int length = p.Length;
            double result = 0;

            for (int n = 0; n < length; n++)
                result += p[n] * MixHaar.MixedHaar2(1, n + 1)(x);

            return result;
        }

        public static double FastCalc(double[] p, double x)
        {
            int length = p.Length;
            double result = 0;
            int k = 0;
            int i = GetI(x, k);
            double pow2k = Math.Pow(2, k);
            int n = Convert.ToInt32(pow2k + i) + 1;

            result += p[0] * MixHaar.MixedHaar2(1, 1)(x);
            if (p.Length >= 2)
                    result += p[1] * MixHaar.MixedHaar2(1, 2)(x);

            while (pow2k + i < length)
            {
                if (pow2k * x < i && pow2k * x + 1 > i)
                    result += p[n - 1] * MixHaar.MixedHaar2(1, n)(x);

                k++;
                i = GetI(x, k);
                pow2k *= 2;
                n = Convert.ToInt32(pow2k + i) + 1;
            }

            return result;
        }

        private static int GetI(double x, int k)
        {
            return Convert.ToInt32(Math.Floor(x * Math.Pow(2, k) + 1));
        }
    }
}
