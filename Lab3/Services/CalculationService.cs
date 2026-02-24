using Lab3.Models;

namespace Lab3.Services;

public sealed class CalculationService : ICalculationService
{
    public decimal Calculate(decimal leftOperand, decimal rightOperand, OperationType operation) => operation switch
    {
        OperationType.Add => leftOperand + rightOperand,
        OperationType.Subtract => leftOperand - rightOperand,
        OperationType.Multiply => leftOperand * rightOperand,
        OperationType.Divide when rightOperand == 0 => throw new DivideByZeroException("Ділення на нуль неможливе."),
        OperationType.Divide => leftOperand / rightOperand,
        _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, "Невідома операція.")
    };
}
