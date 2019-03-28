using Bookstore.Models;
using Bookstore.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bookstore.WebApi.Controllers
{
    [Authorize]
    public class BookController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            BookService bookService = CreateBookService();
            var books = bookService.GetBooks();
            return Ok(books);
        }

        public IHttpActionResult Get(int bookId)
        {
            BookService bookService = CreateBookService();
            var book = bookService.GetBookById(bookId);
            return Ok(book);
        }

        public IHttpActionResult Post(BookCreate book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBookService();

            if (!service.CreateBook(book))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Put(BookEdit book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBookService();

            if (!service.UpdateBook(book))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int bookId)
        {
            var service = CreateBookService();

            if (!service.DeleteBook(bookId))
                return InternalServerError();
            return Ok();
        }
        private BookService CreateBookService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var bookService = new BookService(userId);
            return bookService;
        }
    }
}
