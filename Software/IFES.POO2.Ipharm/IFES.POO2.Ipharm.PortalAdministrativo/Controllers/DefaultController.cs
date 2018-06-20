using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IFES.POO2.Ipharm.PortalAdministrativo.Controllers
{

    public enum MessageType
    {
        Success = 1,
        Error = 2,
        Info = 3,
        Notice = 4
    }

    public class DefaultController : Controller
    {
        /// <summary>
        /// Cria qualquer tipo de mensagem personalizada
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="messages"></param>
        public void Message(MessageType messageType, params string[] messages)
        {
            TempData["MessageType"] = (int) messageType;
            foreach (var message in messages)
            {
                TempData["Message"] += message + "\\\n";
            }
        }

        /// <summary>
        /// Método específico para mostrar erros do ModelState
        /// </summary>
        /// <param name="messages"></param>
        public void MessageError(params string[] messages)
        {
            foreach (var message in messages)
            {
                ModelState.AddModelError("", message); ;
            }
        }
    }
}