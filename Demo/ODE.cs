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
using GraphBuilders;
using mathlib.DiffEq;
using Steema.TeeChart.Styles;
using static System.Math;

namespace Demo
{
    public partial class ODE : Form
    {
        GraphBuilder2DForm gb = new GraphBuilder2DForm();
        Plot2D exactSolutionPlot = new Plot2D("Точное решение");
        Plot2D numSolutionPlot = new Plot2D("Численное решение");
        public ODE()
        {
            InitializeComponent();
            gb.Show();
            gb.GraphBuilder.DrawPlot(exactSolutionPlot);
            gb.GraphBuilder.DrawPlot(numSolutionPlot);
        }

        private void buttonSolve_Click(object sender, EventArgs e)
        {
            Solve(100);
        }

        private void Solve(int n)
        {
            var x0 = 1d;
            var y0 = 2d;
            Func<double, double, double> f = (x, y) => 2*x*x + 1/2.0/Sqrt(x);
            var b = 11;
            var pair = Euler.Solve(f, x0, y0, b, n);

            var xarr = pair.Item1;
            var yarr = pair.Item2;

            numSolutionPlot.DiscreteFunction = new DiscreteFunction2D(pair.Item1, pair.Item2);
            numSolutionPlot.Refresh();

            exactSolutionPlot.DiscreteFunction = new DiscreteFunction2D(x => x * x + Sqrt(x), pair.Item1);
            exactSolutionPlot.Refresh();


        }

        private void cbShowPoints_CheckedChanged(object sender, EventArgs e)
        {
            (gb.GraphBuilder.GetSeriesOfPlot(exactSolutionPlot) as Line).Pointer.Visible = cbShowPoints.Checked;
            (gb.GraphBuilder.GetSeriesOfPlot(numSolutionPlot) as Line).Pointer.Visible = cbShowPoints.Checked;
        }

        private void nupPointsCount_ValueChanged(object sender, EventArgs e)
        {
            Solve((int)nupPointsCount.Value);
        }
    }
}
