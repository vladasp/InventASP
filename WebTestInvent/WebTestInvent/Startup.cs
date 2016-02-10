using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebTestInvent.Startup))]
namespace WebTestInvent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
