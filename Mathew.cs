namespace byte_deez_nuts;

public static class Mathew
{
    public static int Beta = 2;
    public static int P = 53;
    public static double U = 1.0 / (1L << P);

    public static double Gamma(int n)
    {
        return n * U / (1 - n * U);
    }

    private static double Ufp(double x)
    {
        return Math.Pow(Beta, Math.Log2(Math.Abs(x)));
    }

    public static double Ulp(this double x)
    {
        return Math.Pow(Beta, 1 - P) * Ufp(x);
    }
}