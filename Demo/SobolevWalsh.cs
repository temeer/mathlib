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
using mathlib.Functions;
using mathlib.Symbolic;

namespace Demo
{
    public partial class SobolevWalsh : GraphBuilder2DForm
    {
        private readonly Plot2D _plot = new Plot2D("Walsh - Sobolev");
        private readonly Plot2D _plot2 = new Plot2D("Walsh - Sobolev - 2^k");

        public SobolevWalsh()
        {
            InitializeComponent();
            GraphBuilder.DrawPlot(_plot);
            GraphBuilder.DrawPlot(_plot2);
        }

        private void nupNum_ValueChanged(object sender, EventArgs e)
        {
            var n = (int) nupNum.Value;
            var pow2 = (int) Math.Pow(2, Math.Floor(Math.Log(n-1, 2)));
            _plot.DiscreteFunction =
                new DiscreteFunction2D(WalshSobolev.Get(n) , 0, 1, 1024);
            _plot.Refresh();
            _plot2.DiscreteFunction =
                new DiscreteFunction2D(WalshSobolev.Get(pow2+1), 0, 1, 1024);
            _plot2.Refresh();
        }
    }
}
