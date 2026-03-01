using Lab6.Domain.Abstractions;
using Lab6.Domain.Models;

namespace Lab6.Application;

public sealed class FractalApplication(IFractalGeneratorFactory generatorFactory, ISceneRenderer sceneRenderer)
{
    public string BuildFractal(FractalParameters parameters, string outputDirectory)
    {
        Validate(parameters);
        var generator = generatorFactory.Create(parameters.Type);
        var scene = generator.Generate(parameters);
        return sceneRenderer.Render(scene, parameters, outputDirectory);
    }

    private static void Validate(FractalParameters parameters)
    {
        if (parameters.Iterations < 0 || parameters.Iterations > 7)
        {
            throw new ArgumentOutOfRangeException(nameof(parameters.Iterations), "Iterations must be from 0 to 7.");
        }

        if (parameters.CanvasSize < 256 || parameters.CanvasSize > 4096)
        {
            throw new ArgumentOutOfRangeException(nameof(parameters.CanvasSize), "CanvasSize must be from 256 to 4096.");
        }

        if (parameters.StrokeWidth <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(parameters.StrokeWidth), "StrokeWidth must be positive.");
        }
    }
}
