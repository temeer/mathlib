using System;

namespace mathlib
{
    /// <summary>
    /// Arguments count of DynFunc can be set in runtime
    /// </summary>
    public class DynFunc<T>
    {
        private readonly Func<T[], T> _func;
        public int ArgsCount { get; }

        public DynFunc(int argsCount, Func<T[],T> func)
        {
            _func = func;
            ArgsCount = argsCount;
        }

        public T Invoke(params T[] args)
        {
            if (args.Length != ArgsCount)
                throw new ArgumentOutOfRangeException($"Incorrect number of arguments: should be {ArgsCount}, but was {args.Length}");
            return _func(args);
        }

    }
}