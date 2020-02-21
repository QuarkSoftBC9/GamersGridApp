using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GamersGridApp.Startup))]
namespace GamersGridApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
