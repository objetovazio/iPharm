using IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration.Abstract;
using IFES.POO2.Ipharm.Domain;

namespace IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration
{
    public class PaymentTypeConfiguration : IpharmEntityAbstractConfiguration<Payment>
    {
        protected override void TableNameConfiguration()
        {
            ToTable("Payment");
        }

        protected override void ForeignKeyConfiguration()
        {
            HasRequired(p => p.Order)
                .WithMany(c => c.Payments);

            HasRequired(p => p.PaymentMethod)
                .WithMany(pm => pm.Payments);
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
            Property(p => p.Value)
                .IsRequired();

            Property(p => p.Date)
               .IsRequired();

            Property(p => p.PaymentStatus)
               .IsRequired();
        }

        
    }
}