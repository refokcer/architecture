using Lab5.Domain.Entities;
using Lab5.Domain.Interfaces;

namespace Lab5.Infrastructure.Repositories;

public sealed class InMemoryBookRepository : IBookRepository
{
    private readonly IReadOnlyCollection<Book> _books =
    [
        new Book(Guid.Parse("00000000-0000-0000-0000-000000000101"), "Clean Code", "Robert C. Martin", 2),
        new Book(Guid.Parse("00000000-0000-0000-0000-000000000102"), "Refactoring", "Martin Fowler", 1),
        new Book(Guid.Parse("00000000-0000-0000-0000-000000000103"), "Design Patterns", "Erich Gamma", 3)
    ];

    public Book? GetById(Guid id) => _books.FirstOrDefault(x => x.Id == id);

    public IReadOnlyCollection<Book> GetAll() => _books;
}
