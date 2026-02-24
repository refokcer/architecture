using Lab5.Domain.Abstractions;
using Lab5.Domain.Models;

namespace Lab5.Domain.Strategies;

public sealed class AuthorSearchStrategy : IBookSearchStrategy
{
    public IReadOnlyCollection<Book> Search(IReadOnlyCollection<Book> source, string query) =>
        source.Where(b => b.Author.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
}
