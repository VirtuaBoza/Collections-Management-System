using System.Linq;

namespace CoraCorpCM.App.Interfaces.Persistence
{
    public interface IReadOnlyRepository<TEntity, TId> 
    {
        IQueryable<TEntity> GetAll();

        TEntity Get(TId id);
    }
}
