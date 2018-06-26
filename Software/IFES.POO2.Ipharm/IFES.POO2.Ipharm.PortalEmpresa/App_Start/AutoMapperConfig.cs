using AutoMapper;
using IFES.POO2.Ipharm.PortalEmpresa.AutoMapper;

namespace IFES.POO2.Ipharm.PortalEmpresa
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