using Lab5.Domain.Abstractions;
using Lab5.Domain.Models;

namespace Lab5.Infrastructure.Repositories;

public sealed class InMemoryRentalRepository : IRentalRepository
{
    private readonly List<RentalRecord> _rentals = [];

    public IReadOnlyCollection<RentalRecord> GetByUserId(Guid userId) =>
        _rentals.Where(r => r.UserId == userId).ToList();

    public void Add(RentalRecord record) => _rentals.Add(record);
}
