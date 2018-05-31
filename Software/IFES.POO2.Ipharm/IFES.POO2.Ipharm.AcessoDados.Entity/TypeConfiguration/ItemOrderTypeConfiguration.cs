using IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration;
using IFES.POO2.Ipharm.Domain;
using System.Data.Entity.ModelConfiguration;

namespace IFES.POO2.Ipharm.AcessoDados.Entity.Context
{
    public class ItemOrderTypeConfiguration : IpharmEntityAbstractConfiguration<ItemOrder>
    {
        protected override void TableNameConfiguration()
        {
            ToTable("ItemOrder");
        }

        protected override void ForeignKeyConfiguration()
        {
            HasRequired(p => p.Order)
                .WithRequiredDependent();

            HasRequired(p => p.Product)
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
            Property(p => p.ItemValue)
                .IsRequired();

            Property(p => p.ItemDescount)
                .IsRequired();
        }
    }
}