using System;
using System.Linq;
using System.Threading.Tasks;
using mathlib.Polynomials;
using static System.Linq.Enumerable;

namespace mathlib.DiffEq
{
    public class AFiniteDimOperator
    {
        private readonly double _h;
        private readonly DynFunc<double>[] _f;
        private readonly double[] _initialValues;
        private readonly double[] _nodes;
        private Func<double, double>[] _phi;
        private readonly Func<double, double>[] _phiSobolev;
        private readonly int _partialSumOrder; // N
        private readonly int _m;
        //private readonly FourierDiscretePartialSum _sobolevPartSum;

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
            _m = f.First().ArgsCount - 1;

            //_sobolevPartSum = new FourierDiscretePartialSum(_nodes, _phiSobolev);
            
            // TODO: check arguments consistence
        }

        public double[][] GetValue(double[][] c)
        {
            if (c.Length != _m)
                throw new ArgumentOutOfRangeException($"Argument c should have first dimension length equal to {_m}");
            // eta[k][j] = $\eta_k(t_j)$
            var eta = Range(0, _m).AsParallel()
                        .Select(k => CalcEta(k, c[k])).ToArray();

            return CalcCoeffs(eta);
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

        private double[][] CalcCoeffs(double[][] eta)
        {
            //var fk = _nodes.Select(t => _f[k].Invoke(_h * t, eta[k]))
            // fArgs[j][k] = $\eta_k(t_j)$ if k>0 and $h t_j$ if k=0, so
            // fArgs[j] = $(h t_j, \eta_0(t_j), ..., \eta_{m-1}(t_j))$.
            var fArgs = new double[_nodes.Length][];

            for (int j = 0; j < _nodes.Length; j++)
            {
                fArgs[j] = new double[_m+1];
                fArgs[j][0] = _h * _nodes[j];
                for (int k = 1; k < _m + 1; k++)
                {
                    fArgs[j][k] = eta[k-1][j];
                }
            }

            return Range(0,_m).AsParallel()
                .Select(i => Range(0, _partialSumOrder + 1).AsParallel()
                    .Select(k => CalcCoeff(i, k, fArgs)).ToArray()).ToArray();
        }

        /// <summary>
        /// Calculates $c_k(f_j)$
        /// </summary>
        /// <param name="i"></param>
        /// <param name="k"></param>
        /// <param name="fArgs"></param>
        /// <returns></returns>
        private double CalcCoeff(int i, int k, double[][] fArgs)
        {
            // qk[j] = $f_k(h t_j, \eta_0(t_j), ..., \eta_{m-1}(t_j)) * phi_k(t_j)$,
            // so qk is a vector of values of function $q_k(t)=f_k(ht,\eta_0(t),...) phi(t)$ in _nodes
            var qk = _nodes.Select((t, j) => _f[i].Invoke(fArgs[j])*_phi[k](t));
            return Integrals.Trapezoid(qk.ToArray(), _nodes);
        }

    }
}