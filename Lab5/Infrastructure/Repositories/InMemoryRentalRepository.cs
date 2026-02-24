using Lab5.Domain.Entities;
using Lab5.Domain.Interfaces;

namespace Lab5.Infrastructure.Repositories;

public sealed class InMemoryRentalRepository : IRentalRepository
{
    private readonly List<RentalRecord> _rentals = [];

    public int GetActiveRentalsCountForUser(Guid userId) => _rentals.Count(x => x.UserId == userId);

    public int GetActiveRentalsCountForBook(Guid bookId) => _rentals.Count(x => x.BookId == bookId);

    public void Add(RentalRecord rentalRecord) => _rentals.Add(rentalRecord);
}
