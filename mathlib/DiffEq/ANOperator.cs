using System;
using System.Linq;
using System.Threading.Tasks;
using mathlib.Polynomials;
using static System.Linq.Enumerable;

namespace mathlib.DiffEq
{
    public class AFiniteDimOperator
    {
        private double _h;
        private DynFunc<double>[] _f;
        private readonly double[] _initialValues;
        private double[] _nodes;
        private Func<double, double>[] _phi;
        private Func<double, double>[] _phiSobolev;
        private readonly int _partialSumOrder; // N
        private readonly int _m;


        public AFiniteDimOperator(double h, DynFunc<double>[] f, 
            double[] initialValues, double[] nodes, 
            Func<double, double>[] phi, Func<double, double>[] phiSobolev, int partialSumOrder)
        {
            _h = h;
            _f = f;
            _initialValues = initialValues;
            _nodes = nodes;
            _phi = phi;
            _phiSobolev = phiSobolev;
            _partialSumOrder = partialSumOrder;
            _m = f.First().ArgsCount;

            // TODO: check arguments consistence
        }

        public double[][] GetValue(double[][] c)
        {
            if (c.Length != _m)
                throw new ArgumentOutOfRangeException($"Argument c should have first dimension length equal to {_m}");
            // eta[k][j] = $\eta_k(t_j)$
            var eta = Range(0, _m).AsParallel()
                        .Select(k => CalcEta(k, c[k])).ToArray();

            // CalcCoeff();
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates $\eta_j(t)=initialValues[j]+h\sum_{i=0}^N c[i] phiSobolev[i+1](t)$ in nodes.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private double[] CalcEta(int k, double[] c)
        {
            return _nodes.AsParallel()
                .Select(t => _initialValues[k] + _h * c.Zip(_phiSobolev.Skip(1), (ci, phiiPlus1) => ci * phiiPlus1(t)).Sum())
                .ToArray();
        }

        private double CalcCoeff(int k, double[][] eta)
        {
            throw new NotImplementedException();
            //var fk = _nodes.Select(t => _f[k].Invoke(_h*t, eta[k]))
        }

    }
}