using Lab6.Domain.Abstractions;
using Lab6.Domain.Models;

namespace Lab6.Domain.Generators;

public sealed class SierpinskiTriangleGenerator : IFractalGenerator
{
    public FractalScene Generate(FractalParameters parameters)
    {
        var scene = new FractalScene(parameters.CanvasSize, parameters.CanvasSize, parameters.BackgroundColor);

        var margin = parameters.CanvasSize * 0.06;
        var top = new Point2D(parameters.CanvasSize / 2.0, margin);
        var left = new Point2D(margin, parameters.CanvasSize - margin);
        var right = new Point2D(parameters.CanvasSize - margin, parameters.CanvasSize - margin);

        Build(scene.Segments, top, left, right, parameters.Iterations);
        return scene;
    }

    private static void Build(List<LineSegment> segments, Point2D a, Point2D b, Point2D c, int depth)
    {
        if (depth == 0)
        {
            segments.Add(new LineSegment(a, b));
            segments.Add(new LineSegment(b, c));
            segments.Add(new LineSegment(c, a));
            return;
        }

        var ab = Point2D.Mid(a, b);
        var bc = Point2D.Mid(b, c);
        var ca = Point2D.Mid(c, a);

        Build(segments, a, ab, ca, depth - 1);
        Build(segments, ab, b, bc, depth - 1);
        Build(segments, ca, bc, c, depth - 1);
    }
}
