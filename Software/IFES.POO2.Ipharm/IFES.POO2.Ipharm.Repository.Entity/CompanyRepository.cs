using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFES.POO2.Ipharm.Domain;
using IFES.POO2.Ipharm.Repository.Common;
using IFES.POO2.Ipharm.Repository.Common.Entity.Common;

namespace IFES.POO2.Ipharm.Repository.Entity
{
    public class CompanyRepository : GenericRepositoryEntity<Company, int>
    {
        public CompanyRepository(DbContext context) : base(context) {}

        public List<Company> Select() => context.Set<Company>().Include("User").ToList();
        
    }
}
