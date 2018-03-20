using System.Linq;

namespace CoraCorpCM.App.Interfaces.Persistence
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        T Get(int id);

        void Add(T entity);

        void Remove(T entity);
    }
}
