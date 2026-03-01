using Lab6.Domain.Models;

namespace Lab6.Domain.Abstractions;

public interface IFractalGenerator
{
    FractalScene Generate(FractalParameters parameters);
}
