using CoraCorpCM.Domain.Models;
using System.Linq;

namespace CoraCorpCM.App.Interfaces.Persistence
{
    public interface IUserRepository
    {
        IQueryable<ApplicationUser> GetAll();

        ApplicationUser Get(string id);

        void Add(ApplicationUser entity, string password);

        void Remove(ApplicationUser entity);
    }
}
