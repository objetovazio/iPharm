using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IFES.POO2.Ipharm.PortalAdministrativo.Startup))]
namespace IFES.POO2.Ipharm.PortalAdministrativo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
