using System;
using System.Linq;
using System.Web.Mvc;
using IFES.POO2.Ipharm.AcessoDados.Entity.Context;
using IFES.POO2.Ipharm.Domain;
using IFES.POO2.Ipharm.Repository.Common.Entity.Common;

namespace IFES.POO2.Ipharm.PortalUsuario.Controllers
{
    [Authorize]
    public class AjaxController : IpharmController
    {
        private static IpharmContext _context = new IpharmContext();

        protected GenericRepositoryEntity<Localization, Guid> _localizationRepository = new GenericRepositoryEntity<Localization, Guid>(_context);
        protected GenericRepositoryEntity<Product, Guid> _productRepository = new GenericRepositoryEntity<Product, Guid>(_context);

        [HttpPost]
        public void SaveLocation(float latitude, float longitude)
        {
            Localization localization = _localizationRepository.SelectById(CurrentUser.Localization.Id) ;

            if (localization.Latitude == latitude && localization.Longitude == longitude)
                return;

            localization.Latitude = latitude;
            localization.Longitude = longitude;
            _localizationRepository.Update(localization);
        }

        [HttpPost]
        public int AddProduct(Guid id)
        {
            Product p = _productRepository.SelectById(id);
            ItemOrder io = new ItemOrder(CurrentOrder, p);

            CurrentOrder.ItemsOrder.Add(io);

            return CurrentOrder.ItemsOrder.Count;
        }

        [HttpPost]
        public int RemoveProduct(Guid id)
        {
            var itemOrder = CurrentOrder.ItemsOrder.FirstOrDefault(a => a.Product.Id == id);
            CurrentOrder.ItemsOrder.Remove(itemOrder);

            Message(MessageType.Success , "Produto removido da cesta.");

            return CurrentOrder.ItemsOrder.Count;
        }
    }
}