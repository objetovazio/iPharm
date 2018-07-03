using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using IFES.POO2.Ipharm.PortalEmpresa.ModelBinder;

namespace IFES.POO2.Ipharm.PortalEmpresa
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.Configurar();
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
        }
    }
}
