using Lab5.Domain.Abstractions;
using Lab5.Domain.Models;

namespace Lab5.Application.Services;

public sealed class RentalService(
    IReadOnlyBookRepository readOnlyBooks,
    IBookInventoryRepository inventoryRepository,
    IUserAccountRepository userRepository,
    IRentalRepository rentalRepository)
{
    public string Rent(Guid userId, Guid bookId)
    {
        var user = userRepository.GetById(userId);
        if (user is null || !user.IsActive)
        {
            return "Користувача не знайдено або акаунт неактивний.";
        }

        var currentRentals = rentalRepository.GetByUserId(userId).Count;
        if (currentRentals >= user.MaxRentedBooks)
        {
            return $"Досягнуто ліміт оренди ({user.MaxRentedBooks}).";
        }

        var book = readOnlyBooks.GetById(bookId);
        if (book is null)
        {
            return "Книгу не знайдено.";
        }

        if (!book.TryRent())
        {
            return "Книга недоступна.";
        }

        inventoryRepository.Update(book);
        rentalRepository.Add(new RentalRecord(user.Id, book.Id, DateTime.UtcNow));
        return "Книгу успішно орендовано.";
    }
}
