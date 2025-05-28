# RealDotNetApp

🚀 **Мінімальний .NET 9 Web API додаток з архітектурою по шарах**

## ✅ Що реалізовано:
- Minimal API (.NET 9)
- EF Core (InMemory)
- JWT авторизація
- Swagger документація
- Serilog логування
- Clean Architecture: Application, Domain, Infrastructure


# RealDotNetApp (.NET 9 API Demo)

This is a layered architecture demo of a real-world .NET 9 application with:
- Clean architecture (Domain, Application, Infrastructure)
- Swagger API documentation
- JWT authentication
- Docker support
- GitHub Actions CI/CD

## 🔧 Getting Started

### Requirements
- [.NET 9 SDK](https://dotnet.microsoft.com)
- [Docker](https://www.docker.com)
- Git

---

## 🚀 Run Locally

```bash
git clone https://github.com/your-org/RealDotNetApp.git
cd RealDotNetApp
dotnet run --project RealDotNetApp
```

Browse to: `http://localhost:5000/swagger`

---

## 🧪 Run Tests

```bash
dotnet test
```

---

## 🐳 Docker Support

### Build and Run Docker container

```bash
docker build -t realdotnetapp .
docker run -d -p 8080:80 --name realdotnetapp realdotnetapp
```

---

## ⚙️ GitHub Actions

CI/CD workflows:
- `.github/workflows/dotnet-ci.yml` — builds and tests the API
- `.github/workflows/docker-build.yml` — builds and runs the Docker container

---

## 📁 Project Structure

```
RealDotNetApp/
├── Program.cs
├── Domain/
├── Application/
├── Infrastructure/
├── RealDotNetApp.Tests/
└── Dockerfile
```

---

## 🔐 Authentication

Uses JWT with hardcoded secret for demonstration:

```
supersecretkey1234
```

---

## 📝 Swagger

Swagger is enabled at:

```
/swagger/index.html
```

XML documentation is enabled in the project settings.

---

## 👨‍💻 Author

Built for educational demo purposes by Taras Smirnov.

---

MIT License
