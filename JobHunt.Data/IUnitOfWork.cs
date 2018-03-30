using System;
using JobHunt.Data.Entities;
using JobHunt.Data.Repository.IRepositories;

namespace JobHunt.Data
{
    public interface IUnitOfWork : IDisposable
    {
        #region Repository
        IRepository<T> Repository<T>() where T : EntityBase;
        #endregion

        void CommitTransaction();
        void StartTransaction();
        void Commit();
    }
}
