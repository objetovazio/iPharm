using IFES.POO2.Ipharm.Domain;

namespace IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration
{
    class UserTypeConfiguration : IpharmEntityAbstractConfiguration<User>
    {
        protected override void TableNameConfiguration()
        {
            ToTable("USERS");
        }

        protected override void TableFieldConfiguration()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("USE_IdUsers");

            Property(p => p.Login)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("USE_Login");

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("USE_Name");

            Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("USE_Email");

            Property(p => p.Phone)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnName("USE_Phone");

            Property(p => p.IsActive)
                .IsRequired()
                .HasColumnName("USE_IsActive");

            Property(p => p.IsAdministrator)
                .IsRequired()
                .HasColumnName("USE_IsAdministrator");

        }

        protected override void PrimaryKeyConfiguration()
        {
            HasKey(p => p.Id);
        }

        protected override void ForeignKeyConfiguration()
        {
        }


    }
}
