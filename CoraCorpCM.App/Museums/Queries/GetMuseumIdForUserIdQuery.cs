using CoraCorpCM.App.Interfaces.Persistence;

namespace CoraCorpCM.App.Museums.Queries
{
    public class GetMuseumIdForUserIdQuery : IGetMuseumIdForUserIdQuery
    {
        private readonly IUserRepository museumRepository;

        public GetMuseumIdForUserIdQuery(IUserRepository museumRepository)
        {
            this.museumRepository = museumRepository;
        }

        public int Execute(string userId)
        {
            var user = museumRepository.Get(userId);
            return user.MuseumId;
        }
    }
}
