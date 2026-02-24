using Lab5.Domain.Models;

namespace Lab5.Domain.Abstractions;

public interface IReadOnlyBookRepository
{
    IReadOnlyCollection<Book> GetAll();
    Book? GetById(Guid id);
}
