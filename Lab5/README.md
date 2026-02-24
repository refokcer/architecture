# Lab5 — Система управління бібліотекою (SOLID)

Цей застосунок демонструє систему управління бібліотекою, у якій реалізовані всі п'ять принципів SOLID.

## Структура проєкту

- `Domain/Entities` — сутності предметної області (`Book`, `LibraryUser`, `RentalRecord`).
- `Domain/Interfaces` — контракти (абстракції), від яких залежить бізнес-логіка.
- `Application/Services` — прикладні сервіси з бізнес-правилами (`BookCatalogService`, `RentalService`, `DefaultRentalPolicy`).
- `Infrastructure/*` — інфраструктурні реалізації (in-memory репозиторії, сповіщення в консоль).
- `Presentation` — запуск демонстраційного сценарію в консолі.

## Де і як реалізовано SOLID

### 1) SRP — Single Responsibility Principle

- `BookCatalogService` відповідає лише за пошук книг і перевірку доступності.
- `RentalService` відповідає лише за сценарій видачі книги.
- `ConsoleNotificationService` відповідає тільки за відправку повідомлень у консоль.

Кожен клас має одну чітку відповідальність і одну причину для змін.

### 2) OCP — Open/Closed Principle

- Логіка строку оренди винесена в `IRentalPolicy`.
- Реалізація `DefaultRentalPolicy` може бути замінена або розширена (наприклад, `HolidayRentalPolicy`, `StudentRentalPolicy`) **без змін** у `RentalService`.

Тобто система відкрита для розширення через нові реалізації інтерфейсів та закрита для модифікацій існуючого коду сервісу видачі.

### 3) LSP — Liskov Substitution Principle

- `LibraryUser` є базовим типом.
- `StandardUser` і `PremiumUser` можуть взаємозамінюватися у коді, що працює з `LibraryUser` (наприклад, у `RentalService` при перевірці `MaxActiveRentals`).

Підтипи не ламають очікувану поведінку базового типу.

### 4) ISP — Interface Segregation Principle

- Замість великого «універсального» інтерфейсу розділено контракти:
  - `IBookSearchService` — тільки пошук.
  - `IAvailabilityService` — тільки перевірка доступності.
  - окремо репозиторні інтерфейси та політика оренди.

Клієнти залежать лише від тих методів, які реально використовують.

### 5) DIP — Dependency Inversion Principle

- `RentalService` залежить від абстракцій: `IBookRepository`, `IUserRepository`, `IRentalRepository`, `IAvailabilityService`, `IRentalPolicy`, `INotificationService`.
- Конкретні реалізації (`InMemory*`, `ConsoleNotificationService`) підставляються на етапі композиції (`LibraryConsoleDemo`).

Модуль високого рівня (`RentalService`) не залежить від деталей зберігання чи способу сповіщення.

## Запуск

```bash
dotnet run --project Lab5/Lab5.csproj
```
