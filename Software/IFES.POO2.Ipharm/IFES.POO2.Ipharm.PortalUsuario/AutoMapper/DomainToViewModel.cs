using AutoMapper;
using IFES.POO2.Ipharm.Domain;
using IFES.POO2.Ipharm.PortalUsuario.Models;

namespace IFES.POO2.Ipharm.PortalUsuario.AutoMapper
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<User, RegisterViewModel>();
        }
    }
}