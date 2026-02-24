namespace Lab5.Domain.Interfaces;

public interface IAvailabilityService
{
    bool IsAvailable(Guid bookId);
}
