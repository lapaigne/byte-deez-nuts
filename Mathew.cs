namespace byte_deez_nuts;

public static class Mathew
{
    public static int Beta = 2;
    public static int P = 53;
    public static int Pf = 24;
    public static double U = 1.0 / (1UL << P);
    public static float Uf = 1.0f / (1U << Pf);

    public static double Gamma(int n)
    {
        return n * U / (1.0 - n * U);
    }
    public static float GammaF(int n) // n * Uf < 1
    {
        return n * Uf / (1.0f - n * Uf);
    }

    private static double Ufp(double x)
    {
        return Math.Pow(Beta, Math.Log2(Math.Abs(x)));
    }

    public static double Ulp(this double x)
    {
        return Math.Pow(Beta, 1 - P) * Ufp(x);
    }

    public static float Ulp(this float x)
    {
        // finish
        if (float.IsNaN(x)) return float.NaN;
        if (float.IsInfinity(x)) return float.NaN;
        if (Math.Abs(x) == float.MaxValue) return (float)(UInt128.One << (127 - 23));
        if (Math.Abs(x) < float.MinValue) throw new NotImplementedException();
        if (Math.Abs(x) == 0.0f) throw new NotImplementedException();
        throw new NotImplementedException();
    }
}