using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IFES.POO2.Ipharm.PortalAdministrativo.Controllers
{
    public class DefaultController : Controller
    {
        public void MessageSucess(params string[] messages)
        {
            foreach (var message in messages)
            {
                TempData["Success"] += message + "\\\n";
            }
        }

        public void MessageError(params string[] messages)
        {
            foreach (var message in messages)
            {
                ModelState.AddModelError("", message);;
            }
        }
    }
}