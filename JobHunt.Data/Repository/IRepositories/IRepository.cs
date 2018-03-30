using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace JobHunt.Data.Repository.IRepositories
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces", Justification = "IDbRepository will be used in reflection to determine repository without knowing TEntity")]
    public interface IRepository
    {
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "The name Repository is self explain it was a collection, but RepositoryCollection sounds like 'collection of repository' (repositories) which has different meaning.")]
    public interface IRepository<T> : IRepository where T : class
    {
        /// <summary>
        /// Get all record status (include active and inactive)
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetWithDelete();
        IQueryable<T> GetQuerry();


        /// <summary>
        /// Get item with any record status
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get(int key);

        IQueryable<T> GetById(Guid Id);
        /// <summary>
        /// Insert without commit
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Add(T entity);

        /// <summary>
        /// Update without commit
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Update(T entity);

        /// <summary>
        /// Sort delete without commit
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
    }
}
