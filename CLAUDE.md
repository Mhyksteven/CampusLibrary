# CampusLibrary — Claude Code Project Instructions

## Project Overview

CampusLibrary is an ASP.NET Core MVC library management system built with .NET 10, Entity Framework Core, and SQL Server LocalDB.

The project uses the Service–Repository Pattern to organize the code and separate business logic from database operations.

## Project Structure

- `src/CampusLibrary.Domain` — Book entity and interfaces
- `src/CampusLibrary.Application` — Book service and business logic
- `src/CampusLibrary.Infrastructure` — Book repository, EF Core context, and migrations
- `src/CampusLibrary.Web` — MVC controllers, Razor views, REST API, and UI

## Development Guidelines

- Keep the Domain project independent of database-specific code.
- Use dependency injection for repositories and services.
- Use async methods for database operations.
- Follow the existing Service–Repository Pattern.
- Reuse the existing Book entity and database context.
- Avoid unnecessary dependencies.
- Do not store API keys or passwords in source files.

## Build and Run

To build:

`dotnet build CampusLibrary.sln`

To apply database migrations:

`dotnet ef database update --project src/CampusLibrary.Infrastructure --startup-project src/CampusLibrary.Web`

To run the application:

`dotnet run --project src/CampusLibrary.Web`

## REST API

The web application includes book management API endpoints under `/api/books`.

## Project Goal

Maintain a working library management system that supports adding, viewing, editing, and deleting book records.