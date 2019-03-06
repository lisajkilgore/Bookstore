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
                return RedirectToAction("Cart");
            };

            ModelState.AddModelError("", "An error was encountered. Your cart was not updated.");
            return View(model);
        }

        public ActionResult Details(int cartId)
        {
            var svc = CreateCartService();
            var model = svc.GetCartById(cartId);

            return View(model);
        }

        public ActionResult Edit(int cartId)
        {
            var service = CreateCartService();
            var detail = service.GetCartById(cartId);
            var model =
                new CartEdit
                {
                    CartId = detail.CartId,
                    OwnerId = detail.OwnerId,
                    BookId = detail.BookId,
                    Quantity = detail.Quantity,
                    Book = detail.Book
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int cartId, CartEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CartId != cartId)
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
    }
}