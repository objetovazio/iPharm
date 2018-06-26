using AutoMapper;
using IFES.POO2.Ipharm.PortalAdministrativo.AutoMapper;

namespace IFES.POO2.Ipharm.PortalAdministrativo
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