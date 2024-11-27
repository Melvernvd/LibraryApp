using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryApp.Models;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {

        private Dictionary<int, Book> Library;
        public LibraryController() {
            Library = new Dictionary<int, Book>
            {
                { 1, new Book { Id = 1, Title = "The Pragmatic Programmer", Author = "Andrew Hunt", Genre = "Technology", Year = 1999 } },
                { 2, new Book { Id = 2, Title = "Clean Code", Author = "Robert C. Martin", Genre = "Technology", Year = 2008 } },
                { 3, new Book { Id = 3, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction", Year = 1960 } },
                { 4, new Book { Id = 4, Title = "1984", Author = "George Orwell", Genre = "Fiction", Year = 1949 } },
                { 5, new Book { Id = 5, Title = "Sapiens", Author = "Yuval Noah Harari", Genre = "Non-Fiction", Year = 2011 } },
            };
        }

        // TODO: Add filters on each property
        [HttpGet("[action]")]
        public IActionResult GetAll() {
            var random = new Random().Next(0, 10);
            if (random < 3) return BadRequest("Something went wrong");
            Thread.Sleep(1500);
            var result = Library.Values.ToArray();
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetBookById(int id) {
            var result = Library.Values.FirstOrDefault(v => v.Id == id);
            if (result == null) return NotFound($"Book not found for {id}");
            return Ok(result);
        }

    }
}