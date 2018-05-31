using IFES.POO2.Ipharm.Domain;

namespace IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration
{
    public class UserTypeConfiguration : IpharmEntityAbstractConfiguration<User>
    {
        protected override void TableNameConfiguration()
        {
            ToTable("Users");
        }

        protected override void TableFieldConfiguration()
        {
            Property(p => p.Id)
                .IsRequired();
                //.HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(p => p.Login)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("User_Login");

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.Phone)
                .IsRequired()
                .HasMaxLength(11);

            Property(p => p.IsActive)
                .IsRequired();

            Property(p => p.IsAdministrator)
                .IsRequired();
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
