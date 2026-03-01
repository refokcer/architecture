using Lab6.Domain.Models;

namespace Lab6.Domain.Abstractions;

public interface IFractalGeneratorFactory
{
    IFractalGenerator Create(FractalType type);
}
