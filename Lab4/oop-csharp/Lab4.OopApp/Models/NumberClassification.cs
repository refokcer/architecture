namespace Lab4.OopApp.Models;

public sealed class NumberClassification
{
    public NumberClassification(int value, bool isPrime, bool isPerfect)
    {
        Value = value;
        IsPrime = isPrime;
        IsPerfect = isPerfect;
    }

    public int Value { get; }
    public bool IsPrime { get; }
    public bool IsPerfect { get; }

    public bool IsPrimeOrPerfect => IsPrime || IsPerfect;
}
