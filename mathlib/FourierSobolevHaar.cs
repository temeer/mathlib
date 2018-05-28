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
            double result = 0;

            int length = p.Length;

            for (int n = 0; n < length; n++)
                result += p[n] * MixHaar.MixedHaar(1, n + 1)(x);

            return result;
        }

        public static Func<double, double> Calc(double[] p)
        {
            return x =>
            {
                return Calc(p, x);
            };
        }

        public static double FastCalc(double[] p, double x)
        {
            double result = 0;

            int length = p.Length;
            int k = 0;
            int pow2k = (int)Math.Pow(2, k);
            int i = (int)(pow2k * x) + 1;
            int n = pow2k + i + 1;

            result += p[0] * MixHaar.MixedHaar1(1)(x);
            if (length >= 2)
                result += p[1] * MixHaar.MixedHaar1(2)(x);

            while (pow2k + i < length)
            {
                if (pow2k * x < i && pow2k * x + 1 > i)
                    result += p[n - 1] * MixHaar.MixedHaar1(k, i)(x);
                else
                    break;

                k++;
                pow2k *= 2;
                i = (int)(pow2k * x) + 1;
                n = pow2k + i + 1;
            }

            return result;
        }

        public static Func<double, double> FastCalc(double[] p)
        {
            return x =>
            {
                return FastCalc(p, x);
            };
        }
    }
}
