using System.Collections.Generic;

namespace CoraCorpCM.Application.Genres.Queries.GetGenreList
{
    public interface IGetGenreListQuery
    {
        List<GenreModel> Execute(int museumId);
    }
}
