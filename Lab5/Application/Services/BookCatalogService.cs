using Lab5.Domain.Abstractions;
using Lab5.Domain.Models;

namespace Lab5.Application.Services;

public sealed class BookCatalogService(IReadOnlyBookRepository bookRepository)
{
    public IReadOnlyCollection<Book> GetAll() => bookRepository.GetAll();

    public IReadOnlyCollection<Book> Search(string query, IBookSearchStrategy strategy) =>
        strategy.Search(bookRepository.GetAll(), query);
}
