using f64 = double;
using i32 = int;

public static class Exam
{
    public static readonly i32 LIMIT = 16;
    public static readonly i32 P = 53;

    public static readonly f64 U = 1.0 / (1UL << P);
    public static readonly f64 PI = Math.PI;

    public static (f64 value, f64 error) Atan(f64 x)
    {
        f64 x2 = x * x;
        f64[] numerators = new f64[LIMIT];
        numerators[0] = x;

        f64[] denumerators = new f64[] {
            1.0,
            -1.0 / 3,
            1.0 / 5,
            -1.0 / 7,

            1.0 / 9,
            -1.0 / 11,
            1.0 / 13,
            -1.0 / 15,

            1.0 / 17,
            -1.0 / 19,
            1.0 / 21,
            -1.0 / 23,

            1.0 / 25,
            -1.0 / 27,
            1.0 / 29,
            -1.0 / 31,
        };

        for (i32 i = 1; i < LIMIT; ++i)
        {
            numerators[i] = numerators[i - 1] * x2;
        }

        f64 absSum = 0;
        f64 dotProduct = 0;
        for (i32 i = 0; i < LIMIT; ++i)
        {
            f64 t = numerators[i] * denumerators[i];
            absSum += Math.Abs(t);
            dotProduct += t;
        }

        f64 cutError = Ulp(1.0 / 33 * numerators.Last());
        f64 roundError = U * absSum;
        f64 sumError = Gamma(LIMIT) * absSum;
        f64 totalError = cutError + roundError + sumError;

        return (dotProduct, totalError);
    }

    public static void ComputePI()
    {
        f64 x1 = 1.0 / 5;
        f64 x2 = 1.0 / 239;

        var (x1Atan, x1Err) = Atan(x1);
        var (x2Atan, x2Err) = Atan(x2);

        f64 computed = 16 * x1Atan - 4 * x2Atan;

        Console.WriteLine($"M.PI = {Math.PI.ToString("F64")}");
        Console.WriteLine($"PI   = {computed.ToString("F64")}");
        Console.WriteLine($"Error: {x1Err + x2Err + RN(x1) + RN(x2)}");
    }

    public static void Print()
    {
        f64 calculated = 0;
        f64 error = 0;
        Console.WriteLine($"{calculated.ToString("F64")}\n{error.ToString("F64")}");
    }

    public static f64 RN(this f64 number)
    {
        return number * U;
    }

    public static f64 Gamma(i32 n)
    {
        return n * U / (1.0 - n * U);
    }

    public static f64 Ulp(f64 value)
    {
        if (f64.IsNaN(value)) return f64.NaN;
        if (f64.IsInfinity(value)) return f64.PositiveInfinity;
        if (Math.Abs(value) == f64.MaxValue) return f64.Epsilon * f64.MaxValue * 2;
        if (Math.Abs(value) == 0 || Math.Abs(value) < f64.MinValue) return f64.Epsilon;
        f64 nextValue = value > 0 ? f64.BitIncrement(value) : f64.BitDecrement(value);
        return Math.Abs(nextValue - value);
    }
}