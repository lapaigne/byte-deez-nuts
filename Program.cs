using byte_deez_nuts;
using f64 = double;

public static class Program
{
    public static void Main(string[] args)
    {
        Exam.ComputePI();
    }

    private static void OhOne()
    {
        double x = .1;
        Int64 ix = BitConverter.DoubleToInt64Bits(x);
        Console.WriteLine(x.ToString("F64"));
        Console.WriteLine(ix.ToString("B64"));

        double nx = x.NextAfter();
        Int64 inx = BitConverter.DoubleToInt64Bits(nx);
        Console.WriteLine(nx.ToString("F64"));
        Console.WriteLine(inx.ToString("B64"));

        /*Console.WriteLine((1 - Mathew.Ulp(1.0)).ToString("F64"));*/
    }

    private static void RunAcos()
    {
        var result = Trigger.Acos(1);
        Console.WriteLine(result.First());
        var last = BitConverter.SingleToUInt32Bits(result.Last());
        Console.WriteLine(last.ToBinary());
        Console.WriteLine(MathF.Log2(last));
    }

    private static void RunSwojak()
    {
        List<string> results = new List<string>();
        while (true)
        {
            byte[] bytes = Console.ReadLine().Split().Select(x => Convert.ToByte(x)).ToArray();
            try
            {
                UInt16 encoded = bytes.SwojakEncode();
                results.Add(encoded.ToBinary());
            }
            catch
            {
                break;
            }
        }

        Console.WriteLine(string.Join("\n", results));
    }

    private static void RunDot(int x)
    {
        // calc dot prod for 1/2
        int size = 4;
        List<float> powers = new List<float>();
        List<float> denominators = new List<float>();
        powers[0] = x;
        denominators[0] = 1;
        for (int i = 1; i <= size; ++i)
        {
            powers[i] = powers[i - 1] * x * x;
        }
        float dot = Dotter.DotProduct(ref powers, ref denominators, out float estimate);
    }
}