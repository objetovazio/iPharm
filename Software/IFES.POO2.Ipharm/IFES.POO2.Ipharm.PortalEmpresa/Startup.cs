using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IFES.POO2.Ipharm.PortalEmpresa.Startup))]
namespace IFES.POO2.Ipharm.PortalEmpresa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
