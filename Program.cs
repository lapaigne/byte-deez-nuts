using System.Numerics;

namespace byte_deez_nuts;

class Program
{
    static void Main(string[] args)
    {
        List<string> results = new List<string>();
        while (true)
        {
            byte[] bytes = Console.ReadLine().Split().Select(x => Convert.ToByte(x)).ToArray();
            try
            {
                UInt16 encoded = SvoiakEncode(bytes);
                results.Add(Binary(encoded));
            }
            catch
            {
                break;
            }
        }
        Console.WriteLine(string.Join("\n", results));

    }

    static UInt16 SvoiakEncode(byte[] numbers)
    {
        UInt16 result = 0;
        if (numbers.Length != 4)
        {
            throw new ArgumentException("Wrong array length");
        }

        for (byte i = 0; i < 4; ++i)
        {
            if (numbers[i] > 16) { throw new ArgumentException($"number at {i} is out of range"); }
            result += (UInt16)(1u << numbers[i]);
        }

        return result;
    }

    static string Binary(UInt16 number)
    {
        string bin = Convert.ToString(number, 2).PadLeft(16, '0');
        return "0b" + bin;
    }
}