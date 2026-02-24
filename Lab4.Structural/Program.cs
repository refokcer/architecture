using Lab4.Structural.Core;

Console.Write("Enter upper bound: ");
var input = Console.ReadLine();

if (!int.TryParse(input, out var upperLimit) || upperLimit < 1)
{
    Console.Error.WriteLine("Upper bound must be a positive integer.");
    return;
}

var result = NumberFunctions.SumOfSquaresForPrimeOrPerfect(upperLimit);
Console.WriteLine($"Sum of squares = {result}");
