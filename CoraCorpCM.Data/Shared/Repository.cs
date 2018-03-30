using System;
using System.Linq;
using CoraCorpCM.App.Interfaces.Persistence;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Data.Shared
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId> 
        where TEntity : class, IEntity<TId>
        where TId : IEquatable<TId>
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public virtual TEntity Get(TId id)
        {
            return context.Set<TEntity>()
                .Single(p => p.Id.Equals(id));
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }
    }
}
