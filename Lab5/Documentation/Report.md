# Звіт до лабораторної роботи №5

## Тема
Реалізація системи управління бібліотекою з дотриманням принципів **SOLID**.

## Опис застосунку
Застосунок дозволяє:
1. переглядати список книг та їхню доступність;
2. шукати книги за назвою або автором;
3. орендувати книги;
4. створювати й активувати/деактивувати облікові записи користувачів.

## Де саме в коді реалізовані 5 принципів SOLID

### 1) SRP — Single Responsibility Principle
- `Domain/Models/Book.cs` — тільки стан книги та зміна доступності.
- `Application/Services/RentalService.cs` — тільки сценарій оренди.
- `Application/Services/UserAccountService.cs` — тільки керування користувачами.
- `Presentation/ConsoleUi.cs` — тільки взаємодія з користувачем.

### 2) OCP — Open/Closed Principle
- `Domain/Abstractions/IBookSearchStrategy.cs` + стратегії:
  - `Domain/Strategies/TitleSearchStrategy.cs`,
  - `Domain/Strategies/AuthorSearchStrategy.cs`.
- `Application/Services/BookCatalogService.cs` працює з абстракцією стратегії і не змінюється при додаванні нових типів пошуку.
- `Infrastructure/Repositories/BookSearchStrategyFactory.cs` дозволяє розширювати режими пошуку без змін сервісу каталогу.

### 3) LSP — Liskov Substitution Principle
- `Domain/Models/UserAccount.cs` — базовий тип.
- `StandardUserAccount` і `PremiumUserAccount` підставляються замість `UserAccount` у `UserAccountService` та `RentalService` без поломки логіки.

### 4) ISP — Interface Segregation Principle
- Розбиті вузькі інтерфейси:
  - `IReadOnlyBookRepository` — тільки читання;
  - `IBookInventoryRepository` — тільки оновлення інвентарю;
  - `IUserAccountRepository` — операції з користувачами;
  - `IRentalRepository` — операції з орендою;
  - `IBookSearchStrategyFactory` — вибір стратегії пошуку.

### 5) DIP — Dependency Inversion Principle
- Сервіси в `Application/Services` залежать від абстракцій з `Domain/Abstractions`, а не від конкретних in-memory класів.
- `ConsoleUi` також отримує фабрику пошуку через абстракцію `IBookSearchStrategyFactory`.
- Конкретні реалізації (`InMemory*Repository`, `BookSearchStrategyFactory`) підключаються лише в `Program.cs` (composition root).

## Висновок
У проєкті реалізовано всі 5 принципів SOLID, причому кожен принцип прив’язано до конкретних файлів та ролей у системі.
