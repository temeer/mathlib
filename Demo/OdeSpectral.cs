using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscreteFunctions;
using DiscreteFunctionsPlots;
using Endless;
using GraphBuilders;
using mathlib;
using mathlib.DiffEq;
using Steema.TeeChart.Styles;
using static System.Math;
using static System.Linq.Enumerable;

namespace Demo
{
    public partial class OdeSpectral : GraphBuilder2DForm
    {
        MultiPlot2D exactSolutionPlot = new MultiPlot2D(name: "Точное решение");
        MultiPlot2D numSolutionPlotIter = new MultiPlot2D(name: "Численное решение итерационным методом");
        public OdeSpectral()
        {
            InitializeComponent();
            GraphBuilder.DrawPlot(exactSolutionPlot);
            GraphBuilder.DrawPlot(numSolutionPlotIter);
        }

        (double y0, Func<double, double, double> f, double h, Func<double, double> yExact) Example1()
        {
            //var x0 = 0d;
            var y0 = 1d;
            Func<double, double, double> f = (x, y) => x * y;
            //var b = 1;

            var h = 0.5d;
            Func<double, double> yExact = x => Exp(x * x / 2);
            return (y0, f, h, yExact);
        }

        (double y0, Func<double, double, double> f, double h, Func<double, double> yExact) Example2()
        {
            //var x0 = 0d;
            var y0 = 0d;
            Func<double, double, double> f = (x, y) => y * y - x * x;
            //var b = 1;

            var h = 1d;
            Func<double, double> yExact = null;
            return (y0, f, h, yExact);
        }

        (double y0, Func<double, double, double> f, double h, Func<double, double> yExact) Example3()
        {
            //var x0 = 0d;
            var y0 = 1d;
            Func<double, double, double> f = (x, y) => -2 * x * y * y / (x * x - 1);
            //var b = 1;

            var h = 0.5d;
            Func<double, double> yExact = x => 1.0 / (Log(1 - x * x) + 1);
            return (y0, f, h, yExact);
        }

        void Solve(int partSumOrder, int iterCount, int nodesCount)
        {
            var (y0, f, h, yExact) = Example3();
            var nodes = Range(0, nodesCount).Select(j => 1d * j / nodesCount).ToArray();
            if (yExact != null)
            {
                exactSolutionPlot.DiscreteFunctions = new []{new DiscreteFunction2D(x => yExact(x), nodes)};
                exactSolutionPlot.Refresh();
            }

            var cosSystem = new CosSystem();
            var sobCosSystem = new SobolevCosSystem();

            var solverIter = new SpectralSolverIter(f, y0, Natural.NumbersWithZero.Select(k => cosSystem.Get(k)),
                Natural.NumbersWithZero.Select(k => sobCosSystem.Get(k)));
            var df = solverIter.Solve(nodes, h, partSumOrder, iterCount).First();
            df.X = df.X.Select(x => x * h).ToArray();
            numSolutionPlotIter.DiscreteFunctions = new[]{df};
            numSolutionPlotIter.Refresh();
        }

        (double[] initVals, DynFunc<double>[] f, double h, Func<double, double>[] yExact) ExampleSystem1()
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

        (double[] initVals, DynFunc<double>[] f, double h, Func<double, double>[] yExact) ExampleSystem2()
        {
            var initVals = new[] { 0d, 1, 1 };
            var f = new DynFunc<double>[]
            {
                new DynFunc<double>(3, (x, y, z) => 1d),
                new DynFunc<double>(3, (x, y, z) => 1),
                new DynFunc<double>(3, args => args[1]+1)
            };

            var h = 1d;
            return (initVals, f, h, new Func<double, double>[] { x => Exp(x), x => x + Exp(x) });
        }

        void SolveSystem(int partSumOrder, int iterCount, int nodesCount)
        {
            var (initVals, f, h, yExact) = ExampleSystem1();
            var nodes = Range(0, nodesCount).Select(j => 1d * j / nodesCount).ToArray();
            if (yExact != null)
            {
                exactSolutionPlot.DiscreteFunctions =
                    yExact.Select(y => new DiscreteFunction2D(y, nodes)).ToArray();
                exactSolutionPlot.Refresh();
            }

            var cosSystem = new CosSystem();
            var sobCosSystem = new SobolevCosSystem();

            var solverIter = new SpectralSolverIter(f, initVals, Natural.NumbersWithZero.Select(k => cosSystem.Get(k)),
                Natural.NumbersWithZero.Select(k => sobCosSystem.Get(k)));
            var solution = solverIter.Solve(nodes, h, partSumOrder, iterCount);
            foreach (var s in solution)
            {
                s.X = s.X.Select(x => x * h).ToArray();
            }
            numSolutionPlotIter.DiscreteFunctions = solution;
            numSolutionPlotIter.Refresh();
            var deltas = solution.Zip(yExact, (df, y) => Abs(df.Y.Last() - y(df.X.Last()))).ToArray();
            Trace.WriteLine($"iter={iterCount}; N={partSumOrder}; dy1={deltas[0]};dy2={deltas[1]}");

        }

        private void ValueChanged(object sender, EventArgs e)
        {
            //Solve((int)nupOrder.Value, (int)nupIterCount.Value, (int)nupNodesCount.Value);
            SolveSystem((int)nupOrder.Value, (int)nupIterCount.Value, (int)nupNodesCount.Value);
        }


    }
}
