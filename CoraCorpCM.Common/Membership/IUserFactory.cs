namespace CoraCorpCM.Common.Membership
{
    public interface IUserFactory
    {
        ApplicationUser Create(int museumId, string email, string firstName, string lastName);
    }
}
