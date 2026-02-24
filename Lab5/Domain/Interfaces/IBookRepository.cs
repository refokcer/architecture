using Lab5.Domain.Entities;

namespace Lab5.Domain.Interfaces;

public interface IBookRepository
{
    Book? GetById(Guid id);
    IReadOnlyCollection<Book> GetAll();
}
