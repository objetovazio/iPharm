using AutoMapper;
using IFES.POO2.Ipharm.Domain;
using IFES.POO2.Ipharm.PortalEmpresa.Models;

namespace IFES.POO2.Ipharm.PortalEmpresa.AutoMapper
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<User, RegisterViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Product, ProductEditViewModel>();
            CreateMap<Product, ProductDetailsViewModel>();
        }
    }
}