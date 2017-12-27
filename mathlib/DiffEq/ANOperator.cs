using System;

namespace mathlib.DiffEq
{
    public class AFiniteDimOperator
    {
        private double _h;
        private DynFunc<double>[] _f;
        private double[] _nodes;
        private Func<double, double>[] _phi;
        private Func<double, double>[] _phiSobolev;


        public AFiniteDimOperator(double h, DynFunc<double>[] f, double[] nodes, Func<double, double>[] phi, Func<double, double>[] phiSobolev)
        {
            _h = h;
            _f = f;
            _nodes = nodes;
            _phi = phi;
            _phiSobolev = phiSobolev;
        }
    }
}