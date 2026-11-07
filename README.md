# CampusLibrary — Library Management System

## Project Overview

CampusLibrary is a web-based library book management system built using ASP.NET Core MVC and C#.

The system demonstrates the Service–Repository Pattern, Entity Framework Core database access, and REST API development.

It provides a professional dashboard interface for managing the campus library's book collection.

## Technologies Used

- C# and .NET 10
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server Express LocalDB
- HTML, CSS, and Bootstrap
- REST API

## Project Structure

The solution consists of four projects:

1. **CampusLibrary.Domain** — Contains the Book entity and interfaces.
2. **CampusLibrary.Application** — Contains the BookService and business logic.
3. **CampusLibrary.Infrastructure** — Contains the BookRepository, DbContext, and database migrations.
4. **CampusLibrary.Web** — Contains MVC controllers, Razor views, REST API, and the user interface.

## System Features

- Display and manage library books
- Create new book records
- View book details
- Edit book information
- Delete book records
- Display book statistics on the dashboard
- Retrieve book information through a REST API

## Database

The application uses SQL Server Express LocalDB with Entity Framework Core.

The included EF Core migrations can create the required database schema.

## How to Run the Project

### Requirements

- .NET 10 SDK
- SQL Server Express LocalDB
- Entity Framework Core CLI tools

### Instructions

1. Open PowerShell in the CampusLibrary project folder.
2. Run `dotnet restore`.
3. Run `dotnet build CampusLibrary.sln`.
4. Apply the migrations:

   `dotnet ef database update --project CampusLibrary.Infrastructure --startup-project CampusLibrary.Web`

5. Start the website:

   `dotnet run --project CampusLibrary.Web`

6. Open the URL displayed in PowerShell, followed by `/Books`.

For the development setup used in this project, the website runs at:

`http://localhost:5087/Books`

## REST API

The project implements these book management endpoints:

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/books` | Retrieve all books |
| GET | `/api/books/{id}` | Retrieve a book by ID |
| POST | `/api/books` | Add a book |
| PUT | `/api/books/{id}` | Update a book |
| DELETE | `/api/books/{id}` | Delete a book |

The GET collection endpoint has been manually tested. The remaining API methods are implemented but have not been fully verified.

## Screenshots

Evidence of the application's functionality is available in the `Screenshots` folder:

- `01-Dashboard.png`
- `02-Create-Book.png`
- `03-Edit-Book.png`
- `04-REST-API.png`
- `05-Build-Success.png`

## Notes

- The application uses a local SQL Server database.
- Existing database records are not included in the source ZIP.
- The database schema can be recreated using EF Core migrations.
- The project uses a layered architecture with dependency injection.

## Project Status

The MVC dashboard, book creation, book editing, book listing, and API book retrieval have been tested successfully.