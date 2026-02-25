using Lab5.Domain.Abstractions;
using Lab5.Domain.Strategies;

namespace Lab5.Infrastructure.Repositories;

public sealed class BookSearchStrategyFactory : IBookSearchStrategyFactory
{
    public IBookSearchStrategy Create(string mode)
    {
        return mode.Trim().ToLowerInvariant() switch
        {
            "author" => new AuthorSearchStrategy(),
            _ => new TitleSearchStrategy()
        };
    }
}
