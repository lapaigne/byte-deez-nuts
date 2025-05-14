namespace byte_deez_nuts;

public static class Dotter
{
    public static double Sin(double a)
    {
        throw new NotImplementedException();
    }

    public static float DotProduct(ref List<float> a, ref List<float> b, out float estimate)
    {
        if (a.Count != b.Count)
        {
            throw new ArgumentException("Vector lengths don't match");
        }
        float result = 0.0f;
        estimate = 0.0f;
        for (int i = 0; i < a.Count; ++i)
        {
            result += a[i] * b[i];
            estimate += Math.Abs(a[i]) * Math.Abs(b[i]);

        }
        throw new NotImplementedException();
    }
}

// 1. Ошибка метода
// |R_n(x)| <= |x^(2(n+1)+1)/(2(n+1)+1)!|
//
// 2. x^(2k-1)*x^2 == x^(2k+1)
// float p = 24;
// 2^24
// 9! - cap
//
// 3. От получения скалярного произведения