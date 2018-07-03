using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IFES.POO2.Ipharm.AcessoDados.Entity.Context;
using IFES.POO2.Ipharm.Domain;
using IFES.POO2.Ipharm.Repository.Common.Entity.Common;

namespace IFES.POO2.Ipharm.PortalEmpresa.Controllers
{
    public class AjaxController : IpharmController
    {
        private static IpharmContext _context = new IpharmContext();

        protected GenericRepositoryEntity<Localization, Guid> _localizationRepository = new GenericRepositoryEntity<Localization, Guid>(_context);

        [Authorize]
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
    }
}