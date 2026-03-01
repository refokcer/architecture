using Lab6.Domain.Abstractions;
using Lab6.Domain.Models;

namespace Lab6.Domain.Generators;

public sealed class KochSnowflakeGenerator : IFractalGenerator
{
    public FractalScene Generate(FractalParameters parameters)
    {
        var scene = new FractalScene(parameters.CanvasSize, parameters.CanvasSize, parameters.BackgroundColor);

        var margin = parameters.CanvasSize * 0.12;
        var bottomLeft = new Point2D(margin, parameters.CanvasSize - margin);
        var bottomRight = new Point2D(parameters.CanvasSize - margin, parameters.CanvasSize - margin);
        var side = bottomRight.X - bottomLeft.X;
        var height = side * Math.Sqrt(3) / 2.0;
        var top = new Point2D(parameters.CanvasSize / 2.0, parameters.CanvasSize - margin - height);

        Build(scene.Segments, bottomLeft, bottomRight, parameters.Iterations);
        Build(scene.Segments, bottomRight, top, parameters.Iterations);
        Build(scene.Segments, top, bottomLeft, parameters.Iterations);

        return scene;
    }

    private static void Build(List<LineSegment> segments, Point2D start, Point2D end, int depth)
    {
        if (depth == 0)
        {
            segments.Add(new LineSegment(start, end));
            return;
        }

        var dx = end.X - start.X;
        var dy = end.Y - start.Y;

        var p1 = new Point2D(start.X + dx / 3.0, start.Y + dy / 3.0);
        var p3 = new Point2D(start.X + 2 * dx / 3.0, start.Y + 2 * dy / 3.0);

        var angle = Math.PI / 3.0;
        var peak = new Point2D(
            p1.X + (dx / 3.0) * Math.Cos(angle) - (dy / 3.0) * Math.Sin(angle),
            p1.Y + (dx / 3.0) * Math.Sin(angle) + (dy / 3.0) * Math.Cos(angle));

        Build(segments, start, p1, depth - 1);
        Build(segments, p1, peak, depth - 1);
        Build(segments, peak, p3, depth - 1);
        Build(segments, p3, end, depth - 1);
    }
}
