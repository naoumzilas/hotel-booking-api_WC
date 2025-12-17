# Hotel Booking API

A simple Hotel Room Booking API built with **ASP.NET Core (.NET 8)** and **Entity Framework Core**, following clean architecture principles.

This project was completed as a technical assessment and focuses on clarity, maintainability, and testability rather than exhaustive feature completeness.

---

## Architecture Overview

The solution follows a layered architecture inspired by **DDD / Clean Architecture**:

HotelBooking.Api → HTTP / Swagger / Controllers
HotelBooking.Application → Application services, workflows, requests & responses
HotelBooking.Domain → Core domain entities, value objects, business rules
HotelBooking.Infrastructure → EF Core, database access, repository implementations
HotelBooking.Tests → Minimal unit tests for application logic

Key principles:
- Controllers are thin and delegate all logic to Application services
- Application layer owns business workflows
- Domain contains business rules and invariants
- Infrastructure is responsible only for persistence concerns

---

## Running the API

### Prerequisites
- .NET 8 SDK
- No external database required (SQLite is used)

### Run the API
dotnet run --project HotelBooking.Api

Swagger will be available at: https://localhost:7142/swagger/index.html

###Seeding & Testing

For testing purposes, the API exposes admin endpoints:

POST /api/admin/reset — Clears all data

POST /api/admin/seed — Seeds deterministic test data:

1 hotel

Exactly 6 rooms (Single, Double, Deluxe)

This allows reviewers to test the API immediately without setup.

### Postman Collection
A minimal Postman collection is included to demonstrate the full workflow:

Reset database

Seed database

Find hotel by name

Search availability

Create booking

Retrieve booking by reference

Location: /postman/HotelBooking.postman_collection.json

## Testing
A minimal unit test project is included to demonstrate:

Application-level testing

Isolation of business logic

Use of mocks instead of infrastructure dependencies

The test suite is intentionally small given the scope of the assessment.