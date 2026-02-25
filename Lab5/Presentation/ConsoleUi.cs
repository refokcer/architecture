using Lab5.Application.Services;
using Lab5.Domain.Abstractions;

namespace Lab5.Presentation;

public sealed class ConsoleUi(
    BookCatalogService bookCatalogService,
    UserAccountService userAccountService,
    RentalService rentalService,
    IBookSearchStrategyFactory searchStrategyFactory)
{
    public void Run()
    {
        while (true)
        {
            PrintMenu();
            var command = Console.ReadLine();

            switch (command)
            {
                case "1": ShowBooks(); break;
                case "2": SearchBooks(); break;
                case "3": RentBook(); break;
                case "4": ShowUsers(); break;
                case "5": CreateUser(); break;
                case "6": SetUserActive(false); break;
                case "7": SetUserActive(true); break;
                case "0": return;
                default: Console.WriteLine("Невідома команда."); break;
            }

            Console.WriteLine();
        }
    }

    private void PrintMenu()
    {
        Console.WriteLine("=== Lab5: Система управління бібліотекою ===");
        Console.WriteLine("1. Показати всі книги");
        Console.WriteLine("2. Пошук книги");
        Console.WriteLine("3. Орендувати книгу");
        Console.WriteLine("4. Показати користувачів");
        Console.WriteLine("5. Створити користувача");
        Console.WriteLine("6. Деактивувати користувача");
        Console.WriteLine("7. Активувати користувача");
        Console.WriteLine("0. Вихід");
        Console.Write("Оберіть команду: ");
    }

    private void ShowBooks()
    {
        foreach (var book in bookCatalogService.GetAll())
        {
            Console.WriteLine($"{book.Id} | {book.Title} — {book.Author} | Доступно: {book.CopiesAvailable}/{book.CopiesTotal}");
        }
    }

    private void SearchBooks()
    {
        Console.Write("Введіть запит: ");
        var query = Console.ReadLine() ?? string.Empty;

        Console.Write("Шукати за (title/author): ");
        var mode = Console.ReadLine();

        var strategy = searchStrategyFactory.Create(mode ?? string.Empty);

        var result = bookCatalogService.Search(query, strategy);
        if (result.Count == 0)
        {
            Console.WriteLine("Нічого не знайдено.");
            return;
        }

        foreach (var book in result)
        {
            Console.WriteLine($"{book.Id} | {book.Title} — {book.Author}");
        }
    }

    private void RentBook()
    {
        var userId = ReadGuid("Введіть ID користувача: ");
        var bookId = ReadGuid("Введіть ID книги: ");
        Console.WriteLine(rentalService.Rent(userId, bookId));
    }

    private void ShowUsers()
    {
        foreach (var user in userAccountService.GetAll())
        {
            Console.WriteLine($"{user.Id} | {user.Name} | Active: {user.IsActive} | Limit: {user.MaxRentedBooks}");
        }
    }

    private void CreateUser()
    {
        Console.Write("Ім'я: ");
        var name = Console.ReadLine() ?? "Unknown";
        Console.Write("Premium? (y/n): ");
        var premium = (Console.ReadLine() ?? "n").Trim().ToLowerInvariant() == "y";

        var created = userAccountService.Create(name, premium);
        Console.WriteLine($"Створено користувача: {created.Id}");
    }

    private void SetUserActive(bool isActive)
    {
        var userId = ReadGuid("Введіть ID користувача: ");
        var changed = userAccountService.SetActive(userId, isActive);
        Console.WriteLine(changed ? "Статус оновлено." : "Користувача не знайдено.");
    }

    private static Guid ReadGuid(string label)
    {
        while (true)
        {
            Console.Write(label);
            var value = Console.ReadLine();
            if (Guid.TryParse(value, out var id))
            {
                return id;
            }

            Console.WriteLine("Невірний формат GUID. Спробуйте ще раз.");
        }
    }
}
