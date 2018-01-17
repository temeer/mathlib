using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mathlib;
using static System.Math;

namespace Demo
{
    public static class OdeExamples
    {
        public static (double[] initVals, DynFunc<double>[] f, double h, Func<double, double>[] yExact) ExampleSystem1()
        {
            var initVals = new[] { 1d, 1 };
            var f = new DynFunc<double>[]
            {
                new DynFunc<double>(3, args => args[1]*args[1]/(args[2]-args[0])),
                new DynFunc<double>(3, args => args[1]+1)
            };



            var h = 1d;
            return (initVals, f, h, new Func<double, double>[] { x => Exp(x), x => x + Exp(x) });
        }

        public static (double[] initVals, DynFunc<double>[] f, double h, Func<double, double>[] yExact) ExampleSystem3()
        {
            var initVals = new[] { 1d, 2 };
            var f = new DynFunc<double>[]
            {
                new DynFunc<double>((x, y1, y2) => y1 - y2 +2*Sin(x)),
                new DynFunc<double>((x,y1,y2) => 2*y1-y2)
            };

            var h = 1d;
            return (initVals, f, h, new Func<double, double>[] { x => Cos(x) + x * Sin(x) - x * Cos(x), x => 2 * (Sin(x) + Cos(x)) - 2 * x * Cos(x) });
        }

        public static (double[] initVals, DynFunc<double>[] f, double h, Func<double, double>[] yExact) ExampleSystem2()
        {
            var initVals = new[] { 0d, 1, 1 };
            var f = new DynFunc<double>[]
            {
                new DynFunc<double>((x, y, z) => 1d),
                new DynFunc<double>((x, y, z) => 1),
                new DynFunc<double>(3, args => args[1]+1)
            };

            var h = 1d;
            return (initVals, f, h, new Func<double, double>[] { x => Exp(x), x => x + Exp(x) });
        }

        public static (double y0, Func<double, double, double> f, double h, Func<double, double> yExact) Example1()
        {
            //var x0 = 0d;
            var y0 = 1d;
            Func<double, double, double> f = (x, y) => x * y;
            //var b = 1;

            var h = 0.5d;
            Func<double, double> yExact = x => Exp(x * x / 2);
            return (y0, f, h, yExact);
        }

        public static (double y0, Func<double, double, double> f, double h, Func<double, double> yExact) Example2()
        {
            //var x0 = 0d;
            var y0 = 0d;
            Func<double, double, double> f = (x, y) => y * y - x * x;
            //var b = 1;

            var h = 1d;
            Func<double, double> yExact = null;
            return (y0, f, h, yExact);
        }

        public static (double y0, Func<double, double, double> f, double h, Func<double, double> yExact) Example3()
        {
            //var x0 = 0d;
            var y0 = 1d;
            Func<double, double, double> f = (x, y) => -2 * x * y * y / (x * x - 1);
            //var b = 1;

            var h = 0.5d;
            Func<double, double> yExact = x => 1.0 / (Log(1 - x * x) + 1);
            return (y0, f, h, yExact);
        }
    }
}
