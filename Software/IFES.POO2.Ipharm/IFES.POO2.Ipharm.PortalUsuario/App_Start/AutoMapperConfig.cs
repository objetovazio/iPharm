using AutoMapper;
using IFES.POO2.Ipharm.PortalUsuario.AutoMapper;

namespace IFES.POO2.Ipharm.PortalUsuario
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