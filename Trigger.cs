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
                break;
            }

            if (MathF.Cos(fNumber) == value)
            {
                yield return fNumber;
            }
        }
    }

    public static float Cos(float value)
    {
        float x2 = value * value;

        float[] fact = [1f, -.5f, 1f / 24, -1f / 720, 1f / 40320, -1f / 3628800];
        float[] pows = new float[6];
        pows[0] = 1.0f;

        for (int i = 1; i < 6; ++i)
        {
            pows[i] = pows[i - 1] * x2;
        }

        // |x2 - x^2| = |x2||(1+delta x - 1)| = |delta x| |x^2| <= u |x2|
        // x2 = RN(x*x) = x*x/(1+delta x)

        // ошибка метода
        // ошибка представления чисел
        // ошибка вычисления скалярного произведения

        return DotProd(fact, pows);
    }

    private static float DotProd(float[] a, float[] b)
    {
        float result = 0f;
        for (int i = 0; i < a.Length; ++i)
        {
            result += a[i] * b[i];
        }

        return result;
    }
}