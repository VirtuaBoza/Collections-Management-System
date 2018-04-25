using CoraCorpCM.Application.Interfaces.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace CoraCorpCM.Application.FundingSources.Queries.GetFundingSourceList
{
    public class GetFundingSourceListQuery : IGetFundingSourceListQuery
    {
        private readonly IFundingSourceRepository fundingSourceRepository;

        public GetFundingSourceListQuery(IFundingSourceRepository fundingSourceRepository)
        {
            this.fundingSourceRepository = fundingSourceRepository;
        }

        public List<FundingSourceModel> Execute(int museumId)
        {
            var fundingSources = fundingSourceRepository.GetAll()
                .Where(f => f.MuseumId == museumId)
                .Select(f => new FundingSourceModel
                {
                    Id = f.Id,
                    Name = f.Name
                });

            return fundingSources.ToList();
        }
    }
}
