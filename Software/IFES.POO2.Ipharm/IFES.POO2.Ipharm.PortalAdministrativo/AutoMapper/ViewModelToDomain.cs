using AutoMapper;
using IFES.POO2.Ipharm.Domain;
using IFES.POO2.Ipharm.PortalAdministrativo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IFES.POO2.Ipharm.PortalAdministrativo.Models.Admin;

namespace IFES.POO2.Ipharm.PortalAdministrativo.AutoMapper
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<RegisterViewModel, User>();
            CreateMap<ListAdminViewModel, User>();
            CreateMap<RegisterAdminViewModel, User>();
        }
    }
}