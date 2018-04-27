namespace CoraCorpCM.Application.Museums.Queries
{
    public interface IGetMuseumForUserIdQuery
    {
        MuseumModel Execute(string userId);
    }
}
