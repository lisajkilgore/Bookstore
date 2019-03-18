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

            var chargeOptions = new ChargeCreateOptions()
            {
                Amount = 1999,
                Currency = "usd",
                ReceiptEmail = chargeModel.StripeEmail,
                SourceId = chargeModel.StripeToken,
            };

            var chargeService = new ChargeService();

            try
            {
                var stripeCharge = chargeService.Create(chargeOptions);
            }
            catch (StripeException stripeException)
            {
                ModelState.AddModelError(string.Empty, stripeException.Message);
                return View(chargeModel);
            }

            return RedirectToAction("Confirmation");

        }

        // GET: Confirmation
        public ActionResult Confirmation()
        {
            return View();
        }

    }
}