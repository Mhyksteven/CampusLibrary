using CampusLibrary.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace CampusLibrary.Web.Models;

public class CreateBookModel
{
    public Book Book { get; set; } = new();
    public IFormFile? CoverImage { get; set; }
}