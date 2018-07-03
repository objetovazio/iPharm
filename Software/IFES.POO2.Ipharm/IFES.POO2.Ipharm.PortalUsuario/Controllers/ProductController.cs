using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using IFES.POO2.Ipharm.AcessoDados.Entity.Context;
using IFES.POO2.Ipharm.Domain;
using IFES.POO2.Ipharm.PortalUsuario.Models;
using IFES.POO2.Ipharm.Repository.Common.Entity;
using IFES.POO2.Ipharm.Repository.Common.Entity.Common;


namespace IFES.POO2.Ipharm.PortalUsuario.Controllers
{
    [Authorize(Roles = "Company")]
    public class ProductController : IpharmController
    {
        private static IpharmContext _context = new IpharmContext();

        private GenericRepositoryEntity<Product, Guid>
            _repositoryProduct = new GenericRepositoryEntity<Product, Guid>(_context);

        private GenericRepositoryEntity<Company, int>
            _repositoryCompany = new GenericRepositoryEntity<Company, int>(_context);

        // GET: Product
        public ActionResult Index()
        {
            List<ProductViewModel> products =
                Mapper.Map<List<Product>, List<ProductViewModel>>(_repositoryProduct.Select().Where(p => p.Company.Id == CurrentUser.Company.Id).ToList());
            return View(products);
        }
    }
}
