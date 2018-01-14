using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DiscreteFunctions;
using static System.Linq.Enumerable;

namespace mathlib.DiffEq
{
    public class SpectralSolverIter
    {
        private readonly DynFunc<double>[] _f;
        private readonly double[] _initialValues;
        private readonly IEnumerable<Func<double, double>> _phi;
        private readonly IEnumerable<Func<double, double>> _phiSobolev;

        public SpectralSolverIter(DynFunc<double>[] f, double[] initialValues,
            IEnumerable<Func<double, double>> phi, IEnumerable<Func<double, double>> phiSobolev)
        {
            _f = f;
            _initialValues = initialValues;
            _phi = phi;
            _phiSobolev = phiSobolev;
        }

        public SpectralSolverIter(Func<double, double, double> f, double initialValue,
            IEnumerable<Func<double, double>> phi, IEnumerable<Func<double, double>> phiSobolev)
            : this(new[] { new DynFunc<double>(2, doubles => f(doubles[0], doubles[1])) },
                  new[] { initialValue }, phi, phiSobolev)
        {
        }

        public DiscreteFunction2D[] Solve(double[] nodes, double h, int partialSumOrder, int iterCount)
        {
            //var f = new DynFunc<double>[] {new D};
            var phiSobolev = _phiSobolev.Take(partialSumOrder + 1).ToArray();
            var op = new AFiniteDimOperator(h, _f, _initialValues, nodes,
                _phi.Take(partialSumOrder + 1).ToArray(), phiSobolev, partialSumOrder);
            var m = _f.First().ArgsCount - 1;
            var initCoeffs = Range(0, m).Select(j => Range(0, partialSumOrder).Select(k => 1.0 / (k+1)).ToArray()).ToArray();

            var result = FixedPointIteration.FindFixedPoint(c => op.GetValue(c), initCoeffs, iterCount, c =>
            {
                return;
                for (int i = 0; i < c.Length; i++)
                {
                    Trace.WriteLine("");
                    for (int j = 0; j < c[i].Length; j++)
                    {
                        Trace.Write($"{c[i][j],-5:F3} ");
                    }
                    
                }
                Trace.WriteLine("");
            });
            var sobolevPartSum = new FourierDiscretePartialSum(nodes, phiSobolev);
            return result.Select((coeffs, j) => sobolevPartSum.GetValues(new[]{_initialValues[j]}.Concat(coeffs.Select(c => c * h)))).ToArray();
        }
    }
}