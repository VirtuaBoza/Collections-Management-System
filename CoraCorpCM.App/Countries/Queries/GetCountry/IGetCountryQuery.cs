using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.Countries.Queries.GetCountry
{
    public interface IGetCountryQuery
    {
        Country Execute(int id);
    }
}
