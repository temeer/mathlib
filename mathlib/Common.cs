namespace mathlib
{
    public class Common
    {
        public static int Factorial(int n)
        {
            int prod = 1;
            for (int i = 2; i <= n; i++)
            {
                prod *= i;
            }
            return prod;
        }
    }
}