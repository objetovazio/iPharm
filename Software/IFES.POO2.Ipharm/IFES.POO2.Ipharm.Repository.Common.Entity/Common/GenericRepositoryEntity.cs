﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IFES.POO2.Ipharm.Repository.Common.Entity.Common
{
    public class GenericRepositoryEntity<T, TKey> : IGenericRepository<T, TKey>
        where T : class
    {
        protected DbContext context;

        public GenericRepositoryEntity(DbContext context) => this.context = context;

        /// <summary>
        /// Deleta a entidade enviada como parametro do banco de dados.
        /// </summary>
        /// <param name="entity">Entidade a ser removida</param>
        public void Delete(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }

        /// <summary>
        /// Deleta a entidade utilizando o id enviado como parametro
        /// </summary>
        /// <param name="entityKey">Id da entidade que será removida</param>
        public void DeleteById(TKey entityKey) => this.Delete(SelectById(entityKey));

        /// <summary>
        /// Insere uma entidade no banco
        /// </summary>
        /// <param name="entity">Entidade que será inserida</param>
        public void Insert(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        /// <summary>
        /// Traz todos os elementos de um tipo
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public List<T> Select() => context.Set<T>().ToList();

        /// <summary>
        /// Traz um elemento que pertença ao Id enviado como parametro
        /// </summary>
        /// <param name="id">Id do elemento</param>
        /// <returns>Elemento T que pertence ao Id</returns>
        public T SelectById(TKey id) => context.Set<T>().Find(id);

        /// <summary>
        /// Atualiza o elemento enviado como parametro no banco de dados
        /// </summary>
        /// <param name="entity">Elemento T que será atualizado</param>
        public void Update(T entity)
        {
            //context.Set<T>().AddOrUpdate(entity);
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
            context = null;
        }
    }
}
