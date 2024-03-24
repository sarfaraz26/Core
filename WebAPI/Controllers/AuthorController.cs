using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly LibraryDbContext _libraryDbContext;

        public AuthorController(LibraryDbContext libraryDbContext)
        {
            this._libraryDbContext = libraryDbContext;
        }

        // Get all Authors
        [HttpGet]
        public List<Author> GetAuthors()
        {
            return this._libraryDbContext.Authors.ToList();
        }

        // Get Single Author
        [HttpGet("{id}")]
        public Author GetAuthor(int id)
        {
            return this._libraryDbContext.Authors.ToList().Find(author => author.AuthorId == id);
        }

        // Create Author
        [HttpPost]
        public IActionResult AddAuthor(Author author)
        {
            if (!ModelState.IsValid || author is null)
            {
                return BadRequest("Invalid Operation");
            }
            else
            {
                this._libraryDbContext.Authors.Add(author);
                this._libraryDbContext.SaveChanges();

                return Ok();
            }
        }


        // Update Author
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, Author author)
        {
            if (!ModelState.IsValid || author is null)
            {
                return BadRequest();
            }
            else
            {
                Author authore = _libraryDbContext.Authors.ToList().Find(auth => auth.AuthorId == id);

                if (authore is null)
                {
                    return NotFound();
                }
                else
                {
                    authore.AuthorName = author.AuthorName;
                    authore.Age = author.Age;
                    authore.Address = author.Address;

                    this._libraryDbContext.SaveChanges();

                    return Ok();
                }
            }
        }

        // Delete Author
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            Author author = _libraryDbContext.Authors.ToList().Find(author => author.AuthorId == id);

            if (author is null)
            {
                return NotFound();
            }
            else
            {
                List<Book> books = _libraryDbContext.Books.ToList().FindAll(book => book.AuthorId == id);

                foreach(Book book in books)
                {
                    this._libraryDbContext.Books.Remove(book);
                }

                _libraryDbContext.SaveChanges();

                _libraryDbContext.Authors.Remove(author);
                _libraryDbContext.SaveChanges();

                return Ok();
            }
        }


    }
}
