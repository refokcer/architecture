# Lab4

Три еквівалентні версії застосунку для обчислення **суми квадратів натуральних чисел**, які є:
- простими, або
- досконалими.

Користувач вводить верхню межу з клавіатури.

## Структура

- `structural-cpp/` — структурне програмування (C++ без ООП)
- `oop-csharp/` — об'єктно-орієнтоване програмування (C#)
- `functional-haskell/` — функціональне програмування (Haskell)

## Швидкий запуск

### 1) C++
```bash
cd structural-cpp
g++ -std=c++17 src/main.cpp src/number_utils.cpp -o lab4_struct
./lab4_struct
```

### 2) C#
```bash
cd oop-csharp
dotnet run --project Lab4.OopApp/Lab4.OopApp.csproj
```

### 3) Haskell
```bash
cd functional-haskell
cabal run
```
