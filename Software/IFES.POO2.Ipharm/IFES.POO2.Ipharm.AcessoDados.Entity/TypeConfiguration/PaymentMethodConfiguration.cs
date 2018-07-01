using IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration.Abstract;
using IFES.POO2.Ipharm.Domain;

namespace IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration
{
    public class PaymentMethodConfiguration : IpharmEntityAbstractConfiguration<PaymentMethod>
    {
        protected override void TableNameConfiguration()
        {
            ToTable("PaymentMethod");
        }

        protected override void TableFieldConfiguration()
        {
            // Key
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            //Other Fields
            Property(p => p.PaymentOption)
                .IsRequired();

            Property(p => p.Description)
                .IsRequired();

            Property(p => p.CardNumber)
                .IsOptional();

            Property(p => p.SecurityCode)
                .IsOptional();
        }

        protected override void PrimaryKeyConfiguration()
        {
            HasKey(p => p.Id);
        }

        protected override void ForeignKeyConfiguration()
        {
            HasRequired(add => add.Person)
                .WithMany(p => p.PaymentMethods)
                .WillCascadeOnDelete(false);
        }
    }
}