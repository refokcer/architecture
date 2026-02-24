using Lab5.Domain.Models;

namespace Lab5.Domain.Abstractions;

public interface IBookSearchStrategy
{
    IReadOnlyCollection<Book> Search(IReadOnlyCollection<Book> source, string query);
}
