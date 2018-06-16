namespace CoraCorpCM.Application.Genres.Commands.CreateGenre
{
    public interface ICreateGenreCommand
    {
        int Execute(CreateGenreModel model);
    }
}
