# CampusLibrary - Claude Code Instructions

## Project Overview

CampusLibrary is a library book management system created using
ASP.NET Core MVC, .NET 10, Entity Framework Core, and SQL Server LocalDB.

The project follows the Service-Repository Pattern.

## Project Structure

- src/CampusLibrary.Domain - Book entity and interfaces
- src/CampusLibrary.Application - Business logic and BookService
- src/CampusLibrary.Infrastructure - Repository, DbContext, and migrations
- src/CampusLibrary.Web - MVC controllers, Razor views, REST API, and UI
- android/ - Android Kotlin client
- docs/reports/ - Development documentation

## Coding Guidelines

- Keep Domain independent of Infrastructure.
- Use dependency injection.
- Use asynchronous database operations.
- Keep business logic in the service layer.
- Keep database operations in the repository layer.
- Validate book information before saving.
- Do not put passwords or API keys in source code.
- Do not delete existing data or migrations without permission.
- Build and test changes before reporting success.

## Build

Run from the repository root:

dotnet build CampusLibrary.sln

## Database

dotnet ef database update --project src/CampusLibrary.Infrastructure --startup-project src/CampusLibrary.Web

## Run Web Application

dotnet run --project src/CampusLibrary.Web

## REST API

GET /api/books
GET /api/books/{id}
POST /api/books
PUT /api/books/{id}
DELETE /api/books/{id}

## Current Notes

The MVC application and GET /api/books have been manually tested.
Other API methods and the Android application require separate verification.
