using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mathlib;
using static System.Math;
/// <summary>
/// Test commit
/// </summary>
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

        public static (double[] initVals, DynFunc<double>[] f, double h, Func<double, double>[] yExact) ExampleSystem4()
        {
            var initVals = new[] { 1d, 2 };
            var f = new DynFunc<double>[]
            {
                new DynFunc<double>((x, y1, y2) => 4*y1 - 3*y2 + Sin(x)),
                new DynFunc<double>((x, y1, y2) => 2*y1 - y2 - 2*Cos(x))
            };

            var h = 1d;
            return (initVals, f, h, new Func<double, double>[] { x => Cos(x) - 2 * Sin(x), x => 2 * (Cos(x) - Sin(x)) });
        }

        public static (double[] initVals, DynFunc<double>[] f, double h, Func<double, double>[] yExact) ExampleSystem5()
        {
            var initVals = new[] { 1d, 2 };
            var f = new DynFunc<double>[]
            {
                new DynFunc<double>((x, y1, y2) => (4d*y1 - 3d*y2 + Sin(2*PI*x))*2*PI),
                new DynFunc<double>((x, y1, y2) => (2d*y1 - y2 - 2d*Cos(2*PI*x))*2*PI)
            };

            var h = 1d;
            return (initVals, f, h, new Func<double, double>[] { x => Cos(2 * PI * x) - 2 * Sin(2 * PI * x), x => 2 * (Cos(2 * PI * x) - Sin(2 * PI * x)) });
        }

        public static (Segment segment, double[] initVals, DynFunc<double>[] f, double h, Func<double, double>[] yExact) ExampleSystem6()
        {
            var initVals = new[] { 0, 0d };
            var f = new DynFunc<double>[]
            {
                new DynFunc<double>((x, y1, y2) => 11 - 20 * y2 * y2),
                new DynFunc<double>((x, y1, y2) => 2.5*(1+Sqrt(1-(y1-x)*(y1-x))))
            };

            var h = 0.1d;
            return (new Segment(0, h), initVals, f, h, new Func<double, double>[] { x => x + Sin(10 * x), x => Sin(5 * x) });
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

        public static (Segment segment, double y0, Func<double, double, double> f, Func<double, double> yExact) Example1()
        {
            //var x0 = 0d;
            Func<double, double, double> f = (x, y) => x * y;
            //var b = 1;

            var h = 0.5d;
            var segment = new Segment(0, h);
            Func<double, double> yExact = x => Exp(x * x / 2);
            var y0 = yExact(segment.Start);
            return (segment, y0, f, yExact);
        }

        public static (Segment segment, double y0, Func<double, double, double> f, Func<double, double> yExact) Example2()
        {
            //var x0 = 0d;
            Func<double, double, double> f = (x, y) => x * y;
            //var b = 1;

            //var h = 1d;
            Func<double, double> yExact = x => Exp(x * x / 2) / 10;
            var segment = new Segment(0, 6);
            var y0 = yExact(segment.Start);
            return (segment, y0, f, yExact);
        }

        public static (Segment segment, double y0, Func<double, double, double> f, Func<double, double> yExact) Example3()
        {
            //var x0 = 0d;
            Func<double, double, double> f = (x, y) => -2 * x * y * y / (x * x - 1);
            //var b = 1;

            var h = 0.5d;
            double YExact(double x) => 1.0 / (Log(1 - x * x) + 1);
            var segment = new Segment(0, 0.5);
            var y0 = YExact(segment.Start);
            return (segment, y0, f, YExact);
        }
    }
}
