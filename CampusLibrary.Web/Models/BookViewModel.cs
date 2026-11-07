using CampusLibrary.Domain.Entities;

namespace CampusLibrary.Web.Models;

public class BookViewModel
{
    public Book Book { get; set; } = new();
    public bool IsEditMode => Book.Id == default(int);
}