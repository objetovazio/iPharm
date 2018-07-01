using AutoMapper;
using IFES.POO2.Ipharm.Domain;
using IFES.POO2.Ipharm.PortalEmpresa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IFES.POO2.Ipharm.PortalEmpresa.AutoMapper
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<RegisterViewModel, User>();
            CreateMap<RegisterViewModel, Company>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<ProductEditViewModel, Product>();
        }
    }
}