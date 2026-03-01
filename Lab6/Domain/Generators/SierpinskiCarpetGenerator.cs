using Lab6.Domain.Abstractions;
using Lab6.Domain.Models;

namespace Lab6.Domain.Generators;

public sealed class SierpinskiCarpetGenerator : IFractalGenerator
{
    public FractalScene Generate(FractalParameters parameters)
    {
        var scene = new FractalScene(parameters.CanvasSize, parameters.CanvasSize, parameters.BackgroundColor);
        var margin = parameters.CanvasSize * 0.05;
        var side = parameters.CanvasSize - margin * 2;

        Build(scene.Segments, margin, margin, side, parameters.Iterations);
        return scene;
    }

    private static void Build(List<LineSegment> segments, double x, double y, double size, int depth)
    {
        if (depth == 0)
        {
            AddSquare(segments, x, y, size);
            return;
        }

        var child = size / 3.0;
        for (var row = 0; row < 3; row++)
        {
            for (var col = 0; col < 3; col++)
            {
                if (row == 1 && col == 1)
                {
                    continue;
                }

                Build(segments, x + col * child, y + row * child, child, depth - 1);
            }
        }
    }

    private static void AddSquare(List<LineSegment> segments, double x, double y, double size)
    {
        var topLeft = new Point2D(x, y);
        var topRight = new Point2D(x + size, y);
        var bottomRight = new Point2D(x + size, y + size);
        var bottomLeft = new Point2D(x, y + size);

        segments.Add(new LineSegment(topLeft, topRight));
        segments.Add(new LineSegment(topRight, bottomRight));
        segments.Add(new LineSegment(bottomRight, bottomLeft));
        segments.Add(new LineSegment(bottomLeft, topLeft));
    }
}
