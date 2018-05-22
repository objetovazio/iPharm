using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IFES.POO2.Ipharm.PortalUsuario.Startup))]
namespace IFES.POO2.Ipharm.PortalUsuario
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
