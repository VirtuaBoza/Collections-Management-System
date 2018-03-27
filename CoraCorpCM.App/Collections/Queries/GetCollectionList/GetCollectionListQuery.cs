using CoraCorpCM.App.Interfaces.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace CoraCorpCM.App.Collections.Queries.GetCollectionList
{
    public class GetCollectionListQuery : IGetCollectionListQuery
    {
        private readonly ICollectionRepository collectionRepository;

        public GetCollectionListQuery(ICollectionRepository collectionRepository)
        {
            this.collectionRepository = collectionRepository;
        }

        public List<CollectionModel> Execute(int museumId)
        {
            var collections = collectionRepository.GetAll()
                .Where(c => c.MuseumId == museumId)
                .Select(c => new CollectionModel
                {
                    Id = c.Id,
                    Name = c.Name
                });

            return collections.ToList();
        }
    }
}
