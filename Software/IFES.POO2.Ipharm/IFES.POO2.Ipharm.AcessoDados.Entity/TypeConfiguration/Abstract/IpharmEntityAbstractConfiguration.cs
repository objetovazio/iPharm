using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFES.POO2.Ipharm.AcessoDados.Entity.TypeConfiguration
{
    public abstract class IpharmEntityAbstractConfiguration<T> : EntityTypeConfiguration<T>
        where T : class
    {
        public IpharmEntityAbstractConfiguration()
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
