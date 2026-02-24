using Lab1.Models;

namespace Lab1.Math;

internal static class LinearRegression
{
    public static RegressionResult Fit(double[] x, double[] y)
    {
        if (x.Length != y.Length)
        {
            throw new ArgumentException("Масиви x та y мають бути однакової довжини.");
        }

        if (x.Length < 2)
        {
            throw new ArgumentException("Для регресії потрібно щонайменше 2 точки.");
        }

        var xMean = x.Average();
        var yMean = y.Average();

        var covariance = 0.0;
        var variance = 0.0;

        for (var i = 0; i < x.Length; i++)
        {
            var dx = x[i] - xMean;
            covariance += dx * (y[i] - yMean);
            variance += dx * dx;
        }

        if (variance == 0)
        {
            throw new ArgumentException("Неможливо виконати регресію: усі x однакові.");
        }

        var slope = covariance / variance;
        var intercept = yMean - slope * xMean;

        var totalSumOfSquares = 0.0;
        var residualSumOfSquares = 0.0;

        for (var i = 0; i < x.Length; i++)
        {
            var predicted = intercept + slope * x[i];
            totalSumOfSquares += System.Math.Pow(y[i] - yMean, 2);
            residualSumOfSquares += System.Math.Pow(y[i] - predicted, 2);
        }

        var rSquared = totalSumOfSquares == 0 ? 1.0 : 1.0 - residualSumOfSquares / totalSumOfSquares;

        return new RegressionResult(intercept, slope, rSquared);
    }
}
