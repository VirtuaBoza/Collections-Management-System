using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Application.FundingSources.Commands.CreateFundingSource.Factory
{
    public interface IFundingSourceFactory
    {
        FundingSource Create(string name, int museumId);
    }
}
