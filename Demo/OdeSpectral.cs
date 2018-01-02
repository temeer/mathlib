using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using static System.Math;
using static System.Linq.Enumerable;

namespace Demo
{
    public partial class OdeSpectral : GraphBuilder2DForm
    {
        Plot2D exactSolutionPlot = new Plot2D("Точное решение");
        Plot2D numSolutionPlotIter = new Plot2D("Численное решение итерационным методом");
        public OdeSpectral()
        {
            InitializeComponent();
            GraphBuilder.DrawPlot(exactSolutionPlot);
            GraphBuilder.DrawPlot(numSolutionPlotIter);
        }

        void Solve(int partSumOrder, int iterCount, int nodesCount)
        {
            var x0 = 0d;
            var y0 = 1d;
            Func<double, double, double> f = (x, y) => 2 * x  + 1 / 2.0 / Sqrt(x+1);
            var b = 1;
            var nodes = Range(0, nodesCount).Select(j => 1d * j / nodesCount).ToArray();
            var h = 1d;
            Func <double, double> yExact = x => x * x + Sqrt(x + 1);
            exactSolutionPlot.DiscreteFunction = new DiscreteFunction2D(x => yExact(h*x), nodes);
            exactSolutionPlot.Refresh();

            var cosSystem = new CosSystem();
            var sobCosSystem = new SobolevCosSystem();

            var solverIter = new SpectralSolverIter(f, y0, Natural.NumbersWithZero.Select(k => cosSystem.Get(k)),
                Natural.NumbersWithZero.Select(k => sobCosSystem.Get(k)));
            var df = solverIter.Solve(nodes, h, partSumOrder, iterCount).First();
            numSolutionPlotIter.DiscreteFunction = df;
            numSolutionPlotIter.Refresh();
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            Solve((int)nupOrder.Value, (int)nupIterCount.Value, (int) nupNodesCount.Value);
        }


    }
}
