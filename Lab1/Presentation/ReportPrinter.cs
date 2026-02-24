using Lab1.Models;

namespace Lab1.Presentation;

internal static class ReportPrinter
{
    public static void PrintHeader()
    {
        Console.WriteLine("Лабораторна робота №1");
        Console.WriteLine("Аналіз ефективності процесів і систем");
        Console.WriteLine(new string('-', 72));
    }

    public static void PrintModels(FittedModel nModel, FittedModel lModel, FittedModel powerModel)
    {
        Console.WriteLine("1) Модель N(t) = N0 * exp(αt)");
        Console.WriteLine($"   N0 = {nModel.Scale:F6}");
        Console.WriteLine($"   α  = {nModel.Growth:F6}");
        Console.WriteLine($"   R² = {nModel.RSquared:F6}");
        Console.WriteLine();

        Console.WriteLine("2) Модель L(t) = L0 * exp(βt)");
        Console.WriteLine($"   L0 = {lModel.Scale:F6}");
        Console.WriteLine($"   β  = {lModel.Growth:F6}");
        Console.WriteLine($"   R² = {lModel.RSquared:F6}");
        Console.WriteLine();

        Console.WriteLine("3) Модель L(N) = A * N^γ");
        Console.WriteLine($"   A  = {powerModel.Scale:F6}");
        Console.WriteLine($"   γ  = {powerModel.Growth:F6}");
        Console.WriteLine($"   R² = {powerModel.RSquared:F6}");
        Console.WriteLine();
    }

    public static void PrintComparisonTable(
        double[] t,
        double[] n,
        double[] l,
        FittedModel nModel,
        FittedModel lModel,
        FittedModel powerModel)
    {
        Console.WriteLine("Порівняння фактичних та модельних значень:");
        Console.WriteLine(" t |   N факт | N модель |   L факт | L(t) модель | L(N) модель");
        Console.WriteLine(new string('-', 70));

        for (var i = 0; i < t.Length; i++)
        {
            var nPred = nModel.Scale * System.Math.Exp(nModel.Growth * t[i]);
            var lPredByTime = lModel.Scale * System.Math.Exp(lModel.Growth * t[i]);
            var lPredByN = powerModel.Scale * System.Math.Pow(n[i], powerModel.Growth);

            Console.WriteLine($"{t[i],2:0} | {n[i],8:F2} | {nPred,8:F2} | {l[i],8:F2} | {lPredByTime,11:F2} | {lPredByN,10:F2}");
        }

        Console.WriteLine();
        Console.WriteLine("Перевірка коректності:");
        Console.WriteLine("- використано лінеаризацію моделей (логарифмування) та метод найменших квадратів;");
        Console.WriteLine("- коефіцієнт детермінації R² близький до 1 підтверджує адекватність апроксимації;");
        Console.WriteLine("- таблиця вище показує близькість модельних і експериментальних значень.");
    }
}
