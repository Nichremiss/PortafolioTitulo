using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CentroMedicoWeb.Startup))]
namespace CentroMedicoWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
