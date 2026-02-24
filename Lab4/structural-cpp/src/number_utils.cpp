#include "../include/number_utils.h"

bool isPrime(int number)
{
    if (number < 2)
    {
        return false;
    }

    for (int divisor = 2; divisor * divisor <= number; ++divisor)
    {
        if (number % divisor == 0)
        {
            return false;
        }
    }

    return true;
}

bool isPerfect(int number)
{
    if (number < 2)
    {
        return false;
    }

    int divisorsSum = 1;

    for (int divisor = 2; divisor * divisor <= number; ++divisor)
    {
        if (number % divisor == 0)
        {
            divisorsSum += divisor;

            const int pairDivisor = number / divisor;
            if (pairDivisor != divisor)
            {
                divisorsSum += pairDivisor;
            }
        }
    }

    return divisorsSum == number;
}

long long sumOfSquaresForPrimeOrPerfect(int upperLimit)
{
    long long sum = 0;

    for (int value = 1; value <= upperLimit; ++value)
    {
        if (isPrime(value) || isPerfect(value))
        {
            sum += 1LL * value * value;
        }
    }

    return sum;
}
