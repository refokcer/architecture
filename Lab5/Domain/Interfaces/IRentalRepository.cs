using Lab5.Domain.Entities;

namespace Lab5.Domain.Interfaces;

public interface IRentalRepository
{
    int GetActiveRentalsCountForUser(Guid userId);
    int GetActiveRentalsCountForBook(Guid bookId);
    void Add(RentalRecord rentalRecord);
}
