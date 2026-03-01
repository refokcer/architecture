using System.Globalization;
using System.Text;
using Lab6.Domain.Abstractions;
using Lab6.Domain.Models;

namespace Lab6.Infrastructure.Rendering;

public sealed class SvgRenderer : ISceneRenderer
{
    public string Render(FractalScene scene, FractalParameters parameters, string outputDirectory)
    {
        Directory.CreateDirectory(outputDirectory);
        var fileName = $"{parameters.Type}_it{parameters.Iterations}_{DateTime.Now:yyyyMMdd_HHmmss}.svg";
        var fullPath = Path.Combine(outputDirectory, fileName);

        var sb = new StringBuilder();
        sb.AppendLine($"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{scene.Width}\" height=\"{scene.Height}\" viewBox=\"0 0 {scene.Width} {scene.Height}\">");
        sb.AppendLine($"  <rect width=\"100%\" height=\"100%\" fill=\"{scene.BackgroundColor}\" />");

        foreach (var segment in scene.Segments)
        {
            sb.AppendLine(
                $"  <line x1=\"{ToInvariant(segment.Start.X)}\" y1=\"{ToInvariant(segment.Start.Y)}\" x2=\"{ToInvariant(segment.End.X)}\" y2=\"{ToInvariant(segment.End.Y)}\" stroke=\"{parameters.StrokeColor}\" stroke-width=\"{ToInvariant(parameters.StrokeWidth)}\" stroke-linecap=\"round\" />");
        }

        sb.AppendLine("</svg>");
        File.WriteAllText(fullPath, sb.ToString());

        return fullPath;
    }

    private static string ToInvariant(double value) => value.ToString("0.###", CultureInfo.InvariantCulture);
}
