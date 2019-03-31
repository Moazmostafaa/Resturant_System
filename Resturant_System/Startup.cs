using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Resturant_System.Startup))]
namespace Resturant_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
