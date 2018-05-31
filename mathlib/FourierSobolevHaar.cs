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
            int pow2k = 1;
            int i = (int)x + 1;
            int n = 1 + i;

            result += p[0] * MixHaar.MixedHaar1(1)(x);
            if (length >= 2)
                result += p[1] * MixHaar.MixedHaar1(2)(x);

            for (int k = 0; n < length; k++)
            {
                if (pow2k * x < i && pow2k * x + 1 > i)
                    result += p[n] * MixHaar.MixedHaar1(k, i)(x);
                else
                    break;
                
                pow2k *= 2;
                i = (int)(pow2k * x) + 1;
                n = pow2k + i;
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

        public static double FastCalc1(double[] p, double x)
        {
            double result = 0;

            int length = p.Length;
            int pow2k = 1;
            double pow2kx = x;
            double pow2k2 = 1;
            double sqrt2 = Math.Sqrt(2);
            int nu = (int)x + 1;
            int n = 1 + nu;

            result += p[0] * MixHaar.MixedHaar1(1)(x);
            if (length >= 2)
                result += p[1] * MixHaar.MixedHaar1(2)(x);

            for (int k = 0; n < length; k++)
            {
                if (pow2kx < nu && pow2kx + 1 > nu)
                    result += p[n] * MixHaar.MixedHaar12(pow2kx - (int)pow2kx) * pow2k2;
                else
                    break;
                
                pow2k *= 2;
                pow2kx *= 2;
                pow2k2 /= sqrt2;
                nu = (int)pow2kx + 1;
                n = pow2k + nu;
            }

            return result;
        }

        public static Func<double, double> FastCalc1(double[] p)
        {
            return x =>
            {
                return FastCalc1(p, x);
            };
        }
    }
}
