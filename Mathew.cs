public static class Mathew
{
    public readonly static int Beta = 2;
    public readonly static int P = 53;
    public readonly static double U = 1.0 / (1UL << P);

    public static double Gamma(int n)
    {
        return n * U / (1.0 - n * U);
    }

    public static double NextAfter(this double number)
    {
        return double.BitIncrement(number);
    }
}