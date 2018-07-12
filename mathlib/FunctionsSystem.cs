using System;
using System.Collections.Generic;
using System.Linq;

namespace mathlib
{
    public interface IFunctionsSystem
    {
        Segment OrthogonalitySegment { get; }
        Func<double, double> Get(int k);
        IEnumerable<double> GetValuesOnNet(int k, double[] nodes);
    }

    public abstract class FunctionsSystem : IFunctionsSystem
    {
        public abstract Func<double, double> Get(int k);
        public abstract Segment OrthogonalitySegment { get; }
        public virtual IEnumerable<double> GetValuesOnNet(int k, double[] nodes) =>
            nodes.Select(Get(k));
    }

    public class CosSystem : FunctionsSystem
    {
        private static readonly double Sqrt2 = Math.Sqrt(2);

        public override Func<double, double> Get(int k)
        {
            if (k == 0)
                return x => 1;
            return x => Sqrt2 * Math.Cos(k * Math.PI * x);
        }

        public override Segment OrthogonalitySegment => new Segment(0, 1);
    }

    public class SobolevCosSystem : FunctionsSystem
    {
        private static readonly double Sqrt2OverPi = Math.Sqrt(2.0) / Math.PI;
        public override Func<double, double> Get(int k)
        {
            switch (k)
            {
                case 0: return x => 1;
                case 1: return x => x;
                default:
                    k -= 1;
                    return x => Sqrt2OverPi * Math.Sin(k * Math.PI * x) / k;
            }
        }

        public override Segment OrthogonalitySegment => new Segment(0, 1);
    }







    public class Cheb1System : FunctionsSystem
    {
        private static readonly double OneOverSqrt2 = 1.0 / Math.Sqrt(2.0);

        public override Func<double, double> Get(int k)
        {
            if (k == 0)
                return x => OneOverSqrt2;
            return x => Math.Cos(k * Math.Acos(x));
        }

        public override Segment OrthogonalitySegment => new Segment(-1, 1);
    }

    public class SobolevCheb1System : FunctionsSystem
    {
        private static readonly double OneOverSqrt2 = 1.0 / Math.Sqrt(2.0);
        private static readonly FunctionsSystem chebSystem = new Cheb1System();

        public override Func<double, double> Get(int k)
        {
            switch (k)
            {
                case 0: return x => 1.0;
                case 1: return x => (1.0 + x) * OneOverSqrt2;
                case 2: return x => (x * x - 1.0) * 0.5;
                default:
                    var Tk = chebSystem.Get(k); //T[k] -- Chebyshev polynomial
                    var Tk2 = chebSystem.Get(k-2); //T[k-2] -- Chebyshev polynomial
                    if (k % 2 == 0) {
                        return x =>
                            Tk(x) * 0.5 / (double)k + Tk2(x) * 0.5 / (k - 2.0) + 1.0 / (k * k - 2.0 * k);
                    } else {
                        return x =>
                            Tk(x) * 0.5 / (double)k + Tk2(x) * 0.5 / (k - 2.0) - 1.0 / (k * k - 2.0 * k);
                    }
            }
        }
        public override Segment OrthogonalitySegment => new Segment(-1, 1);
    }


        

    public class Cheb1Weight : FunctionsSystem
    {
        private static readonly double OneOverSqrt2 = 1.0 / Math.Sqrt(2.0);

        public override Func<double, double> Get(int k)
        {
            return x => OrthogonalWeights.Cheb1Weight(x);
        }

        public override Segment OrthogonalitySegment => new Segment(-1, 1);
    }






    public static class OrthogonalWeights
    {
        private static readonly double Sqrt2OverPi = Math.Sqrt(2.0) / Math.PI;


        public static Func<double, double> Cheb1Weight
        {
            get
            {
                return x => Sqrt2OverPi / Math.Sqrt(1.0 - x * x);
            }
        }

        public static Func<double, double> UniteWeight
        {
            get
            {
                return UniformWeight();
            }
        }

        public static Func<double, double> UniformWeight(double A = 1.0)
        {
                return x => A;
        }

    }






}