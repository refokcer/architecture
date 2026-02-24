using Lab5.Domain.Entities;

namespace Lab5.Domain.Interfaces;

public interface INotificationService
{
    void NotifyRentalCreated(LibraryUser user, Book book, DateOnly dueDate);
}
