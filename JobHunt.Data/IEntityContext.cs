using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace JobHunt.Data
{
    public interface IEntityContext : IDisposable
    {
        int SaveChanges();
        DbSet<T> Set<T>() where T : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
