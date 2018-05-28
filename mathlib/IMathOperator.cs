namespace mathlib
{
    public interface IMathOperator<T>
    {
        T GetValue(T x);
    }
}