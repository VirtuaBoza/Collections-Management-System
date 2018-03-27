using CoraCorpCM.App.Membership;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.Users.Commands.RegisterUser.Factory
{
    public interface IUserFactory
    {
        ApplicationUser Create(Museum museum, string email, string firstName, string lastName);
    }
}
