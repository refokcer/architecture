using Lab6.Application;
using Lab6.Domain.Models;

namespace Lab6.Presentation;

public sealed class ConsoleUi(FractalApplication app)
{
    public void Run()
    {
        Console.WriteLine("=== Lab6: Фрактальні структури і шаблони ===");
        Console.WriteLine("Доступні фрактали:");
        Console.WriteLine("1 - Трикутник Серпінського");
        Console.WriteLine("2 - Килим Серпінського");
        Console.WriteLine("3 - Сніжинка Коха");

        var type = (FractalType)ReadInt("Оберіть тип (1-3): ", 1, 3);
        var iterations = ReadInt("Кількість ітерацій (0-7): ", 0, 7);
        var canvas = ReadInt("Розмір полотна (256-4096): ", 256, 4096);

        Console.Write("Колір ліній (наприклад #0088ff або black, enter=black): ");
        var stroke = ReadStringOrDefault("black");

        Console.Write("Колір фону (наприклад #ffffff, enter=white): ");
        var background = ReadStringOrDefault("white");

        var strokeWidth = ReadDouble("Товщина ліній (0.1-10): ", 0.1, 10);

        var parameters = new FractalParameters(type, iterations, canvas, stroke, background, strokeWidth);
        var outputPath = app.BuildFractal(parameters, Path.Combine(AppContext.BaseDirectory, "generated"));

        Console.WriteLine();
        Console.WriteLine("Фрактал збережено у SVG:");
        Console.WriteLine(outputPath);
    }

    private static int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            var text = Console.ReadLine();
            if (int.TryParse(text, out var value) && value >= min && value <= max)
            {
                return value;
            }

            Console.WriteLine($"Введіть число в діапазоні [{min}; {max}].");
        }
    }

    private static double ReadDouble(string prompt, double min, double max)
    {
        while (true)
        {
            Console.Write(prompt);
            var text = Console.ReadLine();
            if (double.TryParse(text, out var value) && value >= min && value <= max)
            {
                return value;
            }

            Console.WriteLine($"Введіть число в діапазоні [{min}; {max}].");
        }
    }

    private static string ReadStringOrDefault(string fallback)
    {
        var text = Console.ReadLine();
        return string.IsNullOrWhiteSpace(text) ? fallback : text.Trim();
    }
}
