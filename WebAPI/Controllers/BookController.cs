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
    public class BookController : ControllerBase
    {
        private readonly LibraryDbContext _libraryDbContext;

        public BookController(LibraryDbContext libraryDbContext)
        {
            this._libraryDbContext = libraryDbContext;
        }


        // Get All Books
        [HttpGet]
        public List<Book> GetBooks()
        {
            return this._libraryDbContext.Books.Include(b => b.Author).ToList();
        }


        // Get Single Book
        [HttpGet("{id}")]
        public Book GetBook(int id)
        {
            return this._libraryDbContext.Books.ToList().Find(book => book.BookID == id);
        }


        // Create Book
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (!ModelState.IsValid || book is null)
            {
                return BadRequest("Invalid Operation");
            }
            else
            {
                this._libraryDbContext.Books.Add(book);
                this._libraryDbContext.SaveChanges();

                return Ok("Added");
            }
        }


        // Update a Book
        [HttpPatch("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            if(!ModelState.IsValid || book is null)
            {
                return BadRequest();
            }
            else
            {
                Book booke = _libraryDbContext.Books.ToList().Find(book => book.BookID == id);

                if(booke is null)
                {
                    return NotFound();
                }
                else
                {
                    booke.Title = book.Title;
                    booke.Description = book.Description;
                    booke.Price = book.Price;
                    booke.PublishedDate = book.PublishedDate;
                    booke.isPublished = book.isPublished;
                    booke.AuthorId = book.AuthorId;

                    _libraryDbContext.SaveChanges();
                    return Ok("Updated");
                }
            }
        }



        // Delete a Book
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            Book book = _libraryDbContext.Books.ToList().Find(book => book.BookID == id);

            if(book is null)
            {
                return NotFound("Invalid ID");
            }
            else
            {
                _libraryDbContext.Books.Remove(book);
                _libraryDbContext.SaveChanges();

                return Ok("Book Removed");
            }
        }
    }
}
