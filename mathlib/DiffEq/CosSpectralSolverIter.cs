using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DiscreteFunctions;
using Endless;
using static System.Linq.Enumerable;

namespace mathlib.DiffEq
{
    public class CosSpectralSolverIter: SpectralSolverIterBase
    {
        // Used to calculate coeffs that are represented as integrals
        private readonly double[] _quadratureNodes;

        public CosSpectralSolverIter(int quadratureNodesCount, double[][] initialCoeffs):
            base(CreateOperator(quadratureNodesCount), initialCoeffs, CreateIft())
        {
        }

        private static ISpectralOdeOperator<double[][]> CreateOperator(int quadratureNodesCount)
        {
            var quadratureNodes = new Segment(0, 1).GetUniformPartition(quadratureNodesCount);
            var cosSystem = new CosSystem();
            var sobCosSystem = new SobolevCosSystem();
            var op = new CosSpectralOdeOperator(Natural.NumbersWithZero.Select(k => cosSystem.Get(k)),
                Natural.NumbersWithZero.Select(k => sobCosSystem.Get(k)), quadratureNodes);
            return op;
        }

        private static IInvFourierTransformer CreateIft()
        {
            throw new NotImplementedException();
        }

        //public DiscreteFunction2D[] Solve(double[] nodes, double h, int partialSumOrder, int iterCount)
        //{

        //}


        //protected override ISpectralOdeOperator<double[][]> GetCoeffsOperator()
        //{
        //    throw new NotImplementedException();
        //    var phiSobolev = _phiSobolev.Take(coeffsCount + 1).ToArray();
        //    var op = new CosSpectralOdeOperator(f, initialValues, nodes,
        //        _phi.Take(partialSumOrder + 1).ToArray(), phiSobolev, partialSumOrder);
            
            
        //}

        //protected override double[][] GetInitialCoeffs() =>
        //    Range(0, m).Select(j => Range(0, coeffsCount).Select(k => 1.0 / (k + 1)).ToArray()).ToArray();
        
    }
}