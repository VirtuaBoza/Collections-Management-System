using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Application.Interfaces.Persistence
{
    public interface ICountryRepository : IReadOnlyRepository<Country,int>
    {
    }
}
