using System.Linq;
using CoraCorpCM.Application.Countries.Queries;
using CoraCorpCM.Web.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoraCorpCM.Web.Services.Account
{
    public class RegisterViewModelFactory : IRegisterViewModelFactory
    {
        private readonly IGetCountryListQuery getCountryListQuery;

        public RegisterViewModelFactory(IGetCountryListQuery getCountryListQuery)
        {
            this.getCountryListQuery = getCountryListQuery;
        }

        public RegisterViewModel Create()
        {
            var viewModel = new RegisterViewModel();

            var countries = getCountryListQuery.Execute();

            viewModel.Countries = countries
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });

            return viewModel;
        }
    }
}
