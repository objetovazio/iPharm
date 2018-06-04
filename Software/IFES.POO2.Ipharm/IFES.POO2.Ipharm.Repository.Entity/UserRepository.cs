using IFES.POO2.Ipharm.AcessoDados.Entity.Context;
using IFES.POO2.Ipharm.Domain;
using IFES.POO2.Ipharm.Repository.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFES.POO2.Ipharm.Repository.Entity
{
    public class UserRepository : GenericRepositoryEntity<User, Guid>
    {
        public UserRepository(IpharmContext context) 
            : base(context) {}

        /// <summary>
        /// Traz um User do login enviado
        /// </summary>
        /// <returns>Um User</returns>
        public User SelectByLogin(string login)
        {
            return context.Set<User>().FirstOrDefault(u => u.Login.Equals(login));
        }

        
    }
}
