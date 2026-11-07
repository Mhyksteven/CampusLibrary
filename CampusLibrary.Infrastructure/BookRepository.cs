using CampusLibrary.Domain.Entities;
using CampusLibrary.Domain.Interfaces;
using CampusLibrary.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CampusLibrary.Infrastructure;

public class BookRepository : IBookRepository
{
    private readonly CampusLibraryDbContext _context;

    public BookRepository(CampusLibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task AddAsync(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var book = await GetByIdAsync(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}