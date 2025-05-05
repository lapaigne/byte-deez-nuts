namespace byte_deez_nuts;

public static class Swojak
{
    public static UInt16 SwojakEncode(this byte[] numbers)
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
}