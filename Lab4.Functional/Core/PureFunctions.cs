namespace Lab4.Functional.Core;

public static class PureFunctions
{
    public static bool IsPrime(int number) =>
        number >= 2 && Enumerable.Range(2, Math.Max(0, (int)Math.Sqrt(number) - 1)).All(d => number % d != 0);

    public static bool IsPerfect(int number) =>
        number >= 2 && Enumerable.Range(1, number - 1).Where(d => number % d == 0).Sum() == number;

    public static long SumOfSquaresForPrimeOrPerfect(int upperLimit) =>
        Enumerable.Range(1, upperLimit)
            .Where(value => IsPrime(value) || IsPerfect(value))
            .Select(value => 1L * value * value)
            .Sum();
}
