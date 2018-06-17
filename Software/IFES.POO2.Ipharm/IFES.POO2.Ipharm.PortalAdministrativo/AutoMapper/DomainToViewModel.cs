using AutoMapper;
using IFES.POO2.Ipharm.Domain;
using IFES.POO2.Ipharm.PortalAdministrativo.Models;
using IFES.POO2.Ipharm.PortalAdministrativo.Models.Admin;

namespace IFES.POO2.Ipharm.PortalAdministrativo.AutoMapper
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<User, RegisterViewModel>();
            CreateMap<User, ListAdminViewModel> ();
            CreateMap<User, RegisterAdminViewModel> ();
        }
    }
}