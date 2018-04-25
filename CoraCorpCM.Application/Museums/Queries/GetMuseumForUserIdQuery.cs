using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Common.Membership;
using Microsoft.AspNetCore.Identity;

namespace CoraCorpCM.Application.Museums.Queries
{
    public class GetMuseumForUserIdQuery : IGetMuseumForUserIdQuery
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMuseumRepository museumRepository;

        public GetMuseumForUserIdQuery(
            UserManager<ApplicationUser> userManager,
            IMuseumRepository museumRepository)
        {
            this.userManager = userManager;
            this.museumRepository = museumRepository;
        }

        public MuseumModel Execute(string userId)
        {
            var user = userManager.FindByIdAsync(userId).Result;

            var museum = museumRepository.Get(user.MuseumId);

            var museumModel = new MuseumModel
            {
                Id = museum.Id,
                Name = museum.Name,
                ShortName = museum.ShortName,
                Address1 = museum.Address1,
                Address2 = museum.Address2,
                City = museum.City,
                State = museum.State,
                ZipCode = museum.ZipCode,
                CountryId = museum.Country.Id,
                RecordCount = museum.RecordCount
            };

            return museumModel;
        }
    }
}
