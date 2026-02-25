namespace Lab5.Domain.Abstractions;

public interface IBookSearchStrategyFactory
{
    IBookSearchStrategy Create(string mode);
}
