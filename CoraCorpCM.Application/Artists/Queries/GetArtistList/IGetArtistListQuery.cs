using System.Collections.Generic;

namespace CoraCorpCM.Application.Artists.Queries.GetArtistList
{
    public interface IGetArtistListQuery
    {
        List<ArtistModel> Execute(int museumId);
    }
}
