using System;
using System.Linq;
using System.Web.Security;
using JobHunt.Data.Entities;
using JobHunt.Data.Repository.IRepositories;
using EntityState = System.Data.Entity.EntityState;

namespace JobHunt.Data.Repository.Implements
{
    public class Repository<T> : IRepository<T>
        where T : EntityBase
    {
        protected readonly IEntityContext _context;

        protected readonly string _currentUser;

        public Repository(IEntityContext context)
        {
            //var user = Membership.GetUser();
            //if (user != null)
            //{
            //    _currentUser = user.UserName;
            //}
            //else
            //{
            //    _currentUser = string.Empty;
            //}
            _context = context;
        }

        public IQueryable<T> GetWithDelete()
        {
            return _context.Set<T>().Where(record => !record.IsDelete);
        }

        public IQueryable<T> GetQuerry()
        {
            return _context.Set<T>().AsQueryable();
        }


        public T Get(int key)
        {
            var record = _context.Set<T>().Find(key);

            if (record != null && record.IsDelete)
            {
                record = null;
            }

            return record;
        }

        public IQueryable<T> GetById(Guid Id)
        {
           return _context.Set<T>().AsQueryable().Where(e => e.Id == Id);
        }


        public virtual T Add(T entity)
        {
            entity.UpdAt = entity.InsAt = DateTime.Now;
            entity.InsBy = entity.UpdBy = _currentUser;

            entity.IsDelete = false;

            _context.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public virtual T Update(T entity)
        {
            entity.UpdAt = DateTime.Now;
            entity.UpdBy = _currentUser;
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual void Delete(T entity)
        {
            entity.IsDelete = true;
            entity.UpdAt = DateTime.Now;
            entity.UpdBy = _currentUser;
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
