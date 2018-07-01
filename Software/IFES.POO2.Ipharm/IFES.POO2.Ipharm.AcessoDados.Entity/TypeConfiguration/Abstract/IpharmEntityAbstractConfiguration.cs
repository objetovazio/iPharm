using System.Data.Entity.ModelConfiguration;

namespace IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration.Abstract
{
    public abstract class IpharmEntityAbstractConfiguration<T> : EntityTypeConfiguration<T>
        where T : class
    {
        protected IpharmEntityAbstractConfiguration()
        {
            TableNameConfiguration();
            TableFieldConfiguration();
            PrimaryKeyConfiguration();
            ForeignKeyConfiguration();
        }

        protected abstract void TableNameConfiguration();
        protected abstract void TableFieldConfiguration();
        protected abstract void PrimaryKeyConfiguration();
        protected abstract void ForeignKeyConfiguration();
    }
}
