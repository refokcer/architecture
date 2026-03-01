using Lab6.Domain.Abstractions;
using Lab6.Domain.Generators;
using Lab6.Domain.Models;

namespace Lab6.Infrastructure.Factories;

public sealed class FractalGeneratorFactory : IFractalGeneratorFactory
{
    public IFractalGenerator Create(FractalType type) => type switch
    {
        FractalType.SierpinskiTriangle => new SierpinskiTriangleGenerator(),
        FractalType.SierpinskiCarpet => new SierpinskiCarpetGenerator(),
        FractalType.KochSnowflake => new KochSnowflakeGenerator(),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Unknown fractal type")
    };
}
