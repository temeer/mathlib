namespace mathlib
{
    public interface IInvFourierTransformer
    {
        double[] Transform(double[] coeffs, double[] nodes);
    }
}