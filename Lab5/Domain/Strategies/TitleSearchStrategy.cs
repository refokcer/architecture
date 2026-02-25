using Lab5.Domain.Abstractions;
using Lab5.Domain.Models;

namespace Lab5.Domain.Strategies;

public sealed class TitleSearchStrategy : IBookSearchStrategy
{
    public IReadOnlyCollection<Book> Search(IReadOnlyCollection<Book> source, string query) =>
        source.Where(b => b.Title.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
}
