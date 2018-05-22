using System.Web;
using System.Web.Mvc;

namespace IFES.POO2.Ipharm.PortalAdministrativo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
