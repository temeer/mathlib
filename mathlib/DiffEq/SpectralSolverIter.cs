using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DiscreteFunctions;
using static System.Linq.Enumerable;

namespace mathlib.DiffEq
{
    public class SpectralSolverIter: SpectralSolverIterBase<double[][]>
    {
        // Used to calculate coeffs that are represented as integrals
        private readonly double[] _quadratureNodes;

        public SpectralSolverIter(IEnumerable<Func<double, double>> phi, IEnumerable<Func<double, double>> phiSobolev)
            : base(phi, phiSobolev)
        {
        }

        //public DiscreteFunction2D[] Solve(double[] nodes, double h, int partialSumOrder, int iterCount)
        //{

        //}


        protected override IMathOperator<double[][]> GetCoeffsOperator()
        {
            throw new NotImplementedException();
            var phiSobolev = _phiSobolev.Take(coeffsCount + 1).ToArray();
            var op = new AFiniteDimOperator(f, initialValues, nodes,
                _phi.Take(partialSumOrder + 1).ToArray(), phiSobolev, partialSumOrder);
            
            
        }

        protected override double[][] GetInitialCoeffs() =>
            Range(0, m).Select(j => Range(0, coeffsCount).Select(k => 1.0 / (k + 1)).ToArray()).ToArray();
        
    }
}