using IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration.Abstract;
using IFES.POO2.Ipharm.Domain;

namespace IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration
{
    internal class CompanyTypeConfiguration : IpharmEntityAbstractConfiguration<Company>
    {
        protected override void TableNameConfiguration()
        {
            ToTable("Company");
        }

        protected override void TableFieldConfiguration()
        {
            // Key
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            //Other Fields
            Property(p => p.Cnpj)
                .HasMaxLength(18)
                .IsRequired();
        }

        protected override void PrimaryKeyConfiguration()
        {
            HasKey(p => p.Id);
        }

        protected override void ForeignKeyConfiguration()
        {
            //HasRequired(p => p.User)
            //    .WithRequiredDependent(user => user.Company);
        }
    }
}