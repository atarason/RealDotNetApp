# RealDotNetApp

🚀 **Мінімальний .NET 9 Web API додаток з архітектурою по шарах**

## ✅ Що реалізовано:
- Minimal API (.NET 9)
- EF Core (InMemory)
- JWT авторизація
- Swagger документація
- Serilog логування
- Clean Architecture: Application, Domain, Infrastructure

## ▶️ Як запустити
```bash
dotnet run --project Api/RealDotNetApp.csproj
```

## 📦 Структура
- `Api/` — точка входу (`Program.cs`)
- `Application/` — сервіси, інтерфейси
- `Domain/` — моделі, DTO
- `Infrastructure/` — EF Core, репозиторії
