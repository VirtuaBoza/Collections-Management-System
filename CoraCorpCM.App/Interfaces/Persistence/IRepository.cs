using System.Linq;

namespace CoraCorpCM.App.Interfaces.Persistence
{
    public interface IRepository<TEntity, TId>
    {
        IQueryable<TEntity> GetAll();

        TEntity Get(TId id);

        void Add(TEntity entity);

        void Remove(TEntity entity);
    }
}
