namespace CoraCorpCM.App.Museums.Queries
{
    public interface IGetMuseumIdForUserIdQuery
    {
        int Execute(string userId);
    }
}
