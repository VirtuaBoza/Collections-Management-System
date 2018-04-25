using CoraCorpCM.Common.Membership;

namespace CoraCorpCM.Application.Users.Commands.RegisterUser.Factory
{
    public interface IUserFactory
    {
        ApplicationUser Create(int museumId, string email, string firstName, string lastName);
    }
}
