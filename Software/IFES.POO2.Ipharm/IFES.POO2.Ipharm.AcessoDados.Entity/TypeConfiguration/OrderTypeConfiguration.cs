using IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration;
using IFES.POO2.Ipharm.Domain;
using System.Data.Entity.ModelConfiguration;

namespace IFES.POO2.Ipharm.AcessoDados.Entity.Context
{
    public class OrderTypeConfiguration : IpharmEntityAbstractConfiguration<Order>
    {
        protected override void TableNameConfiguration()
        {
            ToTable("Order");
        }

        protected override void ForeignKeyConfiguration()
        {
            HasRequired(p => p.Company)
                .WithRequiredDependent();
                
            HasRequired(p => p.Person)
                .WithRequiredDependent();

            HasRequired(p => p.Address)
                .WithRequiredDependent();
        }

        protected override void PrimaryKeyConfiguration()
        {
            HasKey(p => p.Id);
        }

        protected override void TableFieldConfiguration()
        {
            // Key
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            //Other Fields
            Property(p => p.ValueOrder)
                .IsRequired();

            Property(p => p.OrderStatus)
                .IsRequired();
        }

    }
}