using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IFES.POO2.Ipharm.AcessoDados.Entity.Context;
using IFES.POO2.Ipharm.Domain;
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

    public class DefaultController : Controller
    {
        private static IpharmContext _ipharmContext = new IpharmContext();

        public static IpharmContext Context
        {
            get { return _ipharmContext ?? (_ipharmContext = new IpharmContext()); }
        }


        private User _currentUser;
        private UserRepository _userRepository;

        public UserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(Context)); }
        }
        public User CurrentUser
        {
            get
            {
                return _currentUser ?? (_currentUser = UserRepository.SelectById(Guid.Parse(User.Identity.GetUserId())));
            }
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