using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Device.Location;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using IFES.POO2.Ipharm.AcessoDados.Entity.Context;
using IFES.POO2.Ipharm.Domain;
using IFES.POO2.Ipharm.PortalUsuario.Models;
using IFES.POO2.Ipharm.Repository.Common.Entity.Common;
using IFES.POO2.Ipharm.Repository.Entity;

namespace IFES.POO2.Ipharm.PortalUsuario.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CompanyController : IpharmController
    {
        private static IpharmContext _context;

        public static IpharmContext Context
        {
            get { return _context ?? (_context = new IpharmContext()); }
        }

        public CompanyRepository RepositoryCompany = new CompanyRepository(Context);

        public GenericRepositoryEntity<Product, Guid> RepositoryProduct = new GenericRepositoryEntity<Product, Guid>(Context);

        public GenericRepositoryEntity<Order, int> RepositoryOrder = new GenericRepositoryEntity<Order, int>(Context);


        // GET: Company
        public ActionResult Index()
        {
            var comp = RepositoryCompany.Select();

            var model = Mapper.Map<List<Company>, List<CompanyListViewModel>>(comp);

            model.ForEach(c => c.UserCoordinate = new GeoCoordinate(CurrentUser.Localization.Latitude, CurrentUser.Localization.Longitude));

            return View(model);
        }

        // GET: Product
        public ActionResult ListProducts(int id)
        {
            CurrentCompany = RepositoryCompany.SelectById(id);

            if (CurrentOrder == null || (CurrentOrder != null && CurrentOrder.Company.Id != id))
            {
                CurrentOrder = new Order(CurrentUser.Person, CurrentCompany);
            }

            List<ProductViewModel> products =
                Mapper.Map<List<Product>, List<ProductViewModel>>(CurrentCompany.Products).Where(p => !p.IsDeleted).ToList();

            return View("ProductList", products);
        }

        // GET: Product
        public ActionResult ListChart()
        {
            if (CurrentOrder == null) return RedirectToAction("Index", "Company");

            var list = CurrentOrder.ItemsOrder;
            List<Product> products = new List<Product>();

            list.ForEach(ls =>  products.Add(ls.Product));


            ViewBag.CompanyId = CurrentCompany.Id;

            return View("ProductsChart", Mapper.Map<List<Product>, List<ProductViewModel>>(products));
        }
    }
}
