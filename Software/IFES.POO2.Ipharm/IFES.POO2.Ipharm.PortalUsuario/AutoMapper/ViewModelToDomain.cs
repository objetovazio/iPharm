using AutoMapper;
using IFES.POO2.Ipharm.Domain;
using IFES.POO2.Ipharm.PortalUsuario.Models;

namespace IFES.POO2.Ipharm.PortalUsuario.AutoMapper
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<RegisterViewModel, User>();
            CreateMap<RegisterViewModel, Person>();
        }
    }
}