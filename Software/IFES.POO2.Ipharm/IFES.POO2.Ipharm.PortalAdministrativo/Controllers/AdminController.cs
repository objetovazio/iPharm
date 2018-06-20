using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using IFES.POO2.Ipharm.AcessoDados.Entity.Context;
using IFES.POO2.Ipharm.Domain;
using IFES.POO2.Ipharm.PortalAdministrativo.Models;
using IFES.POO2.Ipharm.PortalAdministrativo.Models.Admin;
using IFES.POO2.Ipharm.Repository.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace IFES.POO2.Ipharm.PortalAdministrativo.Controllers
{
    public class AdminController : DefaultController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private readonly UserRepository _userRepository = new UserRepository(new IpharmContext());

        private User _currentUser;

        public User CurrentUser
        {
            get
            {
                if (_currentUser == null) _currentUser = _userRepository.SelectById(Guid.Parse(User.Identity.GetUserId()));
                return _currentUser;
            }
        }


        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Admin
        public ActionResult Index()
        {
            var users = _userRepository.SelectAdmins();

            users.Remove(CurrentUser);

            var viewUsers = Mapper.Map<List<User>, List<ListAdminViewModel>>(users);

            return View(viewUsers);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterAdminViewModel model)
        {
            User domainUser = Mapper.Map<RegisterAdminViewModel, User>(model);
            _userRepository.Exists(domainUser);

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Login, Email = model.Email, EmailConfirmed = true };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    domainUser.IsAdministrator = true;
                    domainUser.IsActive = true;
                    domainUser.Id = new Guid(user.Id);
                    _userRepository.Insert(domainUser);

                    base.Message(MessageType.Success, "O Administrador " + domainUser.Login + " foi criado!");

                    return RedirectToAction("Index", "Admin");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View("Create", model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = _userRepository.SelectById((Guid)id);

            if (user == null)
            {
                return HttpNotFound();
            }

            ListAdminViewModel model = Mapper.Map<User, ListAdminViewModel>(user);

            return View(model);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid? id, [Bind(Include = "Login,Name,Email,IsActive")] ListAdminViewModel model)
        {
            if (ModelState.IsValid && id.HasValue)
            {
                var userValidation = await UserManager.FindByEmailAsync(model.Email);
                bool found = userValidation != null;

                if (found && userValidation.Id != id.Value.ToString())
                {
                    MessageError("Email já cadastrado.");
                    return View(model);
                }

                var user = found && userValidation.Id == id.Value.ToString() 
                    ? userValidation 
                    : await UserManager.FindByIdAsync(id.Value.ToString());

                user.Email = model.Email;

                User domainUser = _userRepository.SelectById(id.Value);
                domainUser.Email = model.Email;
                domainUser.IsActive = model.IsActive;
                domainUser.Name = model.Name;

                await UserManager.UpdateAsync(user);
                _userRepository.Update(domainUser);

                base.Message(MessageType.Success, "Administrador atualizado com sucesso");

                return RedirectToAction("Index", "Admin");
            }

            return View(model);
        }
    }
}
