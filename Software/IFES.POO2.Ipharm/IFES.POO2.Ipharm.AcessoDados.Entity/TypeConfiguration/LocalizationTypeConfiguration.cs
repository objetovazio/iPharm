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

        }

        protected override void TableFieldConfiguration()
        {
            // Key
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            ////Foreign Key
            //Property(p => p.User_Id)
            //    .IsRequired();


            //Other Fields
            Property(p => p.Latitude)
                .IsRequired();



            Property(p => p.Longitude)
                .IsRequired();
        }

        protected override void PrimaryKeyConfiguration()
        {
            HasKey(p => p.Id);
        }

        protected override void ForeignKeyConfiguration()
        {
            HasRequired(p => p.User)
                .WithOptional(u => u.Localization)
                .WillCascadeOnDelete(true);
        }

    }
}
