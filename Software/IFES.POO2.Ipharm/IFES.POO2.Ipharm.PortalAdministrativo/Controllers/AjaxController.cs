using System;
using System.Web.Mvc;
using IFES.POO2.Ipharm.AcessoDados.Entity.Context;
using IFES.POO2.Ipharm.Domain;
using IFES.POO2.Ipharm.Repository.Common.Entity.Common;

namespace IFES.POO2.Ipharm.PortalAdministrativo.Controllers
{
    public class AjaxController : IpharmController
    {
        private static IpharmContext _context = new IpharmContext();

        protected GenericRepositoryEntity<Localization, Guid> LocalizationRepository = new GenericRepositoryEntity<Localization, Guid>(_context);

        [Authorize]
        [HttpPost]
        public void SaveLocation(float latitude, float longitude)
        {
            Localization localization = LocalizationRepository.SelectById(CurrentUser.Localization.Id) ;

            if (localization.Latitude == latitude && localization.Longitude == longitude)
                return;

            localization.Latitude = latitude;
            localization.Longitude = longitude;
            LocalizationRepository.Update(localization);
        }
    }
}