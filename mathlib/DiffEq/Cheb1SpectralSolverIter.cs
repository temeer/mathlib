using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DiscreteFunctions;
using Endless;
using static System.Linq.Enumerable;

namespace mathlib.DiffEq
{
    public class Cheb1SpectralSolverIter : SpectralSolverIterBase
    {
        public Cheb1SpectralSolverIter(int quadratureNodesCount):
            base(CreateOperator(quadratureNodesCount), CreateIft())
        {
        }

        private static ISpectralOdeOperator<double[][]> CreateOperator(int quadratureNodesCount)
        {
            // Used to calculate coeffs that are represented as integrals
            var quadratureNodes = new Segment(-1, 1).GetUniformPartition(quadratureNodesCount);
            var cheb1System = new Cheb1System();
            var sobCheb1System = new SobolevCheb1System();
            var op = new Cheb1SpectralOdeOperator(
                Natural.NumbersWithZero.Select(k => cheb1System.Get(k)),
                Natural.NumbersWithZero.Select(k => sobCheb1System.Get(k)), 
                quadratureNodes
            );
            return op;
        }

        private static IInvFourierTransformer CreateIft()
        {
            return new InvFourierTransformer((coeffs, nodes) =>
            {
                var sobCheb1System = new SobolevCheb1System();
                var sobolevPartSum = new FourierDiscretePartialSum(
                    nodes, 
                    Natural.NumbersWithZero.Select(k => sobCheb1System.Get(k)).Take(coeffs.Length).ToArray()
                );
                return sobolevPartSum.GetValues(coeffs).Y;
            });
        }


        
        
    }
}