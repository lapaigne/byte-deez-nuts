namespace byte_deez_nuts;

public static class Program
{
    public static void Main(string[] args)
    {
        double x = .1;
        Console.WriteLine(x);

    }

    private static void RunACos()
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