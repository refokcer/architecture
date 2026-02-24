# Lab3 — Вебзастосунок "Калькулятор" (Client-Server)

Цей проєкт демонструє реалізацію калькулятора у вигляді **клієнт-серверного вебзастосунку**:
- **Client**: HTML/CSS/JavaScript інтерфейс у `wwwroot/`.
- **Server**: ASP.NET Core API, який виконує математичні обчислення.

## Структура

- `Controllers/CalculatorController.cs` — HTTP API для обчислень.
- `Services/CalculationService.cs` — бізнес-логіка математичних операцій.
- `Contracts/` — DTO-моделі запиту/відповіді API.
- `Models/OperationType.cs` — перелік підтримуваних операцій.
- `wwwroot/index.html` — графічний інтерфейс калькулятора.
- `wwwroot/js/` — логіка взаємодії з API.
- `wwwroot/css/styles.css` — оформлення інтерфейсу.
- `Documentation/Report.md` — аналітичний звіт згідно завдання.

## Запуск

```bash
dotnet run --project Lab3/Lab3.csproj
```

Після запуску відкрийте у браузері адресу, яку виведе застосунок (наприклад, `http://localhost:5000`).
