## About This Project

CarShop is a backend REST API for managing a car dealership's
inventory. It's a personal project I'm building to practice
production-style ASP.NET Core architecture and patterns.

Currently implemented: full CRUD for the car inventory (create,
list, update, delete). Dealerships, customers, and orders are
planned next.

### Architecture

The solution follows a layered architecture with a clear dependency
direction — outer layers depend on inner layers, never the reverse:

- **CarShop.Core** — domain entities and interfaces, no external
  dependencies
- **CarShop.BusinessLogic** — application services
- **CarShop.DataAccess** — EF Core `DbContext`, entity configurations,
  repositories, PostgreSQL
- **CarShop.API** — controllers, request/response contracts, DI
  composition root, Swagger

### Tech Stack

- **ASP.NET Core Web API**
- **PostgreSQL** via **Entity Framework Core**
- **Docker / Docker Compose** — containerized PostgreSQL
- **Swagger / OpenAPI** — interactive API documentation
- **Dependency Injection** — constructor-based, throughout

### Running Locally

\`\`\`bash
docker compose up -d
dotnet ef database update     # after your first migration exists
dotnet run --project CarShop.API
\`\`\`

Swagger UI is available at the API root once running.

### Notes

Car identifiers currently use `Guid` rather than the real VIN format
(17-character alphanumeric) — a simplification for now, may be
revisited as the domain model grows.
