using Lab5.Domain.Entities;

namespace Lab5.Domain.Interfaces;

public interface IRentalPolicy
{
    DateOnly CalculateDueDate(LibraryUser user, DateOnly rentedOn);
}
