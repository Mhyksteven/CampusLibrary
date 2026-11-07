# Report 04 - Service-Repository Pattern

## Objective
Separate the application's responsibilities into layers.

## Implementation
- Domain contains the Book entity and interfaces.
- Application contains BookService.
- Infrastructure contains BookRepository and database access.
- Web contains MVC controllers and Razor views.

## Dependency Injection
IBookRepository and IBookService are registered in Program.cs.

## Result
The four-project solution was built successfully.
