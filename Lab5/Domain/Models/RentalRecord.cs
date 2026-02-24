namespace Lab5.Domain.Models;

public sealed record RentalRecord(Guid UserId, Guid BookId, DateTime RentedAtUtc);
