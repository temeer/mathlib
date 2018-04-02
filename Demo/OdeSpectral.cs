using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
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
using static Demo.OdeExamples;

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

        

        void Solve(int partSumOrder, int iterCount, int nodesCount)
        {
            var (y0, f, h, yExact) = Example3();
            var nodes = Range(0, nodesCount).Select(j => 1d * j / nodesCount).ToArray();
            if (yExact != null)
            {
                exactSolutionPlot.DiscreteFunctions = new[] { new DiscreteFunction2D(x => yExact(x), nodes) };
                exactSolutionPlot.Refresh();
            }

            var cosSystem = new CosSystem();
            var sobCosSystem = new SobolevCosSystem();

            var solverIter = new SpectralSolverIter(f, y0, Natural.NumbersWithZero.Select(k => cosSystem.Get(k)),
                Natural.NumbersWithZero.Select(k => sobCosSystem.Get(k)));
            var df = solverIter.Solve(nodes, h, partSumOrder, iterCount).First();
            df.X = df.X.Select(x => x * h).ToArray();
            numSolutionPlotIter.DiscreteFunctions = new[] { df };
            numSolutionPlotIter.Refresh();
        }

        



        void SolveSystem(int partSumOrder, int iterCount, int nodesCount)
        {
            var (initVals, f, h, yExact) = ExampleSystem6();
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
            //var deltas = solution.Zip(yExact, (df, y) => Abs(df.Y.Last() - y(df.X.Last()))).ToArray();
            var deltas = solution.Zip(yExact, (df, y) =>
                {
                    var eDf = new DiscreteFunction2D(y, df.X);
                    return Sqrt((df - eDf).Y.Average(v => v * v));
                }
                ).ToArray();
            Trace.WriteLine($"iter={iterCount}; N={partSumOrder}; dy1={deltas[0]};dy2={deltas[1]}");

        }

        private void ValueChanged(object sender, EventArgs e)
        {
            //Solve((int)nupOrder.Value, (int)nupIterCount.Value, (int)nupNodesCount.Value);
            SolveSystem((int)nupOrder.Value, (int)nupIterCount.Value, (int)nupNodesCount.Value);
        }


    }

    //public static class ArrayExts
    //{
    //    public static void Deconstruct(this double[] arr, params out double[] x)
    //    {
    //        x = arr[0];
    //        y = arr[1];
    //    }
    //}
}
