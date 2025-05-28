# ===== Build stage =====
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Копіюємо всі проєкти в контекст
COPY . .

# Відновлюємо залежності
RUN dotnet restore

# 🔍 Запускаємо тести перед публікацією
RUN dotnet test RealDotNetApp.Tests/RealDotNetApp.Tests.csproj --verbosity normal


# Публікуємо API
RUN dotnet publish RealDotNetApp.Api/RealDotNetApp.csproj \
    --configuration Release \
    --no-restore \
    --output /app

# ===== Runtime stage =====
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Копіюємо зібраний застосунок
COPY --from=build /app .

EXPOSE 80
ENTRYPOINT ["dotnet", "RealDotNetApp.dll"]
