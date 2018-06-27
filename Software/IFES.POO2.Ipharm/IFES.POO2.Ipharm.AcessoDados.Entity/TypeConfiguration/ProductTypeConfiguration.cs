using IFES.POO2.Ipharm.Domain;

namespace IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration
{
    public class ProductTypeConfiguration : IpharmEntityAbstractConfiguration<Product>
    {
        protected override void TableNameConfiguration()
        {
            ToTable("Product");
        }

        protected override void TableFieldConfiguration()
        {
            // Key
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            //Other Fields
            Property(p => p.Name)
                .IsRequired();

            Property(p => p.Value)
                .IsRequired();

            Property(p => p.Description)
                .IsRequired();

            Property(p => p.HasControl)
                .IsRequired();

            Property(p => p.IsDeleted)
                .IsRequired();
        }

        protected override void PrimaryKeyConfiguration()
        {
            HasKey(p => p.Id);
        }

        protected override void ForeignKeyConfiguration()
        {
            HasRequired(p => p.Company)
                .WithMany(com => com.Products);
        }
    }
}