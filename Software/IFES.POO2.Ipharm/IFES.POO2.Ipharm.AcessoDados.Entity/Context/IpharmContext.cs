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
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Localization> Localizations { get; set; }
        public DbSet<ItemOrder> ItemsOrder { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        public IpharmContext()
        {
            //Configuration.LazyLoadingEnabled = false; // Para não carregar objetos relacionados sem necessidade
            //Configuration.ProxyCreationEnabled = false; // Para não criar um proxy de objeto (Simula uma cópia do meu objeto original)
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressTypeConfiguration());
            modelBuilder.Configurations.Add(new CompanyTypeConfiguration());
            modelBuilder.Configurations.Add(new LocalizationTypeConfiguration());
            modelBuilder.Configurations.Add(new ItemOrderTypeConfiguration());
            modelBuilder.Configurations.Add(new OrderTypeConfiguration());
            modelBuilder.Configurations.Add(new PaymentTypeConfiguration());
            modelBuilder.Configurations.Add(new PaymentMethodConfiguration());
            modelBuilder.Configurations.Add(new PersonTypeConfiguration());
            modelBuilder.Configurations.Add(new ProductTypeConfiguration());
            modelBuilder.Configurations.Add(new UserTypeConfiguration());
            modelBuilder.Configurations.Add(new ReviewTypeConfiguration());
        }

    }
}
