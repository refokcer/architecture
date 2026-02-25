using Lab5.Application.Services;
using Lab5.Domain.Models;
using Lab5.Infrastructure.Repositories;
using Lab5.Presentation;

var bookRepository = new InMemoryBookRepository(
[
    new Book(Guid.NewGuid(), "Clean Code", "Robert C. Martin", 5, 5),
    new Book(Guid.NewGuid(), "Design Patterns", "Erich Gamma", 4, 3),
    new Book(Guid.NewGuid(), "Refactoring", "Martin Fowler", 2, 2)
]);

var userRepository = new InMemoryUserAccountRepository(
[
    new StandardUserAccount(Guid.NewGuid(), "Іван"),
    new PremiumUserAccount(Guid.NewGuid(), "Олена")
]);

var rentalRepository = new InMemoryRentalRepository();
var searchStrategyFactory = new BookSearchStrategyFactory();

var bookCatalogService = new BookCatalogService(bookRepository);
var userAccountService = new UserAccountService(userRepository);
var rentalService = new RentalService(bookRepository, bookRepository, userRepository, rentalRepository);

var ui = new ConsoleUi(bookCatalogService, userAccountService, rentalService, searchStrategyFactory);
ui.Run();
