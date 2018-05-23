using IFES.POO2.Ipharm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration
{
    class LocalizationTypeConfiguration : IpharmEntityAbstractConfiguration<Localization>
    {
        protected override void TableNameConfiguration()
        {
            ToTable("LOCALIZATION");
        }

        protected override void TableFieldConfiguration()
        {
            // Key
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("LOC_IdLocalization");

            //Foreign Key
            Property(p => p.IdUser)
                .IsRequired()
                .HasColumnName("USE_IdUsers");

            //Other Fields
            Property(p => p.Latitude)
                .IsRequired()
                .HasColumnName("LOC_Latitude");

            Property(p => p.Longitude)
                .IsRequired()
                .HasColumnName("LOC_Longitude");
        }

        protected override void PrimaryKeyConfiguration()
        {
            HasKey(p => p.Id);
        }

        protected override void ForeignKeyConfiguration()
        {
            HasRequired(loc => loc.User)
                .WithOptional(us => us.Localization);
        }

    }
}
