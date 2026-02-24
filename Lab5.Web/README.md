# Lab5.Web — Library Management з фронтендом

Це перероблена Lab5 з **UI (frontend)**, яка запускається без `dotnet`.

## Запуск

Варіант 1: просто відкрийте `index.html` у браузері.

Варіант 2 (рекомендовано): локальний HTTP сервер.

```bash
cd Lab5.Web
python3 -m http.server 5500
```

Потім відкрийте: `http://localhost:5500`.

---

## SOLID у проєкті

1. **SRP**
   - `BookCatalogService` тільки пошук/доступність.
   - `RentalService` тільки сценарій оренди.
   - `LibraryUiController` тільки робота з UI.

2. **OCP**
   - Політика строку оренди винесена в `DefaultRentalPolicy` (можна додати нові політики без змін `RentalService`).

3. **LSP**
   - `StandardUser` і `PremiumUser` підставляються замість базового `LibraryUser`.

4. **ISP**
   - Контракти розділені на вузькі інтерфейси: `IBookRepository`, `IUserRepository`, `IRentalRepository`, `INotificationService`, `IRentalPolicy`.

5. **DIP**
   - `RentalService` залежить від абстракцій (репозиторії, policy, notification), а не конкретних реалізацій.
