using CoraCorpCM.Application.Models;

namespace CoraCorpCM.Application.FundingSources.Commands.CreateFundingSource.Factory
{
    public interface IFundingSourceFactory
    {
        FundingSource Create(string name, int museumId);
    }
}
