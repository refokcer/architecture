using Lab5.Domain.Entities;
using Lab5.Domain.Interfaces;

namespace Lab5.Application.Services;

public sealed class DefaultRentalPolicy : IRentalPolicy
{
    public DateOnly CalculateDueDate(LibraryUser user, DateOnly rentedOn)
    {
        var days = user switch
        {
            PremiumUser => 21,
            _ => 14
        };

        return rentedOn.AddDays(days);
    }
}
