using f64 = double;
using i32 = int;

public static class Exam
{
    public static readonly i32 COUNT = 16;

    public static readonly f64 U = 1.0 / (1L << 53);

    public static (f64 value, f64 error) Atan(f64 x)
    {
        f64 x2 = x * x;
        f64[] numerators = new f64[COUNT];
        numerators[0] = x;

        f64[] denominator = new f64[]
        {
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

        for (i32 i = 1; i < COUNT; ++i)
        {
            numerators[i] = numerators[i - 1] * x2;
        }

        f64[] ts = new f64[COUNT];
        f64[] ats = new f64[COUNT];

        for (i32 i = 0; i < COUNT; ++i)
        {
            f64 t = numerators[i] * denominator[i];
            ts[i] = t;
            ats[i] = Math.Abs(t);
        }

        f64 dotProduct = ts.ToList().PairwiseSum();
        f64 absSum = ats.ToList().PairwiseSum();

        /*---*/

        f64 xError = x * U;
        f64 x2Error = x2 * 3 * U / (1 - 2 * U);

        f64 numError = 0;
        for (i32 i = 0; i < COUNT; ++i)
        {
            numError += Math.Abs(numerators[i]) * Gamma(1 + 4 * i);
        }

        f64 roundError = absSum * Gamma(4);

        f64 repError = xError + x2Error + numError + roundError;

        /*---*/

        f64 cutError = 1.0 / 33 * numerators.Last() * x2;

        /*---*/

        f64 sumError = Gamma(COUNT - 1) * absSum;

        /*---*/

        f64 totalError = repError + cutError + sumError;

        return (dotProduct, totalError);
    }

    public static void ComputePI()
    {
        f64 x1 = 1.0 / 5;
        f64 x2 = 1.0 / 239;

        var (x1Atan, x1Err) = Atan(x1);
        var (x2Atan, x2Err) = Atan(x2);

        f64 computed = 16 * x1Atan - 4 * x2Atan;

        f64 finalErr = computed * U;
        f64 error = x1Err + x2Err + finalErr;

        /*Console.WriteLine("Nums : 0.123456789abcdef0123456789abcdef");*/
        /*Console.WriteLine($"M.PI = {Math.PI.ToString("F64")}");*/
        Console.WriteLine($"PI   = {computed.ToString("F64")}");
        Console.WriteLine($"Error: {error}");
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

    public static f64 PairwiseSum(this List<f64> numbers)
    {
        if (numbers.Count == 0) { throw new ArgumentException("Empty collection"); }

        while (true)
        {
            if (numbers.Count == 1) { return numbers[0]; }
            for (i32 i = 0; i < numbers.Count / 2; ++i)
            {
                numbers[2 * i] += numbers[2 * i + 1];
                numbers[2 * i + 1] = f64.NaN;
            }
            numbers.RemoveAll(x => f64.IsNaN(x));
        }
    }
}