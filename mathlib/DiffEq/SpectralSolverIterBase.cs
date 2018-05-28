using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DiscreteFunctions;
using static System.Linq.Enumerable;

namespace mathlib.DiffEq
{
    public abstract class SpectralSolverIterBase<T>
    {
        protected readonly IEnumerable<Func<double, double>> _phi;
        protected readonly IEnumerable<Func<double, double>> _phiSobolev;

        protected SpectralSolverIterBase(IEnumerable<Func<double, double>> phi, 
            IEnumerable<Func<double, double>> phiSobolev)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="odeRightSide">Array of functions f_i(x,y_1,y_2,...,y_m) that represents ODE system right side, i. e.
        /// y_i'(x)=f_i(x,y1,y2,...,ym), i=1,...,m.
        /// </param>
        /// <param name="initialValues">y_i(a), i=1,...,m</param>
        /// <param name="coeffsCount"></param>
        /// <param name="quadratureNodes">Some implementations may require nodes for calculating integrals</param>
        /// <returns></returns>
        //public void SetParams(DynFunc<double>[] odeRightSide, double[] initialValues,
        //    int coeffsCount, double[] quadratureNodes = null)
        //{
        //}

        
        protected abstract IMathOperator<T> GetCoeffsOperator();
        protected abstract T GetInitialCoeffs();

        /// <summary>
        /// Solves ODE system on [0,1]
        /// </summary>
        /// <param name="odeRightSide">Array of functions f_i(x,y_1,y_2,...,y_m) that represents ODE system right side, i. e.
        /// y_i'(x)=f_i(x,y1,y2,...,ym), i=1,...,m.
        /// </param>
        /// <param name="initialValues">Solutions values at start point: y_i(a), i=1,...,m</param>
        /// <param name="coeffsCount"></param>
        /// <param name="iterCount"></param>
        /// <returns></returns>
        public DiscreteFunction2D[] Solve(DynFunc<double>[] odeRightSide, double[] initialValues, int coeffsCount, int iterCount)
        {
            //var f = new DynFunc<double>[] {new D};
            var op = GetCoeffsOperator();
            var m = odeRightSide.First().ArgsCount - 1;
            var initCoeffs = GetInitialCoeffs();
            var result = FixedPointIteration.FindFixedPoint(c => op.GetValue(c), initCoeffs, iterCount, c =>
            {
                for (int i = 0; i < c.Length; i++)
                {
                    Trace.WriteLine("");
                    for (int j = 0; j < c[i].Length; j++)
                    {
                        Trace.Write($"{c[i][j],-5:F10} ");
                    }
                }
                Trace.WriteLine("");
            });
            var sobolevPartSum = new FourierDiscretePartialSum(nodes, phiSobolev);
            return result.Select((coeffs, j) => sobolevPartSum.GetValues(new[] { initialValues[j] }.Concat(coeffs))).ToArray();
        }

        public DiscreteFunction2D[] Solve(Func<double, double, double> f, double[] nodes, double[] initialValues,
            int partialSumOrder, int iterCount) =>
            Solve(new[] { new DynFunc<double>(2, doubles => f(doubles[0], doubles[1])) }, nodes, initialValues,
                partialSumOrder, iterCount);

        /// <summary>
        /// Solves ODE system on segment
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="f"></param>
        /// <param name="nodes">Nodes should be inside segment</param>
        /// <param name="initialValues"></param>
        /// <param name="partialSumOrder"></param>
        /// <param name="iterCount"></param>
        /// <returns></returns>
        public DiscreteFunction2D[] Solve(Segment segment, DynFunc<double>[] f, double[] nodes, double[] initialValues,
            int partialSumOrder, int iterCount)
        {
            var h = segment.Length;
            // to apply iter method we should linear transform segment to [0,1]
            // transformedF(x,y)=(segment.End-segment.Start)*f((segment.End-segment.Start)x+segment.Start)
            var transformedF = f.Select(fj =>
                new DynFunc<double>(fj.ArgsCount, doubles =>
                {
                    var newDoubles = new double[doubles.Length];
                    Array.Copy(doubles, newDoubles, doubles.Length);
                    newDoubles[0] = h * doubles[0] + segment.Start;
                    return h * fj.Invoke(newDoubles);
                })).ToArray();

            var dfs = Solve(transformedF, nodes.Select(x => (x - segment.Start) / h).ToArray(),
                initialValues, partialSumOrder, iterCount);

            // dfs is defined on [0,1] and we should transform it to [segment.Start, segment.End]
            return dfs.Select(df =>
                new DiscreteFunction2D(df.X.Select(x => h * x + segment.Start).ToArray(),
                                       df.Y)).ToArray();
        }

        public DiscreteFunction2D[] Solve(Segment segment, Func<double, double, double> f, double[] nodes, double[] initialValues,
            int partialSumOrder, int iterCount) =>
            Solve(segment, new[] { new DynFunc<double>(2, doubles => f(doubles[0], doubles[1])) }, nodes, initialValues,
                partialSumOrder, iterCount);

        public List<DiscreteFunction2D[]> Solve(Segment segment, int chunksCount, DynFunc<double>[] f, double[] nodes, double[] initialValues,
            int partialSumOrder, int iterCount)
        {
            var dfs = new List<DiscreteFunction2D[]>();
            var a = segment.Start;
            var b = segment.End;
            var h = (b - a) / chunksCount;
            var initVals = new double[initialValues.Length];
            Array.Copy(initialValues, initVals, initialValues.Length);
            for (int j = 0; j < chunksCount; j++)
            {
                var chunk = new Segment(a + j * h, a + (j + 1) * h);
                var chunkNodes = chunk.GetUniformPartition(nodes.Length);
                var dfsOnChunk = Solve(chunk, f, chunkNodes, initVals, partialSumOrder, iterCount);
                dfs.Add(dfsOnChunk);
                initVals = dfsOnChunk.Select(df => df.Y.Last()).ToArray();
            }
            return dfs;
        }

        public List<DiscreteFunction2D[]> Solve(Segment segment, int chunksCount, Func<double, double, double> f,
            double[] nodes, double[] initialValues, int partialSumOrder, int iterCount)
            => Solve(segment, chunksCount, new[] { new DynFunc<double>(2, doubles => f(doubles[0], doubles[1])) },
                nodes, initialValues, partialSumOrder, iterCount);
    }
}