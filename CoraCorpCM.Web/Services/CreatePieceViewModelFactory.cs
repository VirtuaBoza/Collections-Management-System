using CoraCorpCM.App.Countries.Queries;
using CoraCorpCM.App.Museums.Queries;
using CoraCorpCM.Web.ViewModels.CollectionViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace CoraCorpCM.Web.Services
{
    public class CreatePieceViewModelFactory : ICreatePieceViewModelFactory
    {
        private readonly IGetMuseumIdForUserIdQuery museumIdQuery;
        private readonly IGetCountryListQuery countryListQuery;

        public CreatePieceViewModelFactory(
            IGetMuseumIdForUserIdQuery museumIdQuery,
            IGetCountryListQuery countryListQuery
            //,
            //IGetMediumListQuery mediumListQuery
            )
        {
            this.museumIdQuery = museumIdQuery;
            this.countryListQuery = countryListQuery;
        }

        public CreatePieceViewModel Create(string userId)
        {
            var viewModel = new CreatePieceViewModel();

            var museumId = museumIdQuery.Execute(userId);

            var countries = countryListQuery.Execute();

            viewModel.Countries = countries.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            return viewModel;
        }
    }
}
