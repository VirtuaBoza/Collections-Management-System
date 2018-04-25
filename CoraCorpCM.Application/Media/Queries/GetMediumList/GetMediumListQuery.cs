using CoraCorpCM.Application.Interfaces.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace CoraCorpCM.Application.Media.Queries.GetMediumList
{
    public class GetMediumListQuery : IGetMediumListQuery
    {
        private readonly IMediumRepository mediumRepository;

        public GetMediumListQuery(IMediumRepository mediumRepository)
        {
            this.mediumRepository = mediumRepository;
        }

        public List<MediumModel> Execute(int museumId)
        {
            var media = mediumRepository.GetAll()
                .Where(m => m.MuseumId == museumId)
                .Select(m => new MediumModel
                {
                    Id = m.Id,
                    Name = m.Name
                });

            return media.ToList();
        }
    }
}
