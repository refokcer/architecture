using Lab6.Domain.Models;

namespace Lab6.Domain.Abstractions;

public interface ISceneRenderer
{
    string Render(FractalScene scene, FractalParameters parameters, string outputDirectory);
}
