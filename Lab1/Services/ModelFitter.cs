using Lab1.Math;
using Lab1.Models;

namespace Lab1.Services;

internal static class ModelFitter
{
    public static FittedModel FitExponential(double[] x, double[] y)
    {
        var lnY = y.Select(System.Math.Log).ToArray();
        var regression = LinearRegression.Fit(x, lnY);

        return new FittedModel(System.Math.Exp(regression.Intercept), regression.Slope, regression.RSquared);
    }

    public static FittedModel FitPowerLaw(double[] x, double[] y)
    {
        var lnX = x.Select(System.Math.Log).ToArray();
        var lnY = y.Select(System.Math.Log).ToArray();
        var regression = LinearRegression.Fit(lnX, lnY);

        return new FittedModel(System.Math.Exp(regression.Intercept), regression.Slope, regression.RSquared);
    }
}
