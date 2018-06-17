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
    public class AdminController : Controller
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
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Login, Email = model.Email, EmailConfirmed = true };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    User domainUser = Mapper.Map<RegisterAdminViewModel, User>(model);
                    domainUser.IsAdministrator = true;
                    domainUser.IsActive = true;
                    domainUser.Id = new Guid(user.Id);
                    _userRepository.Insert(domainUser);

                    TempData["Success"] = "O Administrador " + domainUser.Login + " foi criado!";

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
        public ActionResult Edit(Guid? id, [Bind(Include = "Name,Email,IsActive")] ListAdminViewModel model)
        {

            if (ModelState.IsValid && id.HasValue)
            {
                User domainUser = _userRepository.SelectById(id.Value);
                domainUser.Email = model.Email;
                domainUser.IsActive = model.IsActive;
                domainUser.Name = model.Name;

                _userRepository.Update(domainUser);
                return RedirectToAction("Index", "Admin");
            }

            return View(model);
        }
    }
}
