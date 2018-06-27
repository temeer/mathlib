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
using mathlib;
using static System.Math;

namespace Demo
{
    public partial class MixHaar2 : GraphBuilder2DForm
    {
        private readonly Plot2D _plot1 = new Plot2D("Original");
        private readonly Plot2D _plot2 = new Plot2D("Partial sum r=2");
        private readonly Plot2D _plot3 = new Plot2D("Partial sum r=1");
        Func<double, double> f = x => Sin(6 * PI * x) + x;
        Func<double, double> df = x => 6 * PI * Cos(6 * PI * x) + 1;

        public MixHaar2()
        {
            InitializeComponent();
            GraphBuilder.DrawPlot(_plot1);
            GraphBuilder.DrawPlot(_plot2);
            GraphBuilder.DrawPlot(_plot3);
            _plot1.DiscreteFunction = new DiscreteFunction2D(f, 0, 1, 1000);
            _plot1.Refresh();
        }

        private void nupN_ValueChanged(object sender, EventArgs e)
        {
            var n = (int)nupN.Value;

            _plot2.DiscreteFunction = new DiscreteFunction2D(x => PartialSum2(n, x), 0, 1, 1000);
            _plot3.DiscreteFunction = new DiscreteFunction2D(x => PartialSum1(n, x), 0, 1, 1000);

            //_plot2.DiscreteFunction = new DiscreteFunction2D(x => MixHaar.MixedHaar(2, n + 1)(x), 0, 1, 1000);
            //_plot3.DiscreteFunction = new DiscreteFunction2D(x => MixHaar.MixedHaar(1, n)(x), 0, 1, 1000);

            _plot2.Refresh();
            _plot3.Refresh();
        }

        private double PartialSum2(int n, double x)
        {
            var s = coeff2(0) + coeff2(1) * x;
            for (int j = 2; j <= n; j++)
            {
                s += coeff2(j) * MixHaar.MixedHaar(2, j + 1)(x);
            }
            return s;
        }

        private double coeff2(int n)
        {
            if (n == 0) return f(0);
            if (n == 1) return df(0);
            if (n == 2) return df(1) - df(0);
            var (k, i) = Common.Decompose(n-1);
            return (2 * df((2 * i - 1) / Pow(2, k + 1)) - (df((i - 1) / Pow(2, k)) + df(i / Pow(2, k)))) * Pow(2,k / 2.0);
        }

        private double PartialSum1(int n, double x)
        {
            var s = coeff1(0);
            for (int j = 1; j <= n; j++)
            {
                s += coeff1(j) * MixHaar.MixedHaar(1, j + 1)(x);
            }
            return s;
        }

        private double coeff1(int n)
        {
            if (n == 0) return f(0);
            if (n == 1) return f(1)-f(0);
            var (k, i) = Common.Decompose(n);
            return (2 * f((2 * i - 1) / Pow(2, k + 1)) - (f((i - 1) / Pow(2, k)) + f(i / Pow(2, k)))) * Pow(2, k / 2.0);
        }


    }


}
