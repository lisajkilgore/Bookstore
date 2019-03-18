using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Bookstore.WebMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            StripeConfiguration.SetApiKey(ConfigurationManager.AppSettings["sk_test_n9ph6eUYkYPByT2ua06v6Bdv"]);
            StripeConfiguration.SetApiKey(ConfigurationManager.AppSettings["pk_test_xyxrTGDcuvs2YlTTIu9Ak5M1"]);
        }
    }
}
