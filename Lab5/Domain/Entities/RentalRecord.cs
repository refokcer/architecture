namespace Lab5.Domain.Entities;

public sealed class RentalRecord
{
    public RentalRecord(Guid id, Guid userId, Guid bookId, DateOnly rentedOn, DateOnly dueDate)
    {
        Id = id;
        UserId = userId;
        BookId = bookId;
        RentedOn = rentedOn;
        DueDate = dueDate;
    }

    public Guid Id { get; }
    public Guid UserId { get; }
    public Guid BookId { get; }
    public DateOnly RentedOn { get; }
    public DateOnly DueDate { get; }
}
