using Lab5.Domain.Abstractions;
using Lab5.Domain.Models;

namespace Lab5.Infrastructure.Repositories;

public sealed class InMemoryBookRepository : IReadOnlyBookRepository, IBookInventoryRepository
{
    private readonly List<Book> _books;

    public InMemoryBookRepository(IEnumerable<Book> seed)
    {
        _books = seed.ToList();
    }

    public IReadOnlyCollection<Book> GetAll() => _books;

    public Book? GetById(Guid id) => _books.FirstOrDefault(b => b.Id == id);

    public void Update(Book book)
    {
        // In-memory storage keeps references, method is explicit for abstraction completeness.
    }
}
