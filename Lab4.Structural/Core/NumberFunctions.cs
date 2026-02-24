namespace Lab4.Structural.Core;

public static class NumberFunctions
{
    public static bool IsPrime(int number)
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

    public static bool IsPerfect(int number)
    {
        if (number < 2)
        {
            return false;
        }

        var divisorsSum = 1;
        for (var divisor = 2; divisor * divisor <= number; divisor++)
        {
            if (number % divisor != 0)
            {
                continue;
            }

            divisorsSum += divisor;
            var pairDivisor = number / divisor;
            if (pairDivisor != divisor)
            {
                divisorsSum += pairDivisor;
            }
        }

        return divisorsSum == number;
    }

    public static long SumOfSquaresForPrimeOrPerfect(int upperLimit)
    {
        long sum = 0;

        for (var value = 1; value <= upperLimit; value++)
        {
            if (IsPrime(value) || IsPerfect(value))
            {
                sum += 1L * value * value;
            }
        }

        return sum;
    }
}
