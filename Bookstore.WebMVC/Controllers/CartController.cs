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
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CartService(userId);
            var model = service.GetUserBooks();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CartCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            CartService service = CreateCartService();

            if (service.CreateCart(model))
            {
                TempData["SaveResult"] = "Your cart has been successully updated.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "An error was encountered. Your cart was not updated.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCartService();
            var model = svc.GetCartById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCartService();
            var detail = service.GetCartById(id);
            var model =
                new CartEdit
                {
                    CartId = detail.CartId,
                    OwnerId = detail.OwnerId,
                    BookId = detail.BookId,
                    Quantity = detail.Quantity,
                    Price = detail.Price,
                    CartTotal = detail.CartTotal,
                    Book = detail.Book
                };
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCartService();
            var model = svc.GetCartById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CartEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CartId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCartService();

            if (service.UpdateCart(model))
            {
                TempData["SaveResult"] = "Your cart was successully updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "An error was encountered. Your cart could not be updated.");
            return View(model);
        }
        private CartService CreateCartService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CartService(userId);
            return service;
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCartService();

            service.DeleteCart(id);

            TempData["SaveResult"] = "Your cart was deleted.";

            return RedirectToAction("Index");
        }
    }
}