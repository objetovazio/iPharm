using IFES.POO2.Ipharm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration
{
    public class ReviewTypeConfiguration : IpharmEntityAbstractConfiguration<Review>
    {
        protected override void TableNameConfiguration()
        {
            ToTable("Review");
        }

        protected override void ForeignKeyConfiguration()
        {
            HasRequired(p => p.Company)
                .WithMany(c => c.Reviews);

            HasRequired(p => p.Order)
                .WithRequiredDependent();
        }

        protected override void PrimaryKeyConfiguration()
        {
            HasKey(p => p.Id);
        }

        protected override void TableFieldConfiguration()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(p => p.Stars)
                .IsRequired();

            Property(p => p.ReviewDetails)
                .IsRequired()
                .HasMaxLength(200);
        }

    }
}
