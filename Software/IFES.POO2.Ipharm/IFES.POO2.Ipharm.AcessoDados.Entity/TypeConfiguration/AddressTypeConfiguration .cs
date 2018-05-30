using IFES.POO2.Ipharm.Domain;

namespace IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration
{
    class AddressTypeConfiguration : IpharmEntityAbstractConfiguration<Address>
    {
        protected override void TableNameConfiguration()
        {
            //ToTable("ADDRESS");
        }

        protected override void TableFieldConfiguration()
        {
            // Key
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            //.HasColumnName("ADD_IdAddress");

            //Foreign Key
            //Property(p => p.User_Id)
                //.IsRequired();
                //.HasColumnName("USE_IdUsers");

            //Other Fields
            Property(p => p.Street_Name)
                .IsRequired();
            //.HasColumnName("ADD_Street_Name");

            Property(p => p.Neighborhood)
                .IsRequired();
            //.HasColumnName("ADD_Neighborhood");

            Property(p => p.City)
                .IsRequired();
            //.HasColumnName("ADD_City");

            Property(p => p.State)
                .IsRequired();
            //.HasColumnName("ADD_State");

            Property(p => p.Country)
                .IsRequired();
            //.HasColumnName("ADD_Country");

            Property(p => p.CEP)
                .IsRequired();
            //.HasColumnName("ADD_CEP");

            Property(p => p.Details)
                .IsRequired();
                //.HasColumnName("ADD_Details");
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
