using CampusLibrary.Domain.Entities;
using CampusLibrary.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampusLibrary.Web.Controllers;

public class BooksController : Controller
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<IActionResult> Index()
    {
        var books = await _bookService.GetAllBooksAsync();
        return View(books);
    }

    public async Task<IActionResult> Details(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        return book == null ? NotFound() : View(book);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Book book)
    {
        if (!ModelState.IsValid)
            return View(book);

        try
        {
            await _bookService.AddBookAsync(book);
            return RedirectToAction(nameof(Index));
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(book);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        return book == null ? NotFound() : View(book);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Book book)
    {
        if (id != book.Id)
            return BadRequest();

        if (!ModelState.IsValid)
            return View(book);

        try
        {
            await _bookService.UpdateBookAsync(book);
            return RedirectToAction(nameof(Index));
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(book);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        return book == null ? NotFound() : View(book);
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePost(int id)
    {
        await _bookService.DeleteBookAsync(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _bookService.DeleteBookAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
