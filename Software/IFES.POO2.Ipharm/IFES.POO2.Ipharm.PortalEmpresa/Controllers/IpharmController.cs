﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IFES.POO2.Ipharm.AcessoDados.Entity.Context;
using IFES.POO2.Ipharm.Domain;
using IFES.POO2.Ipharm.PortalEmpresa.Filters;
using IFES.POO2.Ipharm.Repository.Entity;
using Microsoft.AspNet.Identity;

namespace IFES.POO2.Ipharm.PortalEmpresa.Controllers
{

    public enum MessageType
    {
        Success = 1,
        Error = 2,
        Info = 3,
        Notice = 4
    }

    [UserDataFilter]
    public class IpharmController : Controller
    {
        public IpharmController()
        {
        }

        public User CurrentUser
        {
            get => (User)Session["CurrentUser"];
            set => Session["CurrentUser"] = value;
        }

        /// <summary>
        /// Cria qualquer tipo de mensagem personalizada
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="messages"></param>
        public void Message(MessageType messageType, params string[] messages)
        {
            TempData["MessageType"] = (int)messageType;
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