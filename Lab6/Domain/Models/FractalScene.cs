namespace Lab6.Domain.Models;

public sealed class FractalScene
{
    public FractalScene(int width, int height, string backgroundColor)
    {
        Width = width;
        Height = height;
        BackgroundColor = backgroundColor;
    }

    public int Width { get; }
    public int Height { get; }
    public string BackgroundColor { get; }
    public List<LineSegment> Segments { get; } = [];
}
