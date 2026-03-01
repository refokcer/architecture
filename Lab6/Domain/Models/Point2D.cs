namespace Lab6.Domain.Models;

public readonly record struct Point2D(double X, double Y)
{
    public static Point2D Mid(Point2D a, Point2D b) => new((a.X + b.X) / 2.0, (a.Y + b.Y) / 2.0);
}
