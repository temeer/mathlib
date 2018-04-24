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

namespace Demo
{
    public partial class FourierSobolevHaarExample : GraphBuilder2DForm
    {
        private readonly Plot2D _plot1 = new Plot2D("FourierSobolevHaar");
        private readonly Plot2D _plot2 = new Plot2D("Fast FourierSobolevHaar");

        private int lengthP;
        private int lengthX;

        private double[] p;
        private double[] x;
        private double[] y1;
        private double[] y2;

        public FourierSobolevHaarExample()
        {
            InitializeComponent();

            lengthP = (int) numP.Value;
            lengthX = (int) numericUpDown2.Value;
            
            Calculations();

            _plot1.DiscreteFunction = new DiscreteFunction2D(x, y1);
            _plot2.DiscreteFunction = new DiscreteFunction2D(x, y2);

            GraphBuilder.DrawPlot(_plot1);
            GraphBuilder.DrawPlot(_plot2);

            Refresh();
        }

        private void Calculations()
        {
            p = new double[lengthP];
            x = new double[lengthX];
            y1 = new double[lengthX];
            y2 = new double[lengthX];

            for (int i = 0; i < lengthP; i++)
            {
                p[i] = 1;
            }

            for (int i = 0; i < lengthX; i++)
            {
                x[i] = i / (lengthX - 1.0);
                y1[i] = FourierSobolevHaar.Calc(p, x[i]);
                y2[i] = FourierSobolevHaar.FastCalc(p, x[i]);
            }
        }

        private void numP_ValueChanged(object sender, EventArgs e)
        {
            lengthP = (int)numP.Value;

            PlotRefresh();
        }

        private void PlotRefresh()
        {
            Calculations();

            _plot1.DiscreteFunction = new DiscreteFunction2D(x, y1);
            _plot2.DiscreteFunction = new DiscreteFunction2D(x, y2);

            _plot1.Refresh();
            _plot2.Refresh();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            lengthX = (int)numericUpDown2.Value;

            PlotRefresh();
        }
    }
}
