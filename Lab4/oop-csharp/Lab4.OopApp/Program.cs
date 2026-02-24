using Lab4.OopApp.Services;

Console.Write("Enter upper bound: ");
var input = Console.ReadLine();

if (!int.TryParse(input, out var upperLimit) || upperLimit < 1)
{
    Console.Error.WriteLine("Upper bound must be a positive integer.");
    return;
}

var calculator = new SquareSumCalculator(new NumberAnalyzer());
var result = calculator.CalculateUpTo(upperLimit);

Console.WriteLine($"Sum of squares = {result}");
