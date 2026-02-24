namespace Lab4.OopApp.Services;

public sealed class SquareSumCalculator
{
    private readonly NumberAnalyzer _analyzer;

    public SquareSumCalculator(NumberAnalyzer analyzer)
    {
        _analyzer = analyzer;
    }

    public long CalculateUpTo(int upperLimit)
    {
        long sum = 0;

        for (var value = 1; value <= upperLimit; value++)
        {
            var classification = _analyzer.Analyze(value);
            if (classification.IsPrimeOrPerfect)
            {
                sum += 1L * value * value;
            }
        }

        return sum;
    }
}
