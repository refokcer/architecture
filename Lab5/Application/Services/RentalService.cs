using Lab5.Domain.Entities;
using Lab5.Domain.Interfaces;

namespace Lab5.Application.Services;

public sealed class RentalService(
    IBookRepository bookRepository,
    IUserRepository userRepository,
    IRentalRepository rentalRepository,
    IAvailabilityService availabilityService,
    IRentalPolicy rentalPolicy,
    INotificationService notificationService)
{
    public RentalRecord RentBook(Guid userId, Guid bookId, DateOnly rentedOn)
    {
        var user = userRepository.GetById(userId)
                   ?? throw new InvalidOperationException("User not found.");

        var book = bookRepository.GetById(bookId)
                   ?? throw new InvalidOperationException("Book not found.");

        if (!availabilityService.IsAvailable(bookId))
        {
            throw new InvalidOperationException("Book is unavailable.");
        }

        var userActiveRentals = rentalRepository.GetActiveRentalsCountForUser(userId);

        if (userActiveRentals >= user.MaxActiveRentals)
        {
            throw new InvalidOperationException("User reached rental limit.");
        }

        var dueDate = rentalPolicy.CalculateDueDate(user, rentedOn);
        var rental = new RentalRecord(Guid.NewGuid(), userId, bookId, rentedOn, dueDate);

        rentalRepository.Add(rental);
        notificationService.NotifyRentalCreated(user, book, dueDate);

        return rental;
    }
}
