using CoraCorpCM.App.Interfaces.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace CoraCorpCM.App.Artists.Queries.GetArtistList
{
    public class GetArtistListQuery : IGetArtistListQuery
    {
        private readonly IArtistRepository artistRepository;

        public GetArtistListQuery(IArtistRepository artistRepository)
        {
            this.artistRepository = artistRepository;
        }

        public List<ArtistModel> Execute(int museumId)
        {
            var artists = artistRepository.GetAll()
                .Where(a => a.MuseumId == museumId)
                .Select(a => new ArtistModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    AlsoKnownAs = a.AlsoKnownAs
                });

            return artists.ToList();
        }
    }
}
