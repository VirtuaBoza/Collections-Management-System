namespace CoraCorpCM.App.Museums.Queries.GetMuseumId
{
    public interface IGetMuseumIdQuery
    {
        MuseumModel Execute(string userId);
    }
}
