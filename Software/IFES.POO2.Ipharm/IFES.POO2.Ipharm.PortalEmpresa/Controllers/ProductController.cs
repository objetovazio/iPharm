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
using IFES.POO2.Ipharm.PortalEmpresa.Models;
using IFES.POO2.Ipharm.Repository.Common.Entity;
using IFES.POO2.Ipharm.Repository.Common.Entity.Common;

namespace IFES.POO2.Ipharm.PortalEmpresa.Controllers
{
    public class ProductController : DefaultController
    {
        private static IpharmContext _context = new IpharmContext();

        private GenericRepositoryEntity<Product, Guid>
            _repository = new GenericRepositoryEntity<Product, Guid>(_context);

        // GET: Product
        public ActionResult Index()
        {
            List<ProductViewModel> products =
                Mapper.Map<List<Product>, List<ProductViewModel>>(_repository.Select().Where(p => p.Company == CurrentUser(_context).Company).ToList());
            return View(products);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Value,Description,HasControl")] ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = Mapper.Map<ProductCreateViewModel, Product>(model);

                product.Company = CurrentUser(_context).Company;
                _repository.Insert(product);

                Message(MessageType.Success, "Produto criado com sucesso.");

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                Message(MessageType.Error, "É necessário selecionar um produto.");
                return RedirectToAction("Index");
            }
            Product product = _repository.SelectById(id.Value);
            ProductEditViewModel productView = Mapper.Map<Product, ProductEditViewModel>(product);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(productView);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Value,Description,HasControl,IsDeleted")] ProductEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product p = _repository.SelectById(model.Id);
                p.Name = model.Name;
                p.Value = model.Value;
                p.HasControl = model.HasControl;
                p.Description = model.Description;
                p.IsDeleted = model.IsDeleted;

                _repository.Update(p);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Product/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                Message(MessageType.Error, "É necessário selecionar um produto.");
                return RedirectToAction("Index");
            }

            Product product = _repository.SelectById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }

            var model = Mapper.Map<Product, ProductDetailsViewModel>(product);
            return View(model);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                Message(MessageType.Error, "É necessário selecionar um produto.");
                return RedirectToAction("Index");
            }
            _repository.DeleteById(id.Value);

            return RedirectToAction("Index", "Product");
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var product = _repository.SelectById(id);
            product.IsDeleted = true;
            _repository.Update(product);
            return RedirectToAction("Index");
        }
    }
}
