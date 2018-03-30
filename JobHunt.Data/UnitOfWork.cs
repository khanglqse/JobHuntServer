using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Transactions;
using JobHunt.Data;
using JobHunt.Data.Entities;
using JobHunt.Data.Repository.IRepositories;
using JobHunt.Data.Repository.Implements;

namespace JobHunt.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, IRepository> cachedRepositories = new Dictionary<Type, IRepository>();

        private readonly IEntityContext _dbContext;

        private TransactionScope _transaction;

        public UnitOfWork(IEntityContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Repository


        #endregion

        public void StartTransaction()
        {
            _transaction = new TransactionScope();
        }

        public IRepository<T> Repository<T>() where T : EntityBase
        {
            var type = typeof(T);
            if (cachedRepositories.ContainsKey(type))
            {
                return cachedRepositories[type] as IRepository<T>;
            }
            else
            {
                var repo = new Repository<T>(_dbContext);
                cachedRepositories[type] = repo;
                return repo;
            }
        }

        public void CommitTransaction()
        {
            _transaction.Complete();
        }

        public void Commit()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine(@"- Property: ""{0}"", Error: ""{1}""", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void Dispose()
        {
            if (_transaction != null) _transaction.Dispose();
            _dbContext.Dispose();
        }
    }
}
