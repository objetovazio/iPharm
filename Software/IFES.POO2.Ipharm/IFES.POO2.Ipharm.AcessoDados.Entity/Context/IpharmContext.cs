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
        DbSet<Address> Addresses { get; set; }
        //DbSet<Company> Companies { get; set; }
        DbSet<Localization> Localizations { get; set; }
        //DbSet<ItemOrder> ItemsOrder { get; set; }
        //DbSet<Order> Orders { get; set; }
        //DbSet<Payment> Payments { get; set; }
        //DbSet<PaymentMethod> PaymentMethods { get; set; }
        //DbSet<Person> People { get; set; }
        //DbSet<Product> Products { get; set; }
        //DbSet<Review> Reviews { get; set; }
        DbSet<User> Users { get; set; }

        public IpharmContext()
        {
            Configuration.LazyLoadingEnabled = false; // Para não carregar objetos relacionados sem necessidade
            Configuration.ProxyCreationEnabled = false; // Para não criar um proxy de objeto (Simula uma cópia do meu objeto original)
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserTypeConfiguration());
            modelBuilder.Configurations.Add(new LocalizationTypeConfiguration());
            //modelBuilder.Configurations.Add(new AddressTypeConfiguration());
        }
    }
}
