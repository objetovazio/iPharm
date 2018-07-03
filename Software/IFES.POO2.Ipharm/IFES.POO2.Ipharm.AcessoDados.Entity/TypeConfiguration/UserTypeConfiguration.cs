using IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration.Abstract;
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
                .HasMaxLength(15);

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
            HasOptional(user => user.Company)
                .WithRequired(company => company.User);

            HasOptional(user => user.Person)
                .WithRequired(company => company.User);
        }
    }
}
