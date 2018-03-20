using CoraCorpCM.Web.ViewModels.CollectionViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CoraCorpCM.Web.Utilities
{
    public interface IModelValidator
    {
        bool Validate(ModelStateDictionary modelState, CreatePieceViewModel pieceViewModel);
    }
}
