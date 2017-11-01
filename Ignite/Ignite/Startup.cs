using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ignite.Startup))]
namespace Ignite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
 