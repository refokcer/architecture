using Lab4.Functional.Core;

Console.Write("Enter upper bound: ");
var input = Console.ReadLine();

if (!int.TryParse(input, out var upperLimit) || upperLimit < 1)
{
    Console.Error.WriteLine("Upper bound must be a positive integer.");
    return;
}

var result = PureFunctions.SumOfSquaresForPrimeOrPerfect(upperLimit);
Console.WriteLine($"Sum of squares = {result}");
