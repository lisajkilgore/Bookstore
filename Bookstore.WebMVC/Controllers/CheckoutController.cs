using Bookstore.Models;
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
            var token = chargeModel.StripeToken; // Using ASP.NET MVC

            var options = new ChargeCreateOptions
            {
                Amount = 999,
                Currency = "usd",
                Description = "Example charge",
                SourceId = token,
            };
            var service = new ChargeService();
            Charge charge = service.Create(options);

            return RedirectToAction("Confirmation");
        }
        

        // GET: Confirmation
        public ActionResult Confirmation()
        {
            return View();
        }

    }
}