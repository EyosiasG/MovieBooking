using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieBook.Startup))]
namespace MovieBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
