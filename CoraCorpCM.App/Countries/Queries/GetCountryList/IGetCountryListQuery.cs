using System.Collections.Generic;

namespace CoraCorpCM.App.Countries.Queries
{
    public interface IGetCountryListQuery
    {
        List<CountryModel> Execute();
    }
}
