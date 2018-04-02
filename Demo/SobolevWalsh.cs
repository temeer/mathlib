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
using mathlib.Functions;

namespace Demo
{
    public partial class SobolevWalsh : GraphBuilder2DForm
    {
        Plot2D walshPlot = new Plot2D("Walsh");
        public SobolevWalsh()
        {
            InitializeComponent();
            GraphBuilder.DrawPlot(walshPlot);
        }

        private void nupNum_ValueChanged(object sender, EventArgs e)
        {
            walshPlot.DiscreteFunction =
                new DiscreteFunction2D(Walsh.Get((int)nupNum.Value), 0, 1, 1024);
            walshPlot.Refresh();
        }
    }
}
