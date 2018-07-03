using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Device.Location;
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
        private static IpharmContext _context = new IpharmContext();

        public CompanyRepository RepositoryCompany = new CompanyRepository(_context);

        public GenericRepositoryEntity<Product, Guid> RepositoryProduct = new GenericRepositoryEntity<Product, Guid>(_context);

        // GET: Company
        public ActionResult Index()
        {
            var comp = RepositoryCompany.Select();

            var model = Mapper.Map<List<Company>, List<CompanyListViewModel>>(comp);

            model.ForEach(c => c.UserCoordinate = new GeoCoordinate(CurrentUser.Localization.Latitude, CurrentUser.Localization.Longitude));

            return View(model);
        }



        private GenericRepositoryEntity<Company, int>
            _repositoryCompany = new GenericRepositoryEntity<Company, int>(_context);

        // GET: Product
        public ActionResult ListProducts(int idEmpresa)
        {
            List<ProductViewModel> products =
                Mapper.Map<List<Product>, List<ProductViewModel>>(RepositoryProduct.Select().Where(p => p.Company.Id == CurrentUser.Company.Id).ToList());
            return View(products);
        }

    }
}
