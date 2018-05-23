using IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration;
using IFES.POO2.Ipharm.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFES.POO2.Ipharm.AcessoDados.Entity.Context
{
    public class IpharmContext : DbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Localization> Localizations { get; set; }
        DbSet<Address> Addresses { get; set; }

        public IpharmContext()
        {
            Configuration.LazyLoadingEnabled = false; // Para não carregar objetos relacionados sem necessidade
            Configuration.ProxyCreationEnabled = false; // Para não criar um proxy de objeto (Simula uma cópia do meu objeto original)
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserTypeConfiguration());
            modelBuilder.Configurations.Add(new LocalizationTypeConfiguration());
        }
    }
}
