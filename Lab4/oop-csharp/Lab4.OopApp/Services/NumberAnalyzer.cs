using Lab4.OopApp.Models;

namespace Lab4.OopApp.Services;

public sealed class NumberAnalyzer
{
    public NumberClassification Analyze(int value)
    {
        return new NumberClassification(value, IsPrime(value), IsPerfect(value));
    }

    private static bool IsPrime(int number)
    {
        if (number < 2)
        {
            return false;
        }

        for (var divisor = 2; divisor * divisor <= number; divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsPerfect(int number)
    {
        if (number < 2)
        {
            return false;
        }

        var divisorsSum = 1;
        for (var divisor = 2; divisor * divisor <= number; divisor++)
        {
            if (number % divisor == 0)
            {
                divisorsSum += divisor;
                var pairDivisor = number / divisor;
                if (pairDivisor != divisor)
                {
                    divisorsSum += pairDivisor;
                }
            }
        }

        return divisorsSum == number;
    }
}
