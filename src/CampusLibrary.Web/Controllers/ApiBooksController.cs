using CampusLibrary.Domain.Interfaces;
using CampusLibrary.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CampusLibrary.Web.Controllers;

[ApiController]
[Route("api/books")]
public class ApiBooksController : ControllerBase
{
    private readonly IBookService _service;

    public ApiBooksController(IBookService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        var books = await _service.GetAllBooksAsync();
        return Ok(books);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await _service.GetBookByIdAsync(id);
        if (book == null)
            return NotFound();
        return Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult<Book>> CreateBook(Book book)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        await _service.AddBookAsync(book);
        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateBook(int id, Book book)
    {
        if (id != book.Id)
            return BadRequest();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        await _service.UpdateBookAsync(book);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        await _service.DeleteBookAsync(id);
        return NoContent();
    }
}
