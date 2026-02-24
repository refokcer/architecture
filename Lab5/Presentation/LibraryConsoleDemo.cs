using Lab5.Application.Services;
using Lab5.Domain.Interfaces;
using Lab5.Infrastructure.Notifications;
using Lab5.Infrastructure.Repositories;

namespace Lab5.Presentation;

public static class LibraryConsoleDemo
{
    public static void Run()
    {
        IBookRepository bookRepository = new InMemoryBookRepository();
        IUserRepository userRepository = new InMemoryUserRepository();
        IRentalRepository rentalRepository = new InMemoryRentalRepository();
        INotificationService notificationService = new ConsoleNotificationService();
        IRentalPolicy rentalPolicy = new DefaultRentalPolicy();

        IAvailabilityService availabilityService = new BookCatalogService(bookRepository, rentalRepository);
        IBookSearchService searchService = (IBookSearchService)availabilityService;

        var rentalService = new RentalService(
            bookRepository,
            userRepository,
            rentalRepository,
            availabilityService,
            rentalPolicy,
            notificationService);

        Console.WriteLine("=== Library Management (SOLID Demo) ===");
        Console.WriteLine("Search result for 'Clean':");

        foreach (var book in searchService.Search("Clean"))
        {
            Console.WriteLine($"- {book.Title} by {book.Author}");
        }

        var userId = Guid.Parse("00000000-0000-0000-0000-000000000201");
        var bookId = Guid.Parse("00000000-0000-0000-0000-000000000101");

        var rental = rentalService.RentBook(userId, bookId, DateOnly.FromDateTime(DateTime.Today));
        Console.WriteLine($"Rental created: {rental.Id}");
    }
}
