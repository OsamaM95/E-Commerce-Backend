# ECommerce.API

A robust and modern e-commerce RESTful API built with **ASP.NET Core 10.0**, utilizing **Entity Framework Core**, the **Repository Pattern**, and structured exception handling.

---

## 🚀 Features

- **.NET 10 Web API**: Built on the latest ASP.NET Core platform.
- **Entity Framework Core 10**: Code-First approach targeting Microsoft SQL Server.
- **Automated Database Migration & Seeding**: Applies pending database migrations and seeds initial sample products automatically on application startup.
- **Repository Pattern**: Clean separation of data access concerns (`IProductRepository`).
- **Global Error Handling Middleware**: Custom `ExceptionMiddleware` producing standardized `ApiException` responses with development stack-trace support.
- **OpenAPI Integration**: Built-in endpoint documentation with ASP.NET Core OpenAPI (`/openapi/v1.json`).
- **Container Ready**: Production-ready multi-stage [Dockerfile](file:///d:/Projects/Backend%20Projects/ECommerce.API/ECommerce.API/Dockerfile).

---

## 🛠️ Tech Stack

- **Platform**: [.NET 10.0](https://dotnet.microsoft.com/)
- **Language**: C# 13+
- **ORM**: Entity Framework Core 10.0 (SQL Server provider)
- **Database**: Microsoft SQL Server / LocalDB / Express
- **Containerization**: Docker (Linux containers)
- **API Documentation**: Microsoft.AspNetCore.OpenApi

---

## 📂 Project Structure

```text
ECommerce.API/
├── Controllers/              # API Controllers
│   ├── ProductsController.cs         # Product catalog endpoints
│   └── WeatherForecastController.cs  # Template/diagnostic endpoint
├── Data/                     # Database context & migrations/seeding
│   ├── StoreContext.cs               # EF Core DbContext
│   └── StoreContextSeed.cs           # Initial sample data seeder
├── DT0s/                     # Data Transfer Objects
│   ├── ProductCreateDto.cs           # Validation & payload for product creation
│   └── ProductToReturnDto.cs         # Output projection DTO
├── Entities/                 # Core domain models
│   └── Product.cs                    # Product domain entity
├── Errors/                   # Standardized error representations
│   └── ApiException.cs               # API error response model
├── Interfaces/               # Contracts and abstractions
│   └── IProductRepository.cs         # Repository interfaces
├── Middleware/               # HTTP pipeline middleware
│   └── ExceptionMiddleware.cs        # Global unhandled exception handler
├── Migrations/               # EF Core database migrations
├── Repositories/             # Concrete data access implementations
│   └── ProductRepository.cs          # EF Core repository implementation
├── Dockerfile                # Multi-stage Docker container build definition
├── Program.cs                # Application bootstrap & dependency injection
└── appsettings.json          # Configuration & database connection strings
```

---

## ⚙️ Getting Started

### Prerequisites

Ensure you have installed:
- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Microsoft SQL Server](https://www.microsoft.com/sql-server/) (or SQL Server Express / LocalDB / Docker container)
- Optional: [Docker Desktop](https://www.docker.com/products/docker-desktop/) (for containerized deployment)

### 1. Database Configuration

Update the connection string in [appsettings.json](file:///d:/Projects/Backend%20Projects/ECommerce.API/ECommerce.API/appsettings.json) to match your local SQL Server instance:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.\\SQLEXPRESS;Database=ECommerceDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}
```

> **Note**: On startup, the application runs `context.Database.MigrateAsync()` and seeds starter products automatically.

### 2. Run Locally

Navigate to the project folder and start the API:

```powershell
cd ECommerce.API
dotnet restore
dotnet run
```

The application will be accessible at:
- HTTP: `http://localhost:5000` (or designated port in `launchSettings.json`)
- HTTPS: `https://localhost:7001`
- OpenAPI Specification: `https://localhost:7001/openapi/v1.json`

---

## 🐳 Running with Docker

You can build and run the API using Docker:

### Build Image
```bash
docker build -t ecommerce-api -f ECommerce.API/Dockerfile .
```

### Run Container
```bash
docker run -d -p 8080:8080 -e "ConnectionStrings__DefaultConnection=Server=host.docker.internal;Database=ECommerceDb;User Id=sa;Password=YourPassword123!;TrustServerCertificate=True" --name ecommerce-api ecommerce-api
```

---

## 📡 API Endpoints

### Products

| Method | Endpoint | Description |
| :--- | :--- | :--- |
| `GET` | `/api/products` | Retrieve list of all products |

#### Example Response (`GET /api/products`):
```json
[
  {
    "id": 1,
    "name": "iPhone 15",
    "description": "Apple Smartphone",
    "price": 999.00
  },
  {
    "id": 2,
    "name": "MacBook Pro",
    "description": "Apple Laptop M3",
    "price": 1999.00
  },
  {
    "id": 3,
    "name": "AirPods Pro",
    "description": "Noise Canceling Earbuds",
    "price": 249.00
  }
]
```

---

## 🛡️ Error Handling

Unhandled exceptions are intercepted by `ExceptionMiddleware` and returned as a unified structure:

```json
{
  "statusCode": 500,
  "message": "Internal Server Error",
  "details": "Stack trace (included in Development mode only)"
}
```

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).
