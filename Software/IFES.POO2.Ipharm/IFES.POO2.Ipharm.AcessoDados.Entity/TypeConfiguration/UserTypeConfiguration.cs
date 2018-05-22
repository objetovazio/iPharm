using IFES.POO2.Ipharm.Domain;

namespace IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration
{
    class UserTypeConfiguration<TUser> : IpharmEntityAbstractConfiguration<TUser>
        where TUser : User
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
                .HasColumnName("USE_USERS");

            Property(p => p.Login)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("USE_LOGIN");

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("USE_NAME");

            Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("USE_EMAIL");

            Property(p => p.Phone)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnName("USE_PHONE");

            Property(p => p.IsActive)
                .HasColumnName("USE_ISACTIVE");
        }

        protected override void PrimaryKeyConfiguration()
        {
            HasKey(p => p.Id);
        }

        protected override void ForeignKeyConfiguration()
        {
            HasOptional(opt => opt.Localization) // Localização é opcional
                .WithRequired(a => (TUser)a.User); // Mas não consegue salvar uma localização, se não existir um usuário
        }


    }
}
