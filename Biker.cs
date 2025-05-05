namespace byte_deez_nuts;

public static class Biker
{
    public static string ToBinary(this UInt16 number)
    {
        return "0b" + Convert.ToString(number, 2).PadLeft(16, '0');
    }

    public static string ToBinary(this UInt32 number)
    {
        return "0b" + Convert.ToString(number, 2).PadLeft(32, '0');
    }
}