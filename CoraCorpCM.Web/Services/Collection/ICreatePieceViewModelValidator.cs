using CoraCorpCM.Web.ViewModels.CollectionViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoraCorpCM.Web.Services.Collection
{
    public interface ICreatePieceViewModelValidator
    {
        void Validate(CreatePieceViewModel viewModel, ModelStateDictionary modelState);
    }
}
