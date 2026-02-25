using Lab5.Domain.Models;

namespace Lab5.Domain.Abstractions;

public interface IBookInventoryRepository
{
    void Update(Book book);
}
