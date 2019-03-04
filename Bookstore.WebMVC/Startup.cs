using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bookstore.WebMVC.Startup))]
namespace Bookstore.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
