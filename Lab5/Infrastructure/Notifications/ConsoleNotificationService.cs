using Lab5.Domain.Entities;
using Lab5.Domain.Interfaces;

namespace Lab5.Infrastructure.Notifications;

public sealed class ConsoleNotificationService : INotificationService
{
    public void NotifyRentalCreated(LibraryUser user, Book book, DateOnly dueDate)
    {
        Console.WriteLine($"[Notification] {user.Name} rented \"{book.Title}\". Due date: {dueDate:yyyy-MM-dd}");
    }
}
