using Lab5.Domain.Models;

namespace Lab5.Domain.Abstractions;

public interface IRentalRepository
{
    IReadOnlyCollection<RentalRecord> GetByUserId(Guid userId);
    void Add(RentalRecord record);
}
