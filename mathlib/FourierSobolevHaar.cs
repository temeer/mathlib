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

        public static Func<double, double> Calc(double[] p)
        {
            return x =>
            {
                int length = p.Length;
                double result = 0;

                for (int n = 0; n < length; n++)
                    result += p[n] * MixHaar.MixedHaar2(1, n + 1)(x);

                return result;
            };
        }

        public static double FastCalc(double[] p, double x)
        {
            int length = p.Length;
            double result = 0;
            int k = 0;
            double pow2k = Math.Pow(2, k);
            double pow2kx = pow2k * x + 1;
            int i = (int)pow2kx;
            int n = (int)(pow2k + i) + 1;

            result += p[0] * MixHaar.MixedHaar2(1, 1)(x);
            if (p.Length >= 2)
                    result += p[1] * MixHaar.MixedHaar2(1, 2)(x);

            while (pow2k + i < length)
            {
                if (pow2k * x < i && pow2kx > i)
                    result += p[n - 1] * MixHaar.MixedHaar2(1, n)(x);

                k++;
                pow2k *= 2;
                pow2kx = 2 * pow2kx - 1;
                i = (int)pow2kx;
                n = (int)(pow2k + i) + 1;
            }

            return result;
        }

        public static Func<double, double> FastCalc(double[] p)
        {
            return x =>
            {
                int length = p.Length;
                double result = 0;
                int k = 0;
                double pow2k = Math.Pow(2, k);
                double pow2kx = pow2k * x + 1;
                int i = (int)pow2kx;
                int n = (int)(pow2k + i) + 1;

                result += p[0] * MixHaar.MixedHaar2(1, 1)(x);
                if (p.Length >= 2)
                    result += p[1] * MixHaar.MixedHaar2(1, 2)(x);

                while (pow2k + i < length)
                {
                    if (pow2k * x < i && pow2kx > i)
                        result += p[n - 1] * MixHaar.MixedHaar2(1, n)(x);

                    k++;
                    pow2k *= 2;
                    pow2kx = 2 * pow2kx - 1;
                    i = (int)pow2kx;
                    n = (int)(pow2k + i) + 1;
                }

                return result;
            };
        }
    }
}
