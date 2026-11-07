using CampusLibrary.Domain.Entities;
using CampusLibrary.Domain.Interfaces;

namespace CampusLibrary.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddBookAsync(Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Title))
            throw new ArgumentException("Title is required");
        if (string.IsNullOrWhiteSpace(book.Author))
            throw new ArgumentException("Author is required");
        if (string.IsNullOrWhiteSpace(book.ISBN))
            throw new ArgumentException("ISBN is required");
        if (book.PublicationYear < 0)
            throw new ArgumentException("Publication year cannot be negative");
        if (book.TotalCopies < 0 || book.AvailableCopies < 0)
            throw new ArgumentException("Copy counts cannot be negative");
        if (book.AvailableCopies > book.TotalCopies)
            throw new ArgumentException("Available copies cannot exceed total copies");

        await _repository.AddAsync(book);
    }

    public async Task UpdateBookAsync(Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Title))
            throw new ArgumentException("Title is required");
        if (string.IsNullOrWhiteSpace(book.Author))
            throw new ArgumentException("Author is required");
        if (string.IsNullOrWhiteSpace(book.ISBN))
            throw new ArgumentException("ISBN is required");
        if (book.PublicationYear < 0)
            throw new ArgumentException("Publication year cannot be negative");
        if (book.TotalCopies < 0 || book.AvailableCopies < 0)
            throw new ArgumentException("Copy counts cannot be negative");
        if (book.AvailableCopies > book.TotalCopies)
            throw new ArgumentException("Available copies cannot exceed total copies");

        await _repository.UpdateAsync(book);
    }

    public async Task DeleteBookAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
