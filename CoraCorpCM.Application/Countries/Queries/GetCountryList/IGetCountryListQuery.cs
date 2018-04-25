using System.Collections.Generic;

namespace CoraCorpCM.Application.Countries.Queries
{
    public interface IGetCountryListQuery
    {
        List<CountryModel> Execute();
    }
}
