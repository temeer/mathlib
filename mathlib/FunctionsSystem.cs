using System;
using System.Collections.Generic;
using System.Linq;

namespace mathlib
{
    public interface IFunctionsSystem
    {
        Func<double, double> Get(int k);
        IEnumerable<double> GetValuesOnNet(int k, double[] nodes);
    }

    public abstract class FunctionsSystem : IFunctionsSystem
    {
        public abstract Func<double, double> Get(int k);

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
    }

    public class SobolevCosSystem : FunctionsSystem
    {
        private static readonly double Sqrt2OverPi = Math.Sqrt(2) / Math.PI;
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
    }
}