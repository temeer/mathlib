using System;
using System.Collections.Generic;

namespace mathlib
{
    public class Common
    {
        public static int Factorial(int n)
        {
            int prod = 1;
            for (int i = 2; i <= n; i++)
            {
                prod *= i;
            }
            return prod;
        }

        public static int[] ToBinary(int n)
        {
            var bin = new List<int>(64);
            while (n > 0)
            {
                bin.Add(n & 1);
                n = n >> 1;
            }

            return bin.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">Number is supposed to be in [0,1)</param>
        /// <param name="digitsCount"></param>
        /// <returns></returns>
        public static int[] ToBinary(double x, int digitsCount)
        {
            var bin = new int[digitsCount];
            x = x - (int) x;
            for (int i = 0; i < digitsCount; i++)
            {
                x *= 2;
                bin[i] = (int) x;
                x = x - (int) x;
            }

            return bin;
        }
    }
}