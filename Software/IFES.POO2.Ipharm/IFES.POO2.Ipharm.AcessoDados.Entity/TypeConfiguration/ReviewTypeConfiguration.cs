﻿using IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration.Abstract;
using IFES.POO2.Ipharm.Domain;

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
                .WithRequiredDependent(o => o.Review);
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
