using CoraCorpCM.App.Interfaces.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace CoraCorpCM.App.Subgenres.Queries.GetSubgenreList
{
    public class GetSubgenreListQuery : IGetSubgenreListQuery
    {
        private readonly ISubgenreRepository subgenreRepository;

        public GetSubgenreListQuery(ISubgenreRepository subgenreRepository)
        {
            this.subgenreRepository = subgenreRepository;
        }

        public List<SubgenreModel> Execute(int museumId)
        {
            var subgenres = subgenreRepository.GetAll()
                .Where(s => s.MuseumId == museumId)
                .Select(s => new SubgenreModel
                {
                    Id = s.Id,
                    Name = s.Name
                });

            return subgenres.ToList();
        }
    }
}
