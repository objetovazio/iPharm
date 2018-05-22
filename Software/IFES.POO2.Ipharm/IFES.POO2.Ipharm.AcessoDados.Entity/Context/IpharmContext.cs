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

        public IpharmContext()
        {
            Configuration.LazyLoadingEnabled = false; // Para não carregar objetos relacionados sem necessidade
            Configuration.ProxyCreationEnabled = false; // Para não criar um proxy de objeto (Simula uma cópia do meu objeto original)
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
//            modelBuilder.Configurations.Add(new AlbumTypeConfiguration());
        }
    }
}
