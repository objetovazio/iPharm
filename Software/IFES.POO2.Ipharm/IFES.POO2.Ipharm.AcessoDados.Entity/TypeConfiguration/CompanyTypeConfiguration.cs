using IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration;
using IFES.POO2.Ipharm.Domain;
using System.Data.Entity.ModelConfiguration;

namespace IFES.POO2.Ipharm.AcessoDados.Entity.Context
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
                .IsRequired();

            Property(p => p.CompanyName)
                .IsRequired();
        }

        protected override void PrimaryKeyConfiguration()
        {
            HasKey(p => p.Id);
        }

        protected override void ForeignKeyConfiguration()
        {
            HasRequired(p => p.User)
                .WithOptional(u => u.Company);
        }
    }
}