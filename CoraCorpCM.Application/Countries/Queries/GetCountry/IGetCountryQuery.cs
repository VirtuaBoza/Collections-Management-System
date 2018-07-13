using CoraCorpCM.Application.Models;

namespace CoraCorpCM.Application.Countries.Queries.GetCountry
{
    public interface IGetCountryQuery
    {
        Country Execute(int id);
    }
}
