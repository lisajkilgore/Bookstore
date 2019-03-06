using Bookstore.Models;
using Bookstore.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookstore.WebMVC.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BookService(userId);
            var model = service.GetBooks();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            BookService service = CreateBookService();

            if (service.CreateBook(model))
            {
                TempData["SaveResult"] = "Your book was successally added to the database.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "An error was encountered. Your book could not be added.");

            return View(model);
        }

        public ActionResult Details(int bookId)
        {
            var svc = CreateBookService();
            var model = svc.GetBookById(bookId);

            return View(model);
        }

        public ActionResult Edit(int bookId)
        {
            var service = CreateBookService();
            var detail = service.GetBookById(bookId);
            var model =
                new BookEdit
                {
                    BookId = detail.BookId,
                    Title = detail.Title,
                    Author = detail.Author

                };
            return View(model);
        }

        private BookService CreateBookService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BookService(userId);
            return service;
        }
    }
}

