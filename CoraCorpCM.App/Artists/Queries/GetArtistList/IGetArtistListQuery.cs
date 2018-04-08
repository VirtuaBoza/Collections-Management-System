using System.Collections.Generic;

namespace CoraCorpCM.App.Artists.Queries.GetArtistList
{
    public interface IGetArtistListQuery
    {
        List<ArtistModel> Execute(int museumId);
    }
}
