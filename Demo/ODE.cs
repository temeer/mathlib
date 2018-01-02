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
using Steema.TeeChart.Styles;
using static System.Math;
using static System.Linq.Enumerable;

namespace Demo
{
    public partial class ODE : Form
    {
        GraphBuilder2DForm gb = new GraphBuilder2DForm();
        Plot2D exactSolutionPlot = new Plot2D("Точное решение");
        Plot2D numSolutionPlotE = new Plot2D("Численное решение методом Эйлера");
        Plot2D numSolutionPlotEC = new Plot2D("Численное решение методом Эйлера-Коши");
        Plot2D numSolutionPlotIter = new Plot2D("Численное решение итерационным методом");
        public ODE()
        {
            InitializeComponent();
            gb.Show();
            gb.GraphBuilder.DrawPlot(exactSolutionPlot);
            gb.GraphBuilder.DrawPlot(numSolutionPlotE);
            gb.GraphBuilder.DrawPlot(numSolutionPlotEC);
            gb.GraphBuilder.DrawPlot(numSolutionPlotIter);
        }

        private void buttonSolve_Click(object sender, EventArgs e)
        {
            Solve(100);
        }

        private void Solve(int n)
        {
            var x0 = 0d;
            var y0 = 2d;
            Func<double, double, double> f = (x, y) => 2*x*x + 1/2.0/Sqrt(x);
            var b = 1;
            var df = Solver.EulerImproved(f, x0, y0, b, n);
            numSolutionPlotE.DiscreteFunction = df;
            numSolutionPlotE.Refresh();

            df = Solver.EulerCauchy(f, x0, y0, b, n);
            numSolutionPlotEC.DiscreteFunction = df;
            numSolutionPlotEC.Refresh();

            
            

            exactSolutionPlot.DiscreteFunction = new DiscreteFunction2D(x => x * x + Sqrt(x), df.X);
            exactSolutionPlot.Refresh();
        }

        private void cbShowPoints_CheckedChanged(object sender, EventArgs e)
        {
            (gb.GraphBuilder.GetSeriesOfPlot(exactSolutionPlot) as Line).Pointer.Visible = cbShowPoints.Checked;
            (gb.GraphBuilder.GetSeriesOfPlot(numSolutionPlotE) as Line).Pointer.Visible = cbShowPoints.Checked;
            (gb.GraphBuilder.GetSeriesOfPlot(numSolutionPlotEC) as Line).Pointer.Visible = cbShowPoints.Checked;
        }

        private void nupPointsCount_ValueChanged(object sender, EventArgs e)
        {
            Solve((int)nupPointsCount.Value);
        }
    }
}
