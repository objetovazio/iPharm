using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IFES.POO2.Ipharm.AcessoDados.Entity.Context;
using IFES.POO2.Ipharm.PortalUsuario.Controllers;
using IFES.POO2.Ipharm.Repository.Entity;
using Microsoft.AspNet.Identity;

namespace IFES.POO2.Ipharm.PortalEmpresa.Filters
{
    public class UserDataFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var identityUser = filterContext.HttpContext.User;

            if (identityUser.Identity.IsAuthenticated)
            {
                var userId = new Guid(identityUser.Identity.GetUserId());

                var usr = new UserRepository(new IpharmContext()).SelectById(userId);

                if (usr != null)
                {
                    var controller = filterContext.Controller as IpharmController;
                    controller.CurrentUser = usr;
                }
            }
        }

    }
}
