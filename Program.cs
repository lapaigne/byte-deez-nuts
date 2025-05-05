namespace byte_deez_nuts;

public static class Program
{
    public static void Main(string[] args)
    {

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
}