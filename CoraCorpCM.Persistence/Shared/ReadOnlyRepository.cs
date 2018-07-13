using CoraCorpCM.Application.Interfaces.Persistence;
using System;
using System.Linq;
using CoraCorpCM.Application.Models;

namespace CoraCorpCM.Persistence.Shared
{
    public class ReadOnlyRepository<TEntity, TId> : IReadOnlyRepository<TEntity, TId>
        where TEntity : class, IEntity<TId>
        where TId : IEquatable<TId>
    {
        private readonly ApplicationDbContext context;

        public ReadOnlyRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public TEntity Get(TId id)
        {
            return context.Set<TEntity>().SingleOrDefault(x => x.Id.Equals(id));
        }

        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }
    }
}
