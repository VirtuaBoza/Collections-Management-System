namespace CoraCorpCM.Application.Artists.Commands.CreateArtist
{
    public interface ICreateArtistCommand
    {
        int Execute(CreateArtistModel model);
    }
}
