using System.Collections.Generic;

namespace CoraCorpCM.App.Genres.Queries.GetGenreList
{
    public interface IGetGenreListQuery
    {
        List<GenreModel> Execute(int museumId);
    }
}
