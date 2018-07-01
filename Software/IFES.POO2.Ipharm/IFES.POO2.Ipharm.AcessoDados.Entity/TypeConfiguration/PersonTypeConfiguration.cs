using IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration.Abstract;
using IFES.POO2.Ipharm.Domain;

namespace IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration
{
    public class PersonTypeConfiguration : IpharmEntityAbstractConfiguration<Person>
    {
        protected override void TableNameConfiguration()
        {
            ToTable("Person");
        }

        protected override void TableFieldConfiguration()
        {
            // Key
            Property(p => p.Id)
                .IsRequired();

            //Other Fields
            Property(p => p.Cpf)
                .IsRequired();

            Property(p => p.Birthday)
                .IsRequired();
        }

        protected override void PrimaryKeyConfiguration()
        {
            HasKey(p => p.Id);
        }

        protected override void ForeignKeyConfiguration()
        {
            HasRequired(p => p.User)
                .WithOptional(u => u.Person);
        }
    }
}