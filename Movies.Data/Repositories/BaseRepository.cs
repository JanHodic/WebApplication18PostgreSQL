using Microsoft.EntityFrameworkCore;
using Movies.Data.Data;
using Movies.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly MoviesDbContext context;
        protected readonly DbSet<TEntity> dbSet;

        public BaseRepository(MoviesDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }
        public void Delete(int id)
        {
            TEntity? entity = dbSet.Find(id);

            if (entity is null)
                return;

            try
            {
                dbSet.Remove(entity);
                this.context.SaveChanges();
            }
            catch
            {
                this.context.Entry(entity).State = EntityState.Unchanged;
                throw;
            }
        }

        public bool ExistsWith(int id)
        {
            var entity = dbSet.Find(id);
            if (entity is not null)
            context.Entry(entity).State = EntityState.Detached;
            return entity is not null;
        }

        public TEntity? FindById(int id)
        {
            return dbSet.Find(id);
        }

        public IList<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public TEntity Insert(TEntity entity)
        {
            var entityEntry = dbSet.Add(entity);
            context.SaveChanges();
            return entityEntry.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            var entityEntry = dbSet.Update(entity);
            context.SaveChanges();
            return entityEntry.Entity;
        }
    }
}
