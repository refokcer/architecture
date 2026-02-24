using Lab5.Domain.Entities;
using Lab5.Domain.Interfaces;

namespace Lab5.Application.Services;

public sealed class BookCatalogService(IBookRepository bookRepository, IRentalRepository rentalRepository)
    : IBookSearchService, IAvailabilityService
{
    public IReadOnlyCollection<Book> Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return [];
        }

        return bookRepository
            .GetAll()
            .Where(book =>
                book.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                book.Author.Contains(query, StringComparison.OrdinalIgnoreCase))
            .ToArray();
    }

    public bool IsAvailable(Guid bookId)
    {
        var book = bookRepository.GetById(bookId);

        if (book is null)
        {
            return false;
        }

        var activeRentals = rentalRepository.GetActiveRentalsCountForBook(bookId);
        return activeRentals < book.TotalCopies;
    }
}
