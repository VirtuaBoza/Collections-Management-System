using System.Collections.Generic;

namespace CoraCorpCM.Application.FundingSources.Queries.GetFundingSourceList
{
    public interface IGetFundingSourceListQuery
    {
        List<FundingSourceModel> Execute(int museumId);
    }
}
