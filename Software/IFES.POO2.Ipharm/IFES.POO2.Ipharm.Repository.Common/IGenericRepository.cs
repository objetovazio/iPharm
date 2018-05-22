using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFES.POO2.Ipharm.Repository.Common
{
    public interface IGenericRepository<T, Key> where T : class
    {
        List<T> Select();
        T SelectById(Key id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(Key entity);
    }
}
