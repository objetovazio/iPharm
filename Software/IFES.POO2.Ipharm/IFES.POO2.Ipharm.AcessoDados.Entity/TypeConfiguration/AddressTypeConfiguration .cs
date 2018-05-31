using IFES.POO2.Ipharm.Domain;

namespace IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration
{
    public class AddressTypeConfiguration : IpharmEntityAbstractConfiguration<Address>
    {
        protected override void TableNameConfiguration()
        {
            ToTable("Address");
        }

        protected override void TableFieldConfiguration()
        {
            // Key
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            
            //Other Fields
            Property(p => p.Street_Name)
                .IsRequired();

            Property(p => p.Neighborhood)
                .IsRequired();

            Property(p => p.City)
                .IsRequired();

            Property(p => p.State)
                .IsRequired();

            Property(p => p.Country)
                .IsRequired();

            Property(p => p.CEP)
                .IsRequired();

            Property(p => p.Details)
                .IsRequired();
        }

        protected override void PrimaryKeyConfiguration()
        {
            HasKey(p => p.Id);
        }

        protected override void ForeignKeyConfiguration()
        {
            HasRequired(add => add.User)
                .WithMany(us => us.Addresses);
        }
    }
}
