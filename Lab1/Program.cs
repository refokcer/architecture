using Lab1.Data;
using Lab1.Presentation;
using Lab1.Services;
using System.Text;

namespace Lab1;

internal class Program
{
    private static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        var t = LabInputData.Stages;
        var n = LabInputData.Employees;
        var l = LabInputData.LinesOfCode;

        var nModel = ModelFitter.FitExponential(t, n);
        var lModel = ModelFitter.FitExponential(t, l);
        var powerModel = ModelFitter.FitPowerLaw(n, l);

        ReportPrinter.PrintHeader();
        ReportPrinter.PrintModels(nModel, lModel, powerModel);
        ReportPrinter.PrintComparisonTable(t, n, l, nModel, lModel, powerModel);
    }
}
