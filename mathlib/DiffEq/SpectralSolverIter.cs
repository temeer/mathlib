using System;
using System.Collections.Generic;
using DiscreteFunctions;

namespace mathlib.DiffEq
{
    public class SpectralSolverIter
    {
        public SpectralSolverIter(DynFunc<double>[] f, double[] initialValues, 
            Func<double, double>[] phi, Func<double, double>[] phiSobolev)
        {
        }

        public SpectralSolverIter(Func<double, double, double> f, double initialValue,
            IEnumerable<Func<double, double>> phi, IEnumerable<Func<double, double>> phiSobolev)
        {
        }

        public DiscreteFunction2D[] Solve(double[] nodes, double h, int partialSumOrder, int iterCount)
        {

        }
    }
}