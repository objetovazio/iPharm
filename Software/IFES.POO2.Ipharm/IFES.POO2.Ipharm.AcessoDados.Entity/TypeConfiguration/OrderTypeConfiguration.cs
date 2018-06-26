using IFES.POO2.Ipharm.Domain;

namespace IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration
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
                .WithMany(c => c.Orders)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Person)
                .WithMany(c => c.Orders);

            HasRequired(p => p.Address);
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