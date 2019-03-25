using Bookstore.Data;
using Bookstore.Models;
using Bookstore.Services;
using Microsoft.AspNet.Identity;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookstore.WebMVC.Controllers
{
    public class CheckoutController : Controller
    {

        // GET: Product
        public ActionResult Index()
        {
            string stripePublishableKey = ConfigurationManager.AppSettings["pk_test_xyxrTGDcuvs2YlTTIu9Ak5M1"];
            var model = new ProductModel() { StripePublishableKey = stripePublishableKey };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Charge(ChargeModel chargeModel)
        {
            return RedirectToAction("Confirmation");
        }

        public ActionResult Custom()
        {
            string stripePublishableKey = ConfigurationManager.AppSettings["pk_test_xyxrTGDcuvs2YlTTIu9Ak5M1"];
            var model = new ChargeModel() { StripePublishableKey = stripePublishableKey, PaymentFormHidden = true };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Custom(ChargeModel chargeModel)

        {
            // Set your secret key: remember to change this to your live secret key in production
            // See your keys here: https://dashboard.stripe.com/account/apikeys
            StripeConfiguration.SetApiKey("sk_test_n9ph6eUYkYPByT2ua06v6Bdv");

            // Token is created using Checkout or Elements!
            // Get the payment token submitted by the form:
            var token = chargeModel.Token; // Using ASP.NET MVC

            var options = new ChargeCreateOptions
            {
                Amount = 1999,
                Currency = "usd",
                Description = "Example charge",
                SourceId = token,
                Capture = false,
                ReceiptEmail = "lisajkilgore@hotmail.com",
            };
            var service = new ChargeService();
            Charge charge = service.Create(options);

            return RedirectToAction("Confirmation");
        }



        //public ActionResult UpdateInventory(int cartId, int bookId, int quantity)
        //{

        //    List<UserCartListItem> userCart = GetUserBooks();
        //    foreach (var book in userCart)
        //    {
        //        for (int i = 0; i < quantity; i++)
        //        {
        //            if (bookId ==
        //        }
        //    }

        //    return View();
        //}

        //public ActionResult ClearCart()
        //{
        //    var service = CreateCartService();
        //    var model = service.GetCartById(id);
        //    var cartItems = service.GetUserBooks();
        //    foreach(var book in cartItems)
        //    {
        //        cartItems.Remove(cartItems);
        //    }

        //    cartItems.SaveChanges();
    }
}

