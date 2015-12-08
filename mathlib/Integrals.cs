using System;
using System.Linq;

namespace mathlib
{
    public static class Integrals
    {
        /// <summary>
        /// Returns integral from nodes[0] to nodes[last] of function f.
        /// </summary>
        /// <param name="f"></param>
        /// <param name="nodes"></param>
        /// <param name="formulaType"></param>
        /// <returns></returns>
        public static double Rectangular(Func<double, double> f, double[] nodes, RectType formulaType)
        {
            double sum = 0;
            double a, b;
            switch (formulaType)
            {
                case RectType.Left:
                    a = 1;
                    b = 0;
                    break;
                case RectType.Right:
                    a = 0;
                    b = 1;
                    break;
                case RectType.Center:
                    a = b = 0.5;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(formulaType), formulaType, null);
            }

            for (int i = 0; i < nodes.Length - 1; i++)
            {
                sum += (a * f(nodes[i]) + b * f(nodes[i + 1])) * (nodes[i + 1] - nodes[i]);
            }
            return sum;
        }

        public static double Trapezoid(Func<double, double> f, double[] nodes)
        {
            double sum = 0;
            for (int i = 0; i < nodes.Length - 1; i++)
            {
                sum += (f(nodes[i + 1]) + f(nodes[i])) * (nodes[i + 1] - nodes[i]);
            }
            return sum / 2;
        }

        /// <summary>
        /// Uses equidistant net
        /// </summary>
        /// <param name="f"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="nodesCount"></param>
        /// <returns></returns>
        public static double Trapezoid(Func<double, double> f, double a, double b, int nodesCount)
        {
            double sum = 0.5 * (f(a) + f(b));
            var delta = (b - a) / (nodesCount - 1);
            var x = a + delta;
            
            // In fact, here we must use condition x < b, but due to calc errors 
            // last x = a+delta*(nodesCount-1) can be less than b
            while (x<b-0.5*delta)
            {
                sum += f(x);
                x += delta;
            }
            return sum*delta;
        }

        public static double Rectangular(Func<double, double> f, double a, double b, int nodesCount, RectType formulaType = RectType.Left)
        {
            var nodes = Enumerable.Range(0, nodesCount - 1).Select(j => a + j * (b - a) / (nodesCount - 1)).ToArray();
            return Rectangular(f, nodes, formulaType);
        }

        public enum RectType
        {
            Left,
            Right,
            Center
        }
    }
}