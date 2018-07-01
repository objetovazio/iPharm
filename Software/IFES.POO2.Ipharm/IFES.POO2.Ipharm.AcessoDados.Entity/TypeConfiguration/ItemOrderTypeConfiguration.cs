using IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration.Abstract;
using IFES.POO2.Ipharm.Domain;

namespace IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration
{
    public class ItemOrderTypeConfiguration : IpharmEntityAbstractConfiguration<ItemOrder>
    {
        protected override void TableNameConfiguration()
        {
            ToTable("ItemOrder");
        }

        protected override void ForeignKeyConfiguration()
        {
            HasRequired(io => io.Order)
                .WithMany(o => o.ItemsOrder);

            HasRequired(io => io.Product)
                .WithMany(prod => prod.ItemOrders);
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