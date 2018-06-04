using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mathlib
{
    public static class SobolevHaarLinearCombination
    {
        private static double sqrt2 = Math.Sqrt(2);

        //метод вычисления линейной комбинации S_{1,N}(x)
        public static double FastCalc(double[] alpha, double x)
        {
            int N = alpha.Length;
            //номер k-й пачки = 0
            int pow2k = 1; //2^k
            double pow2kx = x; //2^k*x
            double pow2k2 = 1; //2^{-k/2}
            int nu = (int)x + 1; //nu(k, x) = [2^k*x] + 1
            int n = 1 + nu; //n = 2^k + nu, 1 <= nu <= 2^k, используется для нахождения индекса массива alpha
            
            double result = alpha[0] * x;

            for (int k = 0; n <= N; k++) //вместо нахождения ~K сравниваются значения n и N для n = 2^k + nu
            {
                if (pow2kx + 1 == nu) //проверка на наличие ненулевого элемента в k-й пачке
                {
                    break;
                }

                //нахождение дробной части 2k^x
                double xd = pow2kx - (int)pow2kx;
                result += alpha[n - 1] * pow2k2 * (xd <= 0.5 ? xd : 1 - xd); //вычисление k-го значения суммы

                //обновление значений переменных для следующей k+1-й пачки
                pow2k *= 2;
                pow2kx *= 2;
                pow2k2 /= sqrt2;
                nu = (int)pow2kx + 1;
                n = pow2k + nu;
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
