using CampusLibrary.Domain.Entities;

namespace CampusLibrary.Domain.Interfaces;

public interface IBookService
{
    Task<IEnumerable<Book>> GetAllBooksAsync();

    Task<Book?> GetBookByIdAsync(int id);

    Task AddBookAsync(Book book);

    Task UpdateBookAsync(Book book);

    Task DeleteBookAsync(int id);
}