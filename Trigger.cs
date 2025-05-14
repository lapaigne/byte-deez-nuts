namespace byte_deez_nuts;

public static class Trigger
{
    public static IEnumerable<float> Acos(float value)
    {
        /*1 8 23*/
        Int32 kmax = (1 << 23) * 127 + 1;

        for (Int32 i = 0; i < kmax; ++i)
        {
            float fNumber = BitConverter.Int32BitsToSingle(i);

            if (MathF.Abs(fNumber) > 1)
            {
                continue;
            }

            if (MathF.Cos(fNumber) == value)
            {
                yield return fNumber;
            }
        }
    }
}