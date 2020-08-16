using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieRentaMVC.Startup))]
namespace MovieRentaMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
