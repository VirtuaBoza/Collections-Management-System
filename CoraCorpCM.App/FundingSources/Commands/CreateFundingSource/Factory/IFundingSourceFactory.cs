using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.FundingSources.Commands.CreateFundingSource.Factory
{
    public interface IFundingSourceFactory
    {
        FundingSource Create(string name, int museumId);
    }
}
