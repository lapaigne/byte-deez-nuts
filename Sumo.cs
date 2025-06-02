namespace joe_byten;

public static class Sumo
{
    public static double RecursiveSum(this List<double> numbers)
    {
        double result = 0;
        for (int i = 0; i < numbers.Count; ++i)
        {
            result += numbers[i];
        }
        return result;
    }

    public static double PairwiseSum(this List<double> numbers)
    {
        if (numbers.Count == 0) { throw new ArgumentException("Empty collection"); }

        while (true)
        {
            if (numbers.Count == 1) { return numbers[0]; }
            for (int i = 0; i < numbers.Count / 2; ++i)
            {
                numbers[2 * i] += numbers[2 * i + 1];
                numbers[2 * i + 1] = double.NaN;
            }
            numbers.RemoveAll(x => double.IsNaN(x));
        }
    }

    public static double InsertionSum(this List<double> numbers)
    {
        // добавлять следующее число так, чтобы модуль суммы оставался минимальным
        double result = 0;
        return result;
    }
}