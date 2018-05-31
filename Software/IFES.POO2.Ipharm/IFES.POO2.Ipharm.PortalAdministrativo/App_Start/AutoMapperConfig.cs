using AutoMapper;
using IFES.POO2.Ipharm.PortalAdministrativo.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreinaWeb.Musicas.Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configurar()
        {
            Mapper.Initialize(a => 
            {
                a.AddProfile<ViewModelToDomain>();
                a.AddProfile<DomainToViewModel>();
            });
        }

    }
}