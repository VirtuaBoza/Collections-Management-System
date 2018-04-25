using System.Linq;

namespace CoraCorpCM.Application.Interfaces.Persistence
{
    public interface IReadOnlyRepository<TEntity, TId> 
    {
        IQueryable<TEntity> GetAll();

        TEntity Get(TId id);
    }
}
