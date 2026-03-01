using Lab6.Domain.Abstractions;
using Lab6.Domain.Models;

namespace Lab6.Infrastructure.Rendering;

public sealed class MetricsRendererDecorator(ISceneRenderer innerRenderer) : ISceneRenderer
{
    public string Render(FractalScene scene, FractalParameters parameters, string outputDirectory)
    {
        var started = DateTime.UtcNow;
        var outputPath = innerRenderer.Render(scene, parameters, outputDirectory);
        var elapsed = DateTime.UtcNow - started;

        Console.WriteLine($"[Decorator] Render completed in {elapsed.TotalMilliseconds:0.##} ms. Segments: {scene.Segments.Count}.");
        return outputPath;
    }
}
