using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Application.FundingSources.Commands.CreateFundingSource.Factory
{
    public class FundingSourceFactory : IFundingSourceFactory
    {
        public FundingSource Create(string name, int museumId)
        {
            var fundingSource = new FundingSource();
            fundingSource.Name = name;
            fundingSource.MuseumId = museumId;

            return fundingSource;
        }
    }
}
