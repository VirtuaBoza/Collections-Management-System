using System.Collections.Generic;

namespace CoraCorpCM.App.FundingSources.Queries.GetFundingSourceList
{
    public interface IGetFundingSourceListQuery
    {
        List<FundingSourceModel> Execute(int museumId);
    }
}
