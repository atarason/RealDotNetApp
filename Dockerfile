# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy everything
COPY . .

# OPTIONAL: Restore packages (if needed)
RUN dotnet restore

# ✅ Run unit tests (вважаємо, що тести в проєкті RealDotNetApp.Tests)
RUN dotnet test RealDotNetApp.Tests/RealDotNetApp.Tests.csproj --no-build --verbosity normal

# Publish the API project
RUN dotnet publish RealDotNetApp.Api/RealDotNetApp.csproj --configuration Release --no-restore --output /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
ENTRYPOINT ["dotnet", "RealDotNetApp.dll"]
