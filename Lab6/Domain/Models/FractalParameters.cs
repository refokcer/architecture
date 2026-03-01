namespace Lab6.Domain.Models;

public sealed record FractalParameters(
    FractalType Type,
    int Iterations,
    int CanvasSize,
    string StrokeColor,
    string BackgroundColor,
    double StrokeWidth);
