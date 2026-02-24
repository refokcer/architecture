namespace Lab4.OOP.Services;

public sealed class SumCalculator
{
    private readonly NumberAnalyzer _analyzer;

    public SumCalculator(NumberAnalyzer analyzer)
    {
        _analyzer = analyzer;
    }

    public long Calculate(int upperLimit)
    {
        long sum = 0;

        for (var value = 1; value <= upperLimit; value++)
        {
            if (_analyzer.Analyze(value).IsPrimeOrPerfect)
            {
                sum += 1L * value * value;
            }
        }

        return sum;
    }
}
