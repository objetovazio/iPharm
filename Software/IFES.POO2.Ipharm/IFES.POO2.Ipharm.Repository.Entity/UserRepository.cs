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

        /// <summary>
        /// Traz um User do login enviado
        /// </summary>
        /// <returns>Um User</returns>
        public List<User> SelectAdmins()
        {
            return context.Set<User>().Where(user => user.IsAdministrator).ToList();
        }

        public bool IsActive(string login, bool isAdmin)
        {
            var user = SelectByLogin(login);
            if (user != null) return isAdmin ? user.IsActive && user.IsAdministrator : user.IsActive;
            return false;
        }

        public bool Exists(string login)
        {
            return Select().Any(u => u.Login.Equals(login));
        }
    }
}
