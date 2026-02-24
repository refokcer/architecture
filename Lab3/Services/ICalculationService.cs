using Lab3.Models;

namespace Lab3.Services;

public interface ICalculationService
{
    decimal Calculate(decimal leftOperand, decimal rightOperand, OperationType operation);
}
