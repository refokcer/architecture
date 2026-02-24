using Lab3.Models;

namespace Lab3.Contracts;

public sealed record CalculationRequest(decimal LeftOperand, decimal RightOperand, OperationType Operation);
