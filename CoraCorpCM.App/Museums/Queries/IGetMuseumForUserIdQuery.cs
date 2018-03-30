namespace CoraCorpCM.App.Museums.Queries
{
    public interface IGetMuseumForUserIdQuery
    {
        MuseumModel Execute(string userId);
    }
}
