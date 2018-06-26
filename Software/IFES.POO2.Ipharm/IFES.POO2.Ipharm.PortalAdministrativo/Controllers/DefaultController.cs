using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IFES.POO2.Ipharm.AcessoDados.Entity.Context;
using IFES.POO2.Ipharm.Domain;
using IFES.POO2.Ipharm.Repository.Common.Entity;
using IFES.POO2.Ipharm.Repository.Entity;
using Microsoft.AspNet.Identity;

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
        private User _currentUser;
        private UserRepository _userRepository;

        public UserRepository UserRepository
        {
            get
            {
                if (_userRepository == null) _userRepository = new UserRepository(new IpharmContext());
                return _userRepository;
            }
        }
        public User CurrentUser
        {
            get
            {
                if (_currentUser == null) _currentUser = _userRepository.SelectById(Guid.Parse(User.Identity.GetUserId()));
                return _currentUser;
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